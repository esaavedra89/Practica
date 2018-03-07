
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(string usuario)
        {
            InitializeComponent();
            //Disparamos el evento periodico
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            Usuario.Text = usuario;
        }

        bool OnTimerTick()
        {
            //Iniciamos variable tiempo
            DateTime dt = DateTime.Now;
            //Asignamos Hora
            timeLabel.Text = dt.ToString("T");
            //Asignamos Fecha
            dateLabel.Text = dt.ToString("D");

            return true;

        }
    }
}