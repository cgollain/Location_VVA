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

namespace Location_VVA.View
{
    /// <summary>
    /// Logique d'interaction pour MailRetard.xaml
    /// </summary>
    public partial class MailRetard : Window
    {

        private Utilisateur utilisateur;


        public MailRetard(Utilisateur utilisateur)
        {
            InitializeComponent();


            this.utilisateur = utilisateur;


            txtEmail.Text = utilisateur.GetADRSMAILCPTE();
            txtObjet.Text = "Location en retard";
            txtContenu.Text = "Cher(e) "+ utilisateur.GetNPRENOMCPTE()+ " " + utilisateur.GetNOMCPTE() + " ," + "\r\n\r\nNous vous contactons pour vous rappeler que vous avez actuellement du matériel en votre possession qui est en retard de retour.\r\n\r\n Veuillez retourner le matériel dès que possible pour éviter tout retard supplémentaire. Pour toute question ou pour organiser le retour du matériel, veuillez nous contacter dès que possible.\r\n\r\nCordialement,\r\nVVA Location";


        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            ListeUtilisateurRetard ListeUtilisateurRetard = new ListeUtilisateurRetard();
            ListeUtilisateurRetard.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mail envoyé !");
            this.Close();
            ListeUtilisateurRetard ListeUtilisateurRetard = new ListeUtilisateurRetard();
            ListeUtilisateurRetard.Show();
        }
       
    }
}
