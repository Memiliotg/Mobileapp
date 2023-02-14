using PruebaOrionTek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaOrionTek.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DireccionesDetail : ContentPage
	{
		public DireccionesDetail ()
		{
			InitializeComponent ();
		}
        Models.Direcciones _direcciones;

        public DireccionesDetail(Models.Direcciones direcciones)
        {
            InitializeComponent();
            Title = "Editar direcciones";
            _direcciones = direcciones;
            DireccionEntry.Text = direcciones.Direccion;

            DireccionEntry.Focus();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DireccionEntry.Text))
            {
                await DisplayAlert("Invalido", "Esta Dejando el campo de Direccion vacio", "OK");
            }
            else if (_direcciones != null)
            {
                EditDireccion();
            }
            else
            {
                AddNewDireccion();
            }


        }

        async void AddNewDireccion()
        {
            await App.DataBase.CreateDireccionAsync(new Models.Direcciones
            {
                Direccion = DireccionEntry.Text,



            });
            await Navigation.PopAsync();
        }

        async void EditDireccion()
        {
            _direcciones.Direccion = DireccionEntry.Text;

            await App.DataBase.UpdateDireccionesAsync(_direcciones);
            await Navigation.PopAsync();
        }
    }
}