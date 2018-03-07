using Practica.Interfaces;
using Practica.Views.Main.Bottombar;
using Practica.Views.Main.Carousel;
using Practica.Views.Main.Pestanas;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        private async void BottomBar_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new Bottom());
        }

        private async void Cripto_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await Navigation.PushModalAsync(new PestanasPage());

        }

        private async void Salir_Clicked(object sender, EventArgs e)
        {

            await App.Current.MainPage.DisplayAlert(
                "Aviso", 
                "Esta saliendo",
                "Ok");

            Application.Current.Properties["usuario"] = "";

            Application.Current.Properties["clave"] = "";

            await Application.Current.SavePropertiesAsync();

            DependencyService.Get<ISalir>().ClearAllWebAppCookies();
        }

        private async void Carousel_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new CarouselXam());
        }
    }
}