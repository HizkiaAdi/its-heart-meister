using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector2.right * speed);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Boundary" || collider.tag=="Shoot")
        {
            Destroy(gameObject);
        }
    }
}
