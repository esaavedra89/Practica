
using Android.Webkit;
using Practica.Droid.Interfaces;
using Practica.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(Salir))]
namespace Practica.Droid.Interfaces
{
    public class Salir : ISalir       
    {
        public void ClearAllWebAppCookies()       
        {
            CookieManager.Instance.RemoveAllCookie();       
        }
    }
}
