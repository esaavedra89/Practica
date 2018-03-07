
using Practica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.BottomBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        public ApiPage()
        {
            InitializeComponent();

            LvCripto.ItemSelected += LvCripto_ItemSelected;
        }

        private async void LvCripto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ApiModel modelo = (ApiModel)e.SelectedItem;

            await Navigation.PushModalAsync(new CriptoView(modelo));
        }
    }
}