using UnityEngine;
using System.Collections;
using MiniGameModel;

namespace MiniGame
{
    public class DefensePlayer : MonoBehaviour
    {
        public static float startPos, maxPos;

        void Start()
        {
            startPos = maxPos = transform.localPosition.x;
        }

        void Update()
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                transform.Translate(Vector2.right * 0.15f);

                if(transform.localPosition.x>maxPos)
                {
                    maxPos = transform.localPosition.x;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "Shoot")
            {
                transform.Translate(Vector2.right * -0.4f);
            }

            if (collider.tag == "Enemy")
            {
                Rigidbody2D enemy = collider.GetComponent<Rigidbody2D>();
                enemy.AddForce(new Vector2(100, 100) * 0.8f);
                DefenseGameManager.isGameOver = true;
            }

            if (collider.tag == "Boundary" || collider.tag == "Ball")
            {
                Destroy(gameObject);
                DefenseGameManager.isGameOver = true;
            }
        }
    }
}
