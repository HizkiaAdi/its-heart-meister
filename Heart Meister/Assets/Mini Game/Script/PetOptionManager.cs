using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniGameModel;

namespace MiniGame
{
    public class PetOptionManager : MonoBehaviour
    {
        public GUIText attack, defense, speed, specialAttack, specialDefense, health;

        PetDB petDB;
        TrainingPetAttributs attributs;
        // Use this for initialization
        void Start()
        {
            attributs = TrainingPetAttributs.CreateTrainingAtributSingleton();

            petDB = PetDB.CreatePetDB();
            SetPetAtribut(0);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SetPetAtribut(int id)
        {
            petDB.Id = id;
            attack.text = petDB.PetData[id].Attack.ToString();
            defense.text = petDB.PetData[id].Defense.ToString();
            speed.text = petDB.PetData[id].Speed.ToString();
            specialAttack.text = petDB.PetData[id].SpecialAttack.ToString();
            specialDefense.text = petDB.PetData[id].SpecialDefense.ToString();
            health.text = petDB.PetData[id].Health.ToString();
        }

        void SelectingPet(string param)
        {
            switch (param)
            {
                case "0": SetPetAtribut(0); break;
                case "1": SetPetAtribut(1); break;
                case "2": SetPetAtribut(2); break;
            }
        }

        void GoToTraining()
        {
            attributs.Attack = petDB.PetData[petDB.Id].Attack;
            attributs.Defense = petDB.PetData[petDB.Id].Defense;
            attributs.Speed = petDB.PetData[petDB.Id].Speed;
            attributs.SpecialAttack = petDB.PetData[petDB.Id].SpecialAttack;
            attributs.SpecialDefense = petDB.PetData[petDB.Id].SpecialDefense;
            attributs.Health = petDB.PetData[petDB.Id].Health;
            attributs.Level = petDB.PetData[petDB.Id].Level;

            Application.LoadLevel("MiniGameMenu");
        }
    }
}