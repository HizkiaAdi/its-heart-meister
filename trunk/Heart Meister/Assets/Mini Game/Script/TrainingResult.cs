using UnityEngine;
using System.Collections;
using MiniGameModel;

namespace MiniGame
{
    public class TrainingResult : MonoBehaviour
    {
        public GUIText attack, defense, speed, sAttack, sDefense, health;
        public GUIText attackP, defenseP, speedP, sAttackP, sDefenseP, healthP;
        int attackPoint, defensePoint, speedPoint, sAttackPoint, sDefensePoint, healthPoint;
        int attackPointP, defensePointP, speedPointP, sAttackPointP, sDefensePointP, healthPointP;

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
            /*
            Debug.Log("attack: " + attribut.Attack);
            Debug.Log("defense: " + attribut.Defense);
            Debug.Log("speed: " + attribut.Speed);
            Debug.Log("s.attack: " + attribut.SpecialAttack);
            Debug.Log("s.defense: " + attribut.SpecialDefense);
            Debug.Log("health: " + attribut.Health);*/

            //Debug.Log("defense: " + defensePoint);
        }

        // Update is called once per frame
        void Update()
        {
            SetFinalPoint();
            SetResultPoint();
            SetResultText();

            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (click.collider != null && click.collider.tag == "TrainingResult")
                {
                    Application.LoadLevel("Home");
                }
            }
        }

        void SetFinalPoint()
        {
            attack.text = attribut.Attack.ToString();
            defense.text = attribut.Defense.ToString();
            speed.text = attribut.Speed.ToString();
            sAttack.text = attribut.SpecialAttack.ToString();
            sDefense.text = attribut.SpecialDefense.ToString();
            health.text = attribut.Health.ToString();
        }

        void SetResultPoint()
        {
            attackPointP = attribut.Attack - attackPoint;
            defensePointP = attribut.Defense - defensePoint;
            speedPointP = attribut.Speed - speedPoint;
            sAttackPointP = attribut.SpecialAttack - sAttackPoint;
            sDefensePointP = attribut.SpecialDefense - sDefensePoint;
            healthPointP = attribut.Health - healthPoint;

            //Debug.Log(attribut.Defense + " - " + defensePoint);
        }

        void SetResultText()
        {
            attackP.text = "+" + attackPointP.ToString();
            defenseP.text = "+" + defensePointP.ToString();
            speedP.text = "+" + speedPointP.ToString();
            sAttackP.text = "+" + sAttackPointP.ToString();
            sDefenseP.text = "+" + sDefensePointP.ToString();
            healthP.text = "+" + healthPointP.ToString();
        }
    }
}