using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpecialDefenseEnemy : MonoBehaviour
    {

        float speed;
        Transform ball;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Move(transform.position.x, transform.position.y);
        }

        void Move(float x, float y)
        {
            if (GameObject.FindWithTag("Ball"))
            {
                ball = GameObject.FindWithTag("Ball").transform;

                if (ball.position.x > 0)
                {
                    speed = Random.Range(0.01f, 0.1f);

                    if (y < ball.position.y)
                        transform.position = new Vector2(x, y + speed);
                    if (y > ball.position.y)
                        transform.position = new Vector2(x, y - speed);
                }
            }
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