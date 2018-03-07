using Practica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.BottomBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerContacto : ContentPage
    {
        public VerContacto(RegistroModel modelo)
        {
            InitializeComponent();
            this.BindingContext = modelo;
        }
    }
}