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
using MySql.Data.MySqlClient;

namespace Location_VVA.View
{
    /// <summary>
    /// Logique d'interaction pour ListeMateriel.xaml
    /// </summary>
    public partial class ListeMateriel : Window
    {
        public ListeMateriel()
        {
            InitializeComponent();

            foreach (Materiel u in Location_VVA.ViewModele.ListeMateriel.GetAllMateriel())
            {
                ListBoxMateriel.Items.Add(u);
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
            // Vérifier si un élément est sélectionné dans la liste
            if (ListBoxMateriel.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un matériel à modifier.");
                return; // Sortir de la méthode car aucun élément à modifier n'est sélectionné
            }

            Materiel selectedMateriel = (Materiel)ListBoxMateriel.SelectedItem;

            if (selectedMateriel != null)
            {
                ModifierMateriel modifierMateriel = new ModifierMateriel(selectedMateriel);
                modifierMateriel.Show();
                this.Hide();
            }
        }



        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier si un élément est sélectionné dans la liste
            if (ListBoxMateriel.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un matériel à supprimer.");
                return; // Sortir de la méthode car aucun élément à supprimer n'est sélectionné
            }

            // Afficher une boîte de dialogue de confirmation
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce matériel ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Vérifier la réponse de l'utilisateur
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Materiel selectedMateriel = (Materiel)ListBoxMateriel.SelectedItem;

                    if (selectedMateriel != null)
                    {
                        int currentID = selectedMateriel.GetIDMATERIEL();

                        string query = "DELETE FROM `materiel` WHERE `ID_MATERIEL` = @id;";

                        string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;
                        MySqlConnection connection = new MySqlConnection(connectionString);
                        connection.Open();

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            // Ajouter le paramètre ID avec sa valeur
                            command.Parameters.AddWithValue("@id", currentID); // Assurez-vous de définir correctement currentID

                            // Exécuter la requête
                            int rowsAffected = command.ExecuteNonQuery();

                            // Vérifier si des lignes ont été affectées pour confirmer la suppression
                            if (rowsAffected > 0)
                            {
                                this.Close();
                                MessageBox.Show("Suppression effectuée avec succès.");

                                // Recharger la liste de matériel après la suppression
                                ListeMateriel listemateriel = new ListeMateriel();
                                listemateriel.Show();
                            }
                            else
                            {
                                // Aucune suppression effectuée (peut-être que l'ID n'a pas été trouvé)
                                MessageBox.Show("La suppression a échoué.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    }
