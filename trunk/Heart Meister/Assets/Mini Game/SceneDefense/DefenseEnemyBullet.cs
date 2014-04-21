using UnityEngine;
using System.Collections;

public class DefenseEnemyBullet : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
    }
}
