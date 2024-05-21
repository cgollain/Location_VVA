using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using MySql.Data.MySqlClient;

namespace Location_VVA.View
{
    /// <summary>
    /// Logique d'interaction pour ListeLocation.xaml
    /// </summary>
    public partial class ListeLocation : Window
    {


        public ListeLocation()
        {
            InitializeComponent();

            foreach (Location u in Location_VVA.ViewModele.ListeLocation.GetAllLocation())
            {
                ListBoxLocation.Items.Add(u);
            }

        }

        private void Retour_Click(object sender, RoutedEventArgs e)
        {
            Mainmenu mainmenu = new Mainmenu();
            mainmenu.Show();
            this.Hide();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si une location est sélectionnée dans la liste
            if (ListBoxLocation.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une location à modifier.");
                return; // Sortir de la méthode car aucune location à modifier n'est sélectionnée
            }

            Location selectedLocation = (Location)ListBoxLocation.SelectedItem;

            if (selectedLocation != null)
            {
                ModifierLocation modifierLocation = new ModifierLocation(selectedLocation);
                modifierLocation.Show();
                this.Hide();
            }
        }


        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer la location sélectionnée dans la liste
            Location selectedLocation = (Location)ListBoxLocation.SelectedItem;

            // Vérifier si une location a été sélectionnée
            if (selectedLocation != null)
            {
                // Afficher une boîte de dialogue de confirmation
                MessageBoxResult result = MessageBox.Show("Etes-vous sûr de vouloir supprimer cette location ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                // Vérifier la réponse de l'utilisateur
                if (result == MessageBoxResult.Yes)
                {
                    // Supprimer la location seulement si l'utilisateur confirme
                    try
                    {
                        // Récupérer l'ID de la location à supprimer
                        int currentID = selectedLocation.GetID_LOCATION();

                        // Requête SQL pour supprimer la location de la base de données
                        string query = "DELETE FROM `location` WHERE `ID_LOCATION` = @id;";

                        // Chaîne de connexion à la base de données
                        string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;

                        // Ouvrir une connexion à la base de données
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            // Créer une commande SQL avec la requête et la connexion
                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                // Ajouter le paramètre ID avec sa valeur
                                command.Parameters.AddWithValue("@id", currentID);

                                // Exécuter la commande SQL et obtenir le nombre de lignes affectées
                                int rowsAffected = command.ExecuteNonQuery();

                                // Vérifier si des lignes ont été affectées
                                if (rowsAffected > 0)
                                {
                                    // Afficher un message de succès
                                    MessageBox.Show("Suppression effectuée.");

                                    // Fermer la fenêtre actuelle
                                    this.Close();

                                    // Ouvrir la liste des locations mise à jour
                                    ListeLocation listelocation = new ListeLocation();
                                    listelocation.Show();
                                }
                                else
                                {
                                    // Aucune suppression effectuée
                                    MessageBox.Show("La suppression a échoué.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Afficher toute erreur survenue lors de la suppression
                        MessageBox.Show("Une erreur est survenue lors de la suppression : " + ex.Message);
                    }
                }
            }
            else
            {
                // Aucune location sélectionnée, afficher un message d'avertissement
                MessageBox.Show("Veuillez sélectionner une location à supprimer.");
            }
        }
    }
}