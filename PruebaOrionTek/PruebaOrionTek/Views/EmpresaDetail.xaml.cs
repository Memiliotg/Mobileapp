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
    public partial class EmpresaDetail : ContentPage
    {
        public EmpresaDetail()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreEntry.Text))
            {
                await DisplayAlert("Invalido", "Esta Dejando el campo de nombre vacio", "OK");
            }
            else
            {
                AddNewCliente();
            }

            async void AddNewCliente()
            {
                await App.DataBase.CreateEmpresaAsync(new Models.Empresa
                {
                    Nombre = NombreEntry.Text
                    
                });
                await Navigation.PopAsync();
            }

        }
    }
}