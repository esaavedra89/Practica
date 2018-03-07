using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Practica.Views.Main.BottomBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomPage3 : ContentPage
    {
        ZXingScannerPage scanPage;

        public BottomPage3()
        {
            InitializeComponent();
        }

        private async void ScanButton_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {

                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {

                    Navigation.PopModalAsync();

                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
            await Navigation.PushModalAsync(scanPage);
        }
    }
}