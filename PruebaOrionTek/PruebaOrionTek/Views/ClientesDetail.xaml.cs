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
    public partial class ClientesDetail : ContentPage
    {
        public ClientesDetail()
        {
            InitializeComponent();
        }

        Models.Cliente _cliente;
        public ClientesDetail(Models.Cliente cliente)
        {
            InitializeComponent();
            Title = "Editar Cliente";
            _cliente = cliente;
            NombreEntry.Text = cliente.Nombre;

            NombreEntry.Focus();
        }



        async void Button_Clicked(object sender, EventArgs e)
        {
           if(string.IsNullOrWhiteSpace (NombreEntry.Text))
            {
                await DisplayAlert("Invalido", "Esta Dejando el campo de nombre vacio", "OK");
            }
           else if (_cliente!=null)
           {
                EditCliente();
           }
            else
            {
                AddNewCliente();
            }

        }
        async void AddNewCliente()
        {
            await App.DataBase.CreateClientesAsync(new Models.Cliente
            {
                Nombre = NombreEntry.Text,



            });
            await Navigation.PopAsync();
        }

        async void EditCliente()
        {
          
            _cliente.Nombre = NombreEntry.Text;

            await App.DataBase.UpdateClienteAsync(_cliente);
            await Navigation.PopAsync();

        }
    }
}