using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class MiniGameMenu : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            //if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)) && click.collider != null)
            //{
            //    switch (click.collider.name)
            //    {
            //        case "AttackButton": Application.LoadLevel("AttackScene"); break;
            //        case "DefenseButton": Application.LoadLevel("DefenseScene"); break;
            //        case "SpeedButton": Application.LoadLevel("SpeedScene"); break;
            //        case "SpecialAttackButton": Application.LoadLevel("SpecialAttackScene"); break;
            //        case "SpecialDefenseButton": Application.LoadLevel("SpecialDefenseScene"); break;
            //        case "HealthButton": Application.LoadLevel("HealthScene"); break;
            //        case "HomeButton": Application.LoadLevel("Home"); break;
            //    }
            //}
        }

        void NavigateTo(string target)
        {
            Application.LoadLevel(target);
        }
    }
}