using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class DefensePlayer : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                transform.position = new Vector2(transform.position.x + 0.15f, transform.position.y);
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Shoot")
            {
                transform.position = new Vector2(transform.position.x - 0.4f, transform.position.y);
            }

            if (collider.tag == "Enemy")
            {
                DefenseGameManager.isComplete = true;
                DefenseGameManager.isGameOver = true;
            }

            if (collider.tag == "Boundary" || collider.tag == "Ball")
            {
                Destroy(gameObject);
                DefenseGameManager.isComplete = false;
                DefenseGameManager.isGameOver = true;
            }
        }
    }
}
