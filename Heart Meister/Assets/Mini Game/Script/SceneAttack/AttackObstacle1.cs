using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class AttackObstacle1 : MonoBehaviour
    {

        float speed = 0.05f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.right * speed);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "Boundary" || collision.collider.tag == "OtherObject")
                speed *= -1;
        }
    }
}