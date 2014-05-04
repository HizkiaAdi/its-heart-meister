using UnityEngine;
using System.Collections;

public class SpecialDefenseBall : MonoBehaviour {

    float speed = 5.0f;
    // Use this for initialization
    void Start()
    {
        //ResetPosition();
        rigidbody2D.AddForce(new Vector2(-50, Random.Range(-10, 10)) * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < -8)
        {
            Destroy(gameObject);
        }

        if (transform.localPosition.x > 8)
        {
            Destroy(gameObject);
        }
    }
}
