
using Practica.Interfaces;
using Practica.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Practica.Data
{
    public class DataContext : RegistroModel, IDisposable
    {
        SQLiteConnection cnn;

        public DataContext()
        {
            var configuracion = DependencyService.Get<IConfiguration>();

            cnn = new SQLiteConnection(configuracion.plataforma, Path.Combine(configuracion.directorio, "persona.db3"));

            cnn.CreateTable<RegistroModel>();
        }

        public void Dispose()
        {
            cnn.Dispose();
        }

        public void Insertar(RegistroModel modelo)
        {
            cnn.Insert(modelo);
        }

        public void Actualizar(RegistroModel modelo)
        {
            cnn.Update(modelo);
        }

        public void Eliminar(RegistroModel modelo)
        {
            cnn.Delete(modelo);
        }

        public RegistroModel Consultar(int id)
        {
            return cnn.Table<RegistroModel>().FirstOrDefault(p => p.IdPersona == id);
        }

        public List<RegistroModel> Consultar()
        {
            return cnn.Table<RegistroModel>().ToList();
        }

        public TableQuery<RegistroModel> Users
        {
            get { return cnn.Table<RegistroModel>(); }
        }
    }
}
