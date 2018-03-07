
using Practica.Data;
using Practica.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.BottomBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactosPage : ContentPage
    {
        public ContactosPage()
        {
            InitializeComponent();
            LvUsuarios.ItemSelected += LvUsuarios_ItemSelected;
        }

        private async void LvUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string action = await DisplayActionSheet(
                "Opciones",
                "Cancelar",
                null,
                "Borrar",
                "Editar",
                "Ver");

            if (action == "Borrar")
            {
                RegistroModel modelo = (RegistroModel)e.SelectedItem;
                using (var contexto = new DataContext())
                {
                    contexto.Eliminar(modelo);
                }
            }

            else if (action == "Editar")
            {
                RegistroModel modelo = (RegistroModel)e.SelectedItem;
                await Navigation.PushModalAsync(new EditarUsuario(modelo));
            }

            else if (action == "Ver")
            {
                RegistroModel modelo = (RegistroModel)e.SelectedItem;
                await Navigation.PushModalAsync(new VerContacto(modelo));
            }
        }
    }
}