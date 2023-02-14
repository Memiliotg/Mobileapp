using Prism.Services.Dialogs;
using PruebaOrionTek.Models;
using System;
using System.Linq;
using System.Net.WebSockets;
using Xamarin.Forms;

namespace PruebaOrionTek.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
      
       

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            var EmpresaList = await App.DataBase.GetEmpresaAsync();
            if (EmpresaList != null)
            {
                MainPageCollectionView.ItemsSource = EmpresaList;
            }
        }

        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var Emp = item.CommandParameter as Empresa;
            await Navigation.PushAsync(new EmpresaDetail(Emp));
        }

        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var Emp = item.CommandParameter as Empresa;
            var result = await DisplayAlert("Borrar", $"Quiere eliminar a {cli.Nombre}?", "Si", "No");
            if (result)
            {
                await App.DataBase.DeleteEmpresaAsync(Emp);
                MainPageCollectionView.ItemsSource = await App.DataBase.GetClientesAsync();
            }
        }

        async void AgreggarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmpresaDetail());
        }

      

        async void MainPageCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Current = (e.CurrentSelection.FirstOrDefault() as Empresa);
            var x = (Current.Id != null) ? Current.Id : 0;
            await Navigation.PushAsync(new ClientesPage((int)x));
        }
    }
}
