using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpecialAttackMagic : MonoBehaviour
    {

        Vector3 maxScale;
        // Use this for initialization
        void Start()
        {
            maxScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.localScale.x < maxScale.x)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.01f, transform.localScale.y + 0.01f, transform.localScale.z);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == "OtherObject")
            {
                Destroy(collision.collider.gameObject);
                Destroy(gameObject);
            }
        }
    }
}