
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica.Views.Main.Carousel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselXam : CarouselPage
    {
        public CarouselXam()
        {
            InitializeComponent();
            Children.Add(new Carousel1());
            Children.Add(new Carousel2());
        }
    }
}