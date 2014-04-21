using UnityEngine;
using System.Collections;

public class SpeedOtherObject : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - 0.08f, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
