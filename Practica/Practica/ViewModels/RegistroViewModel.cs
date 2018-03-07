
using Practica.Data;
using Practica.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace Practica.ViewModels
{
    public class RegistroViewModel : RegistroModel
    {
        public ICommand GuardarCommand { get; private set; }
        public ICommand EditarCommand { get; private set; }
        public ICommand BorrarCommand { get; private set; }

        public RegistroViewModel()
        {
            GuardarCommand = new Command(() => 
            {
                RegistroModel modelo = new RegistroModel()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Cedula = Cedula,
                    Correo = Correo,
                    Clave = Clave
                };

                using (var contexto = new DataContext())
                {
                    contexto.Insertar(modelo);
                }
            });

            EditarCommand = new Command(()=>
            {
                RegistroModel modelo = new RegistroModel()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Cedula = Cedula,
                    Correo = Correo,
                    Clave = Clave,
                    IdPersona = IdPersona
                };

                using (var contexto = new DataContext())
                {
                    contexto.Actualizar(modelo);
                }

            });

            BorrarCommand = new Command(()=> 
            {
                RegistroModel modelo = new RegistroModel()
                {
                    Nombre = Nombre,
                    Apellido = Apellido,
                    Cedula = Cedula,
                    Correo = Correo,
                    Clave = Clave,
                    IdPersona = IdPersona
                };

                using (var contexto = new DataContext())
                {
                    contexto.Eliminar(modelo);
                }
            }); 
        }
    }
}
