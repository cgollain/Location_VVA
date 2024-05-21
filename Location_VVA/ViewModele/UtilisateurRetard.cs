using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Location_VVA.ViewModele
{
    public static class ListeUtilisateurRetard
    {
        public static List<Utilisateur> GetAllUsersRetard()
        {
            List<Utilisateur> users = new List<Utilisateur>();

            MySqlDataReader reader;
            string connectionString = Location_VVA.Properties.Settings.Default.SConnexion;
            string query = "SELECT DISTINCT l.USER, c.NOMCPTE, c.PRENOMCPTE, c.NOTELCPTE, c.NOPORTCPTE, c.DATEINSCRIP, c.TYPECOMPTE, c.ADRMAILCPTE " +
                            "FROM location l " +
                            "JOIN compte c ON l.USER = c.USER " +
                            "WHERE l.DATELOCFIN < CURRENT_DATE AND l.STATUSLOC != 'Terminée';";



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
                        string user = reader.GetString("USER");
                        string nomCpte = reader.GetString("NOMCPTE");
                        string prenomCpte = reader.GetString("PRENOMCPTE");
                        DateTime dateInscrip = reader.GetDateTime("DATEINSCRIP");
                        string typeCompte = reader.GetString("TYPECOMPTE");
                        string adrMailCpte = reader.GetString("ADRMAILCPTE");
                        string noTelCpte = reader.GetString("NOTELCPTE");
                        string noPortCpte = reader.GetString("NOPORTCPTE");

                        Utilisateur utilisateur = new Utilisateur(user, nomCpte, prenomCpte, dateInscrip, typeCompte, adrMailCpte, noTelCpte, noPortCpte);

                        // Ajoutez l'utilisateur à la liste des utilisateurs
                        users.Add(utilisateur);

                    }


                }
                catch (Exception ex)    
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return users;
        }



    }
}
