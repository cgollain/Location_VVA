using Location_VVA;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VVA_Location.ViewModele
{
    public class ConnexionManager
    {
        public static bool Connexion(string USER, string MDP)
        {
            // Récupérer la chaîne de connexion depuis les paramètres de l'application
            string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;

            string query = "SELECT * FROM Compte WHERE USER = @User AND MDP = @Password";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@User", USER);
                command.Parameters.AddWithValue("@Password", MDP);

                try
                {
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Si une ligne est retournée, cela signifie que l'utilisateur a été trouvé
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return false;
        }

       

    }
    public static class FenetreHelper
    {
        public static bool EstMainWindow(Window window)
        {
            return window is MainWindow;
        }
    }
}
