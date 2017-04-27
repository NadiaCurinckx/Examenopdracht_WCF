using Model;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IBoekService _boekLogica;
        private readonly IGenreService _genreLogica;


        public MainWindow()
        {
            InitializeComponent();

            var genreChannelFactory = new ChannelFactory<IGenreService>(new BasicHttpBinding());
            _genreLogica = genreChannelFactory.CreateChannel(new EndpointAddress("http://localhost:1399/CategorieService.svc"));

            var boekChannelFactory = new ChannelFactory<IBoekService>(new BasicHttpBinding());
            _boekLogica = boekChannelFactory.CreateChannel(new EndpointAddress("http://localhost:1399/BoekService.svc"));

        }

        //private async Task LijstenVernieuwen()
        //{
            
        //}


        private void btnBoekToevoegen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBoekBewerken_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBoekVerwijderen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lsbBoeken_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
