
using Practica.Interfaces;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(Practica.Droid.Interfaces.Configuration))]
namespace Practica.Droid.Interfaces
{
    public class Configuration : IConfiguration
    {
        string Directorio;

        ISQLitePlatform Plataforma;

        string IConfiguration.directorio
        {
            get
            {
                if (string.IsNullOrEmpty(Directorio))
                {
                    Directorio = System.Environment.GetFolderPath(
                         System.Environment.SpecialFolder.Personal);
                }

                return Directorio;
            }
        }

        ISQLitePlatform IConfiguration.plataforma
        {
            get
            {
                if (Plataforma == null)
                {
                    Plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                }

                return Plataforma;
            }
        }
    }
}