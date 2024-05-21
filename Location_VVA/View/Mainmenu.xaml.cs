using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VVA_Location.ViewModele;
using static VVA_Location.ViewModele.ConnexionManager;

namespace Location_VVA.View
{
    /// <summary>
    /// Logique d'interaction pour Mainmenu.xaml
    /// </summary>
    public partial class Mainmenu : Window
    {
        public Mainmenu()
        {
            InitializeComponent();
        }

        private void BtnConsulterMateriel_Click(object sender, RoutedEventArgs e)
        {
                ListeMateriel listemateriel = new ListeMateriel();
                listemateriel.Show();
                this.Hide();
        }
    

        private void BtnConsulterLocations_Click(object sender, RoutedEventArgs e)
        {
            ListeLocation listelocation = new ListeLocation();
            listelocation.Show();
            this.Hide();
        }

        private void BtnConsulterUtilisateurs_Click(object sender, RoutedEventArgs e)
        {
            ListeUtilisateur listeutilisateur = new ListeUtilisateur();
            listeutilisateur.Show();
            this.Hide();
        }

        private void BtnUtilisateursEnRetard_Click(object sender, RoutedEventArgs e)
        {
            ListeUtilisateurRetard listeutilisateurretard = new ListeUtilisateurRetard();
            listeutilisateurretard.Show();
            this.Hide();
        }



        // Gestion de l'événement de clic sur le bouton de déconnexion
        private void Deconnexion_Click(object sender, RoutedEventArgs e)
        {


            
            MainWindow pageConnexion = new MainWindow();
            pageConnexion.Show();
            this.Hide();

        }





    }
}
