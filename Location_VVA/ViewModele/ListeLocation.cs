using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using Location_VVA.Classe;
using MySql.Data.MySqlClient;

namespace Location_VVA.ViewModele
{
    public static class ListeLocation
    {
        public static List<Location> GetAllLocation()
        {
            List<Location> Locationlist = new List<Location>();

            MySqlDataReader reader;
            string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;
            string query = "SELECT * FROM location"; // Correction de la table utilisée

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = query;
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id_location = reader.GetInt32("ID_LOCATION");
                        DateTime datelocdebut = reader.GetDateTime("DATELOCDEBUT");
                        DateTime datelocfin = reader.GetDateTime("DATELOCFIN");
                        string statusloc = reader.GetString("STATUSLOC");
                        DateTime datelocretour = reader.GetDateTime("DATERETOUR");
                        int id_materiel = reader.GetInt32("ID_MATERIEL");
                        string user = reader.GetString("USER");

                        Location location = new Location(id_location, datelocdebut, datelocfin, statusloc, datelocretour, id_materiel, user);
                        Locationlist.Add(location); // Ajout à la liste de matériel
                    }

                    reader.Close(); // Fermeture du reader après utilisation
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return Locationlist; // Retour de la liste de matériel
        }


        public static bool ModifLocation(Location location)
        {
            string query = $"UPDATE `location` SET `DATELOCDEBUT` = @datedebutloc, `DATELOCFIN` = @datefinloc, `STATUSLOC` = @statusloc, `DATERETOUR` = @dateretour, `ID_MATERIEL` = @id_materiel, `USER` = @user WHERE `ID_LOCATION` = @id_location;";

            string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Ajouter les paramètres avec leurs valeurs
                        command.Parameters.AddWithValue("@id_location", location.GetID_LOCATION());
                        command.Parameters.AddWithValue("@datedebutloc", location.GetDATELOCDEBUT());
                        command.Parameters.AddWithValue("@datefinloc", location.GetDATELOCFIN());
                        command.Parameters.AddWithValue("@statusloc", location.GetSTATUSLOC());
                        command.Parameters.AddWithValue("@dateretour", location.GetDATERETOUR());
                        command.Parameters.AddWithValue("@id_materiel", location.GetID_MATERIEL());
                        command.Parameters.AddWithValue("@user", location.GetUSER());

                        // Exécuter la requête
                        int rowsAffected = command.ExecuteNonQuery();

                        // Vérifier si des lignes ont été affectées pour confirmer la mise à jour
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Mise à jour réussie !");
                            return true;
                        }
                        else
                        {
                            // Aucune mise à jour effectuée (peut-être que l'ID n'a pas été trouvé)
                            Console.WriteLine("Aucune ligne mise à jour.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Afficher les détails de l'erreur
                Console.WriteLine("Erreur lors de la mise à jour de la base de données : " + ex.Message);
                return false;
            }
        }



    }
}
