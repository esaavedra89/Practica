
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.BottomBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomPage2 : ContentPage
    {
        public BottomPage2()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, System.EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
        }

        private void ClearButton_Clicked_1(object sender, System.EventArgs e)
        {
            PadView.Clear();
        }
    }
}