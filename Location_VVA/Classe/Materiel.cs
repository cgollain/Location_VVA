using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_VVA.Classe
{
    public class Materiel
    {
        private int ID_MATERIEL;
        private string NOMMATERIEL;
        private int PRIXPARJOUR;


        public Materiel(int id_materiel, string nommateriel, int prixparjour)
        {
            ID_MATERIEL = id_materiel;
            NOMMATERIEL = nommateriel;
            PRIXPARJOUR = prixparjour;


        }
        public Materiel()
        {

        }

        public int GetIDMATERIEL()
        {
            return ID_MATERIEL;
        }

        public string GetNOMMATERIELT()
        {
            return NOMMATERIEL;
        }

        public int GetPRIXPARJOUR()
        {
            return PRIXPARJOUR;
        }



        public override string ToString()
        {
            return $"ID_Matériel: {ID_MATERIEL}, Nom: {NOMMATERIEL}, Prix: {PRIXPARJOUR}";
        }

    }
}
