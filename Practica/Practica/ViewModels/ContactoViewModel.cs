

using Practica.Models;
using System.Collections.ObjectModel;
using Practica.Data;

namespace Practica.ViewModels
{
    public class ContactoViewModel : RegistroModel
    {
        private ObservableCollection<RegistroModel> _listadoPersonas;

        public ObservableCollection<RegistroModel> ListadoPersonas
        {
            get {

                if (_listadoPersonas == null)
                {
                    LlenarPersonas();
                }

                return _listadoPersonas;

            }
            set { _listadoPersonas = value; }
        }

        public void LlenarPersonas()
        {
            using (var contexto = new DataContext())
            {
                ObservableCollection<RegistroModel> modelo = new ObservableCollection<RegistroModel>(contexto.Consultar());
                _listadoPersonas = modelo;
            }
        }
    }
}
