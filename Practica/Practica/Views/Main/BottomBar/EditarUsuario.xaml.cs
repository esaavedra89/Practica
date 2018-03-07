using Practica.Data;
using Practica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.BottomBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarUsuario : ContentPage
    {
        public EditarUsuario(RegistroModel modelo)
        {
            InitializeComponent();
            BindingContext = modelo;
        }
        //Command="{Binding EditarCommand}"

        private async void EditarButton_Clicked(object sender, System.EventArgs e)
         {
             RegistroModel modelo = new RegistroModel();
             using (var contexto = new DataContext())
             {
                 contexto.Actualizar(modelo);
             }

             await Navigation.PopModalAsync();
         }
    }
}