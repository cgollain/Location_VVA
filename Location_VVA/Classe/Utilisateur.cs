using System;

namespace Location_VVA
{
    public class Utilisateur
    {
        private string USER;
        private string NOMCPTE;
        private string NPRENOMCPTE;
        private DateTime DATEINSCRIP;
        private string TYPECOMPTE;
        private string ADRSMAILCPTE;
        private string NOTELCPTE;
        private string NOPORTCPTE;

       public Utilisateur(string user, string nomcpte, string nprenomcpte, DateTime dateinscrip, string typecompte, string adrsmailcpte, string notelcpte, string noportcpte)
        {
            USER = user;
            NOMCPTE = nomcpte;
            NPRENOMCPTE = nprenomcpte;
            DATEINSCRIP = dateinscrip;
            TYPECOMPTE = typecompte;
            ADRSMAILCPTE = adrsmailcpte;
            NOTELCPTE = notelcpte;
            NOPORTCPTE = noportcpte;
        }


        public string GetUSER()
        {
            return USER;
        }

        public string GetNOMCPTE()
        {
            return NOMCPTE;
        }

        public string GetNPRENOMCPTE()
        {
            return NPRENOMCPTE;
        }

        public DateTime GetDATEINSCRIP()
        {
            return DATEINSCRIP;
        }

        public string GetTYPECOMPTE()
        {
            return TYPECOMPTE;
        }

        public string GetADRSMAILCPTE()
        {
            return ADRSMAILCPTE;
        }

        public string GetNOTELCPTE()
        {
            return NOTELCPTE;
        }

        public string GetNOPORTCPTE()
        {
            return NOPORTCPTE;
        }

        public override string ToString()
        {
            return $"User: {USER}, Nom: {NOMCPTE}, Prénom: {NPRENOMCPTE}, Date inscription: {DATEINSCRIP}, Type compte: {TYPECOMPTE}, Mail: {ADRSMAILCPTE}, Téléphone: {NOTELCPTE}, Portable: {NOPORTCPTE}";
        }


       
    }
}
