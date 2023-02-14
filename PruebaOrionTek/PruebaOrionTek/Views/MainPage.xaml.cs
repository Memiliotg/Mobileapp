using Prism.Services.Dialogs;
using System;

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
                EmpresaListView.ItemsSource = EmpresaList;
            }
        }



        async void AgreggarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmpresaDetail());
        }

       async void TextCell_Tapped(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ClientesPage());
        }
    }
}
