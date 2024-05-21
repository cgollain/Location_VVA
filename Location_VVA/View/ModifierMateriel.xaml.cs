using System;
using System.Windows;
using Location_VVA.Classe;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Location_VVA.View
{
    public partial class ModifierMateriel : Window
    {

        private Materiel materiel;

        public ModifierMateriel(Materiel materiel)
        {
            InitializeComponent();
          

            this.materiel= materiel;

            textBoxNomMateriel.Text = materiel.GetNOMMATERIELT();
            textBoxPrixParJour.Text = materiel.GetPRIXPARJOUR().ToString();

        }

        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Materiel newmateriel = new Materiel(
                materiel.GetIDMATERIEL(),
                textBoxNomMateriel.Text,
                int.Parse(textBoxPrixParJour.Text));

            if (Location_VVA.ViewModele.ListeMateriel.ModifMateriel(newmateriel) == true)
            {
                MessageBox.Show("Mise à jour effectué.");
                this.Close();
                ListeMateriel listemateriel = new ListeMateriel();
                listemateriel.Show();
               

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
            ListeMateriel ListeMateriel = new ListeMateriel();
            ListeMateriel.Show();
            this.Hide();
        }

    }
}
