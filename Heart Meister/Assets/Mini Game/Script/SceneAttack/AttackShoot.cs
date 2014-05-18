using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class AttackShoot : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //transform.Translate(Vector2.up * 0.2f);
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.15f);
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "BlackHole")
            {
                transform.position = new Vector2(Random.Range(-5f, 5f), transform.position.y + 1f);
            }

            else
            {
                if (collider.tag == "Enemy")
                {
                    AttackPlayer.points++;
                }

                if (collider.tag == "OtherObject")
                {
                    AttackPlayer.lives--;
                }

                Destroy(gameObject);
            }
        }
    }
}
