using UnityEngine;
using System.Collections;

public class HealthGround : MonoBehaviour {

    public float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed);

        if (transform.localPosition.x < -11f)
        {
            Destroy(gameObject);
        }
    }
}
