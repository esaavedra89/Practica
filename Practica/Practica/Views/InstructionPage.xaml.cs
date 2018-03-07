
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionPage : ContentPage
    {
        public InstructionPage()
        {
            InitializeComponent();
        }

        private async void Registro_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new RegistroPage());
        }
    }
}