using UnityEngine;
using System.Collections;
using MiniGameModel;

namespace MiniGame
{
    public class TrainingResult : MonoBehaviour
    {
        public GUIText attributText, pointText, pointPText, pointFText;
        int attackPoint, defensePoint, speedPoint, sAttackPoint, sDefensePoint, healthPoint;
        string attributName;

        TrainingPetAttributs attribut;
        // Use this for initialization
        void Awake()
        {
            attribut = TrainingPetAttributs.CreateTrainingAtributSingleton();
            attackPoint = attribut.Attack;
            defensePoint = attribut.Defense;
            speedPoint = attribut.Speed;
            sAttackPoint = attribut.SpecialAttack;
            sDefensePoint = attribut.SpecialDefense;
            healthPoint = attribut.Health;

            SetTextSize();
        }

        // Update is called once per frame
        void Update()
        {
            attributText.text = attributName;
            switch (attributName)
            {
                case "attack": SetAttack(); break;
                case "defense": SetDefense(); break;
                case "speed": SetSpeed(); break;
                case "special attack": SetSpecialAttack(); break;
                case "special defense": SetSpecialDefense(); break;
                case "health": SetHealth(); break;
            }

            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (click.collider != null && click.collider.tag == "TrainingResult")
                {
                    UpdateStatus();
                    Application.LoadLevel("PetOption");
                }
            }
        }

        void SetTextSize()
        {
            int size;
            size = Screen.height / 22;
            Debug.Log(size);

            attributText.fontSize = size;
            pointText.fontSize = size;
            pointPText.fontSize = size;
            pointFText.fontSize = size;
        }

        void UpdateStatus()
        {
            PetDB petDB = PetDB.CreatePetDB();
            petDB.PetData[petDB.Id].Attack = attribut.Attack;
            petDB.PetData[petDB.Id].Defense = attribut.Defense;
            petDB.PetData[petDB.Id].Speed = attribut.Speed;
            petDB.PetData[petDB.Id].SpecialAttack = attribut.SpecialAttack;
            petDB.PetData[petDB.Id].SpecialDefense = attribut.SpecialDefense;
            petDB.PetData[petDB.Id].Health = attribut.Health;
        }

        void SetAttribut(string param)
        {
            attributName = param;
        }

        void SetAttack()
        {
            pointText.text = attackPoint.ToString();
            pointPText.text = "+" + (attribut.Attack-attackPoint).ToString();
            pointFText.text = attribut.Attack.ToString();
        }

        void SetDefense()
        {
            pointText.text = defensePoint.ToString();
            pointPText.text = "+" + (attribut.Defense-defensePoint).ToString();
            pointFText.text = attribut.Defense.ToString();
        }

        void SetSpeed()
        {
            pointText.text = speedPoint.ToString();
            pointPText.text = "+" + (attribut.Speed - speedPoint).ToString();
            pointFText.text = attribut.Speed.ToString();
        }

        void SetSpecialAttack()
        {
            pointText.text = sAttackPoint.ToString();
            pointPText.text = "+" + (attribut.SpecialAttack - sAttackPoint).ToString();
            pointFText.text = attribut.SpecialAttack.ToString();
        }

        void SetSpecialDefense()
        {
            pointText.text = sDefensePoint.ToString();
            pointPText.text = "+" + (attribut.SpecialDefense - sDefensePoint).ToString();
            pointFText.text = attribut.SpecialDefense.ToString();
        }

        void SetHealth()
        {
            pointText.text = healthPoint.ToString();
            pointPText.text = "+" + (attribut.Health - healthPoint).ToString();
            pointFText.text = attribut.Health.ToString();
        }
    }
}