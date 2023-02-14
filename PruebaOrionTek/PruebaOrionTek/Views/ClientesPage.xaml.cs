using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaOrionTek.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaOrionTek.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientesPage : ContentPage
    {
        public ClientesPage()
        {
            InitializeComponent();
        }

        


        protected async override void OnAppearing()
        {
            base.OnAppearing();

             
            var ClientesList = await App.DataBase.GetClientesAsync();
            if (ClientesList != null)
            {
                ClientesListView.ItemsSource = ClientesList;
            }
        }
        async void AgreggarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientesDetail());
        }


       
        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cli = item.CommandParameter as Cliente;
            await Navigation.PushAsync(new ClientesDetail(cli));
        }

      async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var cli = item.CommandParameter as Cliente;
            var result = await DisplayAlert("Borrar",$"Quiere eliminar a {cli.Nombre}?","Si","No");
            if(result)
            {
                await App.DataBase.DeleteClienteAsync(cli);
                ClientesListView.ItemsSource = await App.DataBase.GetClientesAsync();
            }
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClientesListView.ItemsSource = await App.DataBase.Search(e.NewTextValue);
        }

       

        async void ClientesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var Current = (e.CurrentSelection.FirstOrDefault() as Cliente);
            var x = (Current.Id != null) ? Current.Id : 0;  
            await Navigation.PushAsync(new DireccionesPage(x));

        }
    }
}