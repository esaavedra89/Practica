
using SQLite.Net.Interop;

namespace Practica.Interfaces
{
    public interface IConfiguration
    {
        //Variable a crear para el directorio del DB
        string directorio { get; }
        //propiedad a acceder a cada plataforma
        ISQLitePlatform plataforma { get; }
    }
}
