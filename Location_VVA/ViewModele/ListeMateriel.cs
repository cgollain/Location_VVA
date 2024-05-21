using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using Location_VVA.Classe;
using MySql.Data.MySqlClient;

namespace Location_VVA.ViewModele
{
    public static class ListeMateriel
    {
        public static List<Materiel> GetAllMateriel()
        {
            List<Materiel> Materielist = new List<Materiel>();

            MySqlDataReader reader;
            string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;
            string query = "SELECT * FROM materiel"; // Correction de la table utilisée

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
                        int id_materiel = reader.GetInt32("ID_MATERIEL");
                        string nommateriel = reader.GetString("NOMMATERIEL");
                        int prixparjour = reader.GetInt32("PRIXPARJOUR");

                        Materiel materiel = new Materiel(id_materiel, nommateriel, prixparjour);
                        Materielist.Add(materiel); // Ajout à la liste de matériel
                    }

                    reader.Close(); // Fermeture du reader après utilisation
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return Materielist; // Retour de la liste de matériel
        }

        public static bool ModifMateriel(Materiel materiel)
        {
            string query = $"UPDATE `materiel` SET `NOMMATERIEL` = @nommateriel, `PRIXPARJOUR` = @prixparjour WHERE `ID_MATERIEL` = @id_materiel;";

            MySqlDataReader reader;
            string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Ajouter les paramètres avec leurs valeurs
                command.Parameters.AddWithValue("@nommateriel", materiel.GetNOMMATERIELT());
                command.Parameters.AddWithValue("@id_materiel", materiel.GetIDMATERIEL());
                command.Parameters.AddWithValue("@prixparjour", materiel.GetPRIXPARJOUR());



                // Exécuter la requête
                int rowsAffected = command.ExecuteNonQuery();

                // Vérifier si des lignes ont été affectées pour confirmer la mise à jour
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    // Aucune mise à jour effectuée (peut-être que l'ID n'a pas été trouvé)
                    return false;
                }
            }
        }
    }
}