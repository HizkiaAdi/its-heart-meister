using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpecialDefenseObstacle : MonoBehaviour
    {
        float speed = 0.05f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.up * speed);

            if (transform.localPosition.y > 3f || transform.localPosition.y < -3)
                speed *= -1;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.rigidbody2D != null)
            {
                float velocity = collision.gameObject.rigidbody2D.velocity.magnitude;
                collision.gameObject.rigidbody2D.velocity = new Vector2(collision.gameObject.rigidbody2D.velocity.x, (collision.transform.position.y - transform.position.y) * 4);

                if (collision.gameObject.rigidbody2D.velocity.magnitude < velocity)
                {
                    collision.gameObject.rigidbody2D.velocity *= velocity / collision.gameObject.rigidbody2D.velocity.magnitude;
                }
            }
        }
    }
}