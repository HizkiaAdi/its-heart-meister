using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

    public static int lives, points;
    // Use this for initialization
    void Start()
    {
        canShoot = 0;
        lives = 3;
        points = 0;
    }

    public float speed;

    // Update is called once per frame
    void Update()
    {
        canShoot++;
    }

    public GameObject bullet;
    public float bulletSpeed;
    int canShoot;

    void OnGUI()
    {
        float buttonSize = Screen.height / 9;

        if (GUI.RepeatButton(new Rect(5, Screen.height - buttonSize - 5, buttonSize, buttonSize), "<"))
        {
            if (transform.position.x > -(Screen.width / 2))
                transform.Translate(Vector2.right * -speed);
        }

        if (GUI.RepeatButton(new Rect(buttonSize + 10, Screen.height - buttonSize - 5, buttonSize, buttonSize), ">"))
        {
            if (transform.right.x < Screen.width / 2)
                transform.Translate(Vector2.right * speed);
        }

        if (GUI.Button(new Rect(Screen.width - buttonSize - 5, Screen.height - buttonSize - 5, buttonSize, buttonSize), "O") && canShoot >= 30)
        {
            canShoot = 0;
            Vector2 target;
            target.x = transform.position.x;
            target.y = transform.position.y + 1.2f;
            Instantiate(bullet, target, transform.rotation);
            //shoot.transform.LookAt(target);
            //shoot.rigidbody2D.AddForce(shoot.transform.forward * bulletSpeed);
        }
    }
}
