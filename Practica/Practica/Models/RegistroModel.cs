
using SQLite.Net.Attributes;
using System.ComponentModel;

namespace Practica.Models
{
    public class RegistroModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        int _idPersona;

        string _nombre;

        string _apellido;

        int _cedula;

        string _correo;

        string _clave;

        [PrimaryKey, AutoIncrement]
        public int IdPersona
        {
            get
            {
                return _idPersona;
            }
            set
            {
                if (_idPersona != value)
                {
                    _idPersona = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IdPersona)));
                }
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                if (_nombre != value)
                {
                    _nombre = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Nombre)));
                }
            }
        }

        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                if (_apellido != value)
                {
                    _apellido = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Apellido)));
                }
            }
        }

        public int Cedula
        {
            get
            {
                return _cedula;
            }
            set
            {
                if (_cedula != value)
                {
                    _cedula = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Cedula)));
                }
            }
        }

        public string Correo
        {
            get
            {
                return _correo;
            }
            set
            {
                if (_correo != value)
                {
                    _correo = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Correo)));
                }
            }
        }

        public string Clave
        {
            get
            {
                return _clave;
            }
            set
            {
                if (_clave != value)
                {
                    _clave = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Clave)));
                }
            }
        }
    }
}
