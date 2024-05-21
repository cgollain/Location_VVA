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
using Location_VVA.Classe;

namespace Location_VVA.View
{
    /// <summary>
    /// Logique d'interaction pour ListeUtilisateurRetard.xaml
    /// </summary>
    public partial class ListeUtilisateurRetard : Window
    {
        public ListeUtilisateurRetard()
        {

            InitializeComponent();
             foreach (Utilisateur u in Location_VVA.ViewModele.ListeUtilisateurRetard.GetAllUsersRetard())
            {
                lstUsers.Items.Add(u);
            }
        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Mainmenu mainmenu = new Mainmenu();
            mainmenu.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un utilisateur est sélectionné dans la liste
            if (lstUsers.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur pour envoyer un e-mail.");
                return; // Sortir de la méthode car aucun utilisateur n'est sélectionné
            }

            Utilisateur selectedUser = (Utilisateur)lstUsers.SelectedItem;

            if (selectedUser != null)
            {
                MailRetard mailRetard = new MailRetard(selectedUser);
                mailRetard.Show();
                this.Hide();
            }
        }

    }
}
