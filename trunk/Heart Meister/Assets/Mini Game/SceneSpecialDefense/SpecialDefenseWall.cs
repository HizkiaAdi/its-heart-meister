using UnityEngine;
using System.Collections;

public class SpecialDefenseWall : MonoBehaviour {

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
}
