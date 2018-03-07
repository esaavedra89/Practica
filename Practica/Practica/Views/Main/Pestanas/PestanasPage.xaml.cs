using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.Pestanas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PestanasPage : TabbedPage
    {
        public PestanasPage()
        {
            InitializeComponent();
        }
    }
}