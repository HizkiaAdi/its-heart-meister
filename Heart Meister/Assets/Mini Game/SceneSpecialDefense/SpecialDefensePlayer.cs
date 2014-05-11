using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpecialDefensePlayer : MonoBehaviour
    {

        public GameObject shield;
        float buttonSize = Screen.height / 9f;
        float speed = 0.1f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

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

        void OnGUI()
        {
            if (GUI.RepeatButton(new Rect(5, Screen.height - 2 * buttonSize - 5, buttonSize, buttonSize), "^"))
            {
                if (transform.position.y < 3.5f)
                    transform.Translate(Vector2.up * speed);
            }

            if (GUI.RepeatButton(new Rect(5, Screen.height - buttonSize, buttonSize, buttonSize), "v"))
            {
                if (transform.position.y > -3.5f)
                    transform.Translate(Vector2.up * -speed);
            }

            if (GUI.Button(new Rect(Screen.width - buttonSize - 5, Screen.height - buttonSize - 5, buttonSize, buttonSize), "O"))
            {
                if (SpecialDefenseGameManager.specialDefense > 0)
                {
                    Instantiate(shield, new Vector2(transform.position.x + 1.5f, 0), transform.rotation);
                    SpecialDefenseGameManager.specialDefense--;
                }
            }
        }
    }
}