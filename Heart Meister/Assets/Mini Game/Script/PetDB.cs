using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MiniGame
{
    public class PetDB
    {
        private PetDB()
        {
            petData = new List<Pet>();
        }

        private static PetDB petDB;
        public static PetDB CreatePetDB()
        {
            if(petDB==null)
            {
                petDB = new PetDB();
            }
            return petDB;
        }

        List<Pet> petData;

        public List<Pet> PetData
        {
            get { return petData; }
            set { petData = value; }
        }

        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}