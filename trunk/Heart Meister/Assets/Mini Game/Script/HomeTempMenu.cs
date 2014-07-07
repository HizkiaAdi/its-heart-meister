using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class HomeTempMenu : MonoBehaviour
    {
        Pet pet;
        PetDB petDB;

        void Start()
        {
            petDB = PetDB.CreatePetDB();
            for(int i=1;i<=3;i++)
            {
                pet = new Pet();
                pet.Attack = Random.Range(25, 70) * i;
                pet.Defense = Random.Range(25, 70) * i;
                pet.Speed = Random.Range(25, 70) * i;
                pet.SpecialAttack = Random.Range(25, 70) * i;
                pet.SpecialDefense = Random.Range(25, 70) * i;
                pet.Health = Random.Range(50, 100) * i;

                petDB.PetData.Add(pet);

                //Debug.Log("---" + i + "---");
                //Debug.Log(petDB.PetData[i - 1].Attack);
                //Debug.Log(petDB.PetData[i - 1].Defense);
                //Debug.Log(petDB.PetData[i - 1].Speed);
                //Debug.Log(petDB.PetData[i - 1].SpecialAttack);
                //Debug.Log(petDB.PetData[i - 1].SpecialDefense);
                //Debug.Log(petDB.PetData[i - 1].Health);
            }

            petDB.PetData[0].Level = 5;
            petDB.PetData[1].Level = 17;
            petDB.PetData[2].Level = 45;
        }

        void NavigateTo(string destination)
        {
            Application.LoadLevel(destination);
        }
    }
}