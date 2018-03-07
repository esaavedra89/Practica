using Practica.Data;
using Practica.Interfaces;
using Practica.Views.Main;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        //Registro
        private async void GoToRegsitro_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InstructionPage());
        }
        //Olvido contraseña
        private async void GoToOlvidePassword_Tapped(object sender, EventArgs e)
        {
                await Application.Current.MainPage.DisplayAlert(
                    "Epa!",
                    "Marico el que lea esto!",
                    "Aceptar");
        }
        //Login
        private async void Enviar_Clicked(object sender, EventArgs e)
        {
            var usuario = Usuario.Text;

            var clave = Clave.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave))
            {
                await App.Current.MainPage.DisplayAlert(
                    "ERROR!",
                    "No debe dejar campos vacios",
                    "Aceptar");
                return;
            }
            
            try {
                
                //Peticion a la DB local
                var contexto = new DataContext();

                var request = contexto.Users.Where(f => f.Correo.Equals(usuario) || f.Nombre.Equals(usuario)).FirstOrDefault();

                if (request?.Clave == clave)
                {
                    await App.Current.MainPage.DisplayAlert("Excelente", "Acceso Concedido", "Aceptar");
                    //permanencia simple de datos
                    Application.Current.Properties["usuario"] = usuario;

                    Application.Current.Properties["clave"] = clave;
                    //Guarda propiedades en el telefono
                    await Application.Current.SavePropertiesAsync();

                    var perma = Application.Current.Properties["usuario"] as string;
               
                    await Navigation.PushModalAsync(new MainPage(perma));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Usuario o clave invalidos", "Aceptar");

                    return;
                }
                }
                catch (Exception)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Un error a ocurrido con la DB", "Aceptar");

                    return;
                }

                Usuario.Text = string.Empty;

                Clave.Text = string.Empty;
            }
        //Via rapida
        private async void GoToMain_Tapped(object sender, EventArgs e)
        {
            var perma = Application.Current.Properties["usuario"] as string;

            await Navigation.PushModalAsync(new MainPage(perma));
        }

        //Limpiar permanencia
        public void ClearPermanencia()
        {
            Device.BeginInvokeOnMainThread(async () => {

                var result = await this.DisplayAlert(
                    "Alert!",
                    "Desea salir de la App?",
                    "Si", "No");

                if (result)
                {
                    LoginPage permanencia = new LoginPage();

                    permanencia.ClearPermanencia();

                    DependencyService.Get<ISalir>().ClearAllWebAppCookies();
                } 
            });
        }
    }
}