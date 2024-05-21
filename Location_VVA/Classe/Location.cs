using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_VVA.Classe
{
    public class Location
    {
        private int ID_LOCATION;
        private DateTime DATELOCDEBUT;
        private DateTime DATELOCFIN;
        private string STATUSLOC;
        private DateTime DATERETOUR;
        private int ID_MATERIEL;
        private string USER;


        public Location(int id_location, DateTime datelocdebut, DateTime datelocfin, string statusloc, DateTime dateretour, int id_materiel, string user)
        {
            ID_LOCATION = id_location;
            DATELOCDEBUT = datelocdebut;
            DATELOCFIN = datelocfin;
            STATUSLOC = statusloc;
            DATERETOUR = dateretour;
            ID_MATERIEL = id_materiel;
            USER = user;

        }

        public int GetID_LOCATION()
        {
            return ID_LOCATION;
        }

        public DateTime GetDATELOCDEBUT()
        {
            return DATELOCDEBUT;
        }

        public DateTime GetDATELOCFIN()
        {
            return DATELOCFIN;
        }


        public string GetSTATUSLOC()
        {
            return STATUSLOC;
        }

        public DateTime GetDATERETOUR()
        {
            return DATERETOUR;
        }

        public int GetID_MATERIEL()
        {
            return ID_MATERIEL;
        }
        public string GetUSER()
        {
            return USER;
        }



        public override string ToString()
        {
            return $"ID: {ID_LOCATION}, DateLocDébut: {DATELOCDEBUT}, DateLocFin: {DATELOCFIN}, Status: {STATUSLOC}, Type compte: {DATERETOUR},Id_Mat: {ID_MATERIEL}, USER: {USER}";
        }


       
    }
}

