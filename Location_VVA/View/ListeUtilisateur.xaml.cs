using System.Windows;
using System.Windows.Controls;
using Location_VVA.ViewModele;

namespace Location_VVA.View
{
    public partial class ListeUtilisateur : Window
    {
        public ListeUtilisateur()
        {
            InitializeComponent();
          
            foreach (Utilisateur u in Location_VVA.ViewModele.ListeUtilisateur.GetAllUsers())
            {
                lstUsers.Items.Add(u);
            }

        }

        private void BtnRetour_Click(object sender, RoutedEventArgs e)
        {
            Mainmenu mainmenu = new Mainmenu();
            mainmenu.Show();
            this.Hide();
        }




    }
}
