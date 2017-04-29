using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _genreLogica = genreChannelFactory.CreateChannel(new EndpointAddress("http://localhost:8054/CategorieService.svc"));

            var boekChannelFactory = new ChannelFactory<IBoekService>(new BasicHttpBinding());
            _boekLogica = boekChannelFactory.CreateChannel(new EndpointAddress("http://localhost:8054/BoekService.svc"));

            ToonBoeken();
        }




        private void btnBoekToevoegen_Click(object sender, RoutedEventArgs e)
        {
            BewaarBoek();
            ToonBoeken();
            MaakVeldenLeeg();
        }

        private void btnBoekBewerken_Click(object sender, RoutedEventArgs e)
        {
            EditeerBoek();
            ToonBoeken();
            MaakVeldenLeeg();
        }

        private void btnBoekVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            VerwijderBoek();
            ToonBoeken();
            MaakVeldenLeeg();
        }

        private void lsbBoeken_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ToonGeselecteerdBoek();
        }




        public bool IsGeldigBoek()
        {
            if (string.IsNullOrEmpty(txtTitel.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtAuteur.Text))
            {
                return false;
            }

            if (string.IsNullOrEmpty(txtAantalPaginas.Text))
            {
                return false;
            }

            try
            {
                Convert.ToInt32(txtAantalPaginas.Text);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async void BewaarBoek()
        {
            if (IsGeldigBoek())
            {
                Boek boek = new Boek()
                {
                    Titel = txtTitel.Text,
                    Auteur = txtAuteur.Text,
                    AantalPaginas = Convert.ToInt32(txtAantalPaginas.Text),
                    Genres = new List<Genre>()
                };


                //using (var database = new Database())
                //{
                //    foreach (var genre in NeemGeselecteerdeGenres())
                //    {
                //        boek.Genres.Add(database.Genres.SingleOrDefault(x => x.Id == genre.Id));
                //    }
                //}

                await _boekLogica.BewaarBoek(boek);

            }

            else
            {
                MessageBox.Show("Controleer of je alle velden correct hebt ingevuld.", "Fout tijdens bewaren van het boek", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public List<Genre> NeemGeselecteerdeGenres()
        {
            return lsbGenre.SelectedItems.Cast<Genre>().ToList();
        }

        public async void ToonBoeken()
        {
            lsbBoeken.Items.Clear();

            var boekenlijst = await _boekLogica.NeemAlleBoeken();

            foreach (var boek in boekenlijst)
            {
                lsbBoeken.Items.Add(boek);
            }
        }

        public void MaakVeldenLeeg()
        {
            txtTitel.Text = "";
            txtAuteur.Text = "";
            txtAantalPaginas.Text = "";
            lsbGenre.SelectedItems.Clear();
        }

        public void VerwijderBoek()
        {
            Boek geselecteerdBoek = (Boek)lsbBoeken.SelectedItem;

            if (geselecteerdBoek != null)
            {
                _boekLogica.VerwijderBoek(geselecteerdBoek.Id);
            }

        }

        public void EditeerBoek()
        {
            if (IsGeldigBoek())
            {
                Boek geselecteerdBoek = (Boek)lsbBoeken.SelectedItem;

                if (geselecteerdBoek != null)
                {
                    //_boekLogica.WijzigBoek(geselecteerdBoek, List<int>NeemGeselecteerdeGenres())
                }

                else
                {
                    MessageBox.Show("Het lijkt erop dat een andere collega het boek, dat u wenste te bewerken, heeft verwijderd.", "Fout tijdens bewerken van het boek.", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }


            else
            {
                MessageBox.Show("Controleer of je alle velden correct hebt ingevuld.", "Fout tijdens bewaren van het boek", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ToonGeselecteerdBoek()
        {
            Boek geselecteerdBoek = (Boek)lsbBoeken.SelectedItem;
            if (geselecteerdBoek != null)
            {
                _boekLogica.NeemBoek(geselecteerdBoek.Id);


            }
        }


    }
}