using UnityEngine;
using System.Collections;

public class HealthPlayer : MonoBehaviour {

    bool onGround;
    // Use this for initialization
    void Start()
    {
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)) && onGround)
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(new Vector2(0, 300f));
            onGround = false;
        }

        if (transform.localPosition.y < -5.5f)
        {
            HealthGameManager.playerFall = true;
        }
    }

    void OnCollisionEnter2D()
    {
        onGround = true;
    }
}
