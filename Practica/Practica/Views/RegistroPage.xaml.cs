using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }
        //Regresar a Login
        private async void BackLogin_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
        //Registrar
        private async void Registrar_Clicked(object sender, EventArgs e)
        {
            var nombre = Nombre.Text;
            var apellido = Apellido.Text;
            var cedula = Cedula.Text;
            var correo = Correo.Text;
            var clave = Clave.Text;
            int n;
            var emailEntry = sender as Entry;
            var emailP = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&\'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
            var minLimit = 2;
            var maxLimit = 15;
            var isNumericApellido = int.TryParse(apellido, out n);
            var isNumericNombre = int.TryParse(nombre, out n);
            var isNumericCI = int.TryParse(cedula, out n);

            //Validaciones
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(cedula)
                || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                "No deje campos vacios",
                "Aceptar");

                return;
            }

            else if (nombre.Length < minLimit || nombre.Length > maxLimit)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Campo Nombre no debe ser menor a 2 caracteres o mayor a 15 caracteres", 
                    "Aceptar");

                return;
            }

            else if (isNumericNombre)
            {
                 await App.Current.MainPage.DisplayAlert(
                     "Error", 
                     "Ingrese solo letras en campo Nombre", 
                     "Aceptar");

                return;
            }

            else if (apellido.Length < minLimit || apellido.Length > maxLimit)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Campo Apellido no debe ser menor a 2 caracteres o mayor a 15 caracteres", 
                    "Aceptar");

                return;
            }

            else if (isNumericApellido)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Ingrese solo letras en campo Apellido", 
                    "Aceptar");

                return;
            }

            else if (cedula.Length < 6 || cedula.Length > 8)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Campo Cedula no debe ser menor a 6 carcateres o mayor a 8 caracteres",
                    "Aceptar");

                return;
            }
            else if (!isNumericCI)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Ingrese solo numeros en campo Cedula", 
                    "Aceptar");

                return;
            }

            else if (!Regex.IsMatch(correo, emailP))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error", 
                    "Ingrese un correo valido", 
                    "Aceptar");

                return;
            }

            await App.Current.MainPage.DisplayAlert(
                    "Excelente",
                    "Formulario enviado",
                    "Aceptar");

            Nombre.Text = string.Empty;
            Apellido.Text = string.Empty;
            Cedula.Text = string.Empty;
            Correo.Text = string.Empty;
            Clave.Text = string.Empty;

            await Navigation.PopToRootAsync();
        }
    }
}