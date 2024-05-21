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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Location_VVA.Classe;
using VVA_Location.ViewModele;
using static System.Net.Mime.MediaTypeNames;

namespace Location_VVA.View
{
    
    public partial class ModifierLocation : Window
    {
        private Location location;
        public ModifierLocation(Location location)
        {
            InitializeComponent();
          

            this.location = location;

            textBoxDateDebutLoc.Text = location.GetDATELOCDEBUT().ToString();
            textBoxDateFinLoc.Text = location.GetDATELOCFIN().ToString();
            textBoxStatusLocation.Text = location.GetSTATUSLOC();
            textBoxDateRetour.Text = location.GetDATERETOUR().ToString();
            textBoxId_Materiel.Text = location.GetID_MATERIEL().ToString();
            textBoxUser.Text = location.GetUSER();
        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            try { 
                 
            DateTime textSplit = Convert.ToDateTime(textBoxDateDebutLoc.Text);
            DateTime textSplit2 = Convert.ToDateTime(textBoxDateFinLoc.Text);
            DateTime textSplit3 = Convert.ToDateTime(textBoxDateRetour.Text);


            Location newLocation = new Location
           (
           location.GetID_LOCATION(),
           textSplit,
           textSplit2,
           textBoxStatusLocation.Text,
           textSplit3,
           int.Parse(textBoxId_Materiel.Text),
           textBoxUser.Text
           );


            if (Location_VVA.ViewModele.ListeLocation.ModifLocation(newLocation) == true)
            {
                    MessageBox.Show("Mise à jour effectué.");
                    this.Close();
                    ListeLocation listelocation = new ListeLocation();
                    listelocation.Show();

                }
            else
            {
                MessageBox.Show("Erreur");
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            ListeLocation ListeLocation = new ListeLocation();
            ListeLocation.Show();
            this.Hide();
        }
      
    }
}
