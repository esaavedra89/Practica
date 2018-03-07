using Practica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.BottomBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CriptoView : ContentPage
    {
        public CriptoView(ApiModel modelo)
        {
            InitializeComponent();

            BindingContext = modelo;
        }
    }
}