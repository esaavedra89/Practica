
using Practica.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage(string usuario)
        {
            InitializeComponent();
            this.Master = new MasterPage();
            this.Detail = new NavigationPage(new DetailPage(usuario));

            App.MasterD = this;
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {

                var result = await this.DisplayAlert(
                    "Alert!",
                    "Desea salir de la App?",
                    "Si", "No");

                if (result)
                {
                    Application.Current.Properties["usuario"] = "";

                    Application.Current.Properties["clave"] = "";

                    await Application.Current.SavePropertiesAsync();

                    DependencyService.Get<ISalir>().ClearAllWebAppCookies();
                } 
            });

            return true;
        }
    }
}