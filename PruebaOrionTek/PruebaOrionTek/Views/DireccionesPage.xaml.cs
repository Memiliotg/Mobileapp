using ImTools;
using PruebaOrionTek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaOrionTek.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DireccionesPage : ContentPage
	{
        private int Id;
		public DireccionesPage (int id)
		{
			InitializeComponent ();
            Id = id;
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();


            var DireccionesList = await App.DataBase.GetDireccionesAsync(Id);
            if (DireccionesList != null)
            {
                DireccionesCollectionView.ItemsSource = DireccionesList;
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
            var di = item.CommandParameter as Direcciones;
            var result = await DisplayAlert("Borrar", "Quiere eliminar esta Direccion?", "Si", "No");
            if (result)
            {
                await App.DataBase.DeleteDireccionesAsync(di);
                DireccionesCollectionView.ItemsSource = await App.DataBase.GetDireccionesAsync(Id);
            }
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            DireccionesCollectionView.ItemsSource = await App.DataBase.Search(e.NewTextValue);
        }
    }
}