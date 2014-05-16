using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class DefensePlayer : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            float buttonSize = Screen.height / 9;

            if (GUI.Button(new Rect(Screen.width / 2 - buttonSize / 2, Screen.height - buttonSize - 5, buttonSize, buttonSize), ">"))
            {
                transform.position = new Vector2(transform.position.x + 0.25f, transform.position.y);
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Shoot")
            {
                transform.position = new Vector2(transform.position.x - 0.35f, transform.position.y);
            }

            if (collider.tag == "Enemy")
            {
                DefenseGameManager.isComplete = true;
                DefenseGameManager.isGameOver = true;
            }

            if (collider.tag == "Boundary")
            {
                DefenseGameManager.isComplete = false;
                DefenseGameManager.isGameOver = true;
            }
        }
    }
}
