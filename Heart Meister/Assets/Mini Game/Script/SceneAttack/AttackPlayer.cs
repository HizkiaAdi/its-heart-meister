using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class AttackPlayer : MonoBehaviour
    {

        public static int lives, points;
        public GameObject bullet;
        public float bulletSpeed;
        int canShoot;
        float nextShoot, shootDelay;
        // Use this for initialization
        void Start()
        {
            nextShoot = 0;
            shootDelay = 0.5f;
            canShoot = 0;
            lives = 3;
            points = 0;
        }

        public float speed;

        // Update is called once per frame
        void Update()
        {
            nextShoot += Time.deltaTime;
        }

        void OnGUI()
        {
            float buttonSize = Screen.height / 9;

            if (GUI.RepeatButton(new Rect(5, Screen.height - buttonSize - 5, buttonSize, buttonSize), "<"))
            {
                if (transform.localPosition.x > -7.5f)
                    transform.Translate(Vector2.right * -speed);
            }

            if (GUI.RepeatButton(new Rect(buttonSize + 10, Screen.height - buttonSize - 5, buttonSize, buttonSize), ">"))
            {
                if (transform.localPosition.x < 7.5f)
                    transform.Translate(Vector2.right * speed);
            }

            if (GUI.Button(new Rect(Screen.width - buttonSize - 5, Screen.height - buttonSize - 5, buttonSize, buttonSize), "O") && nextShoot > shootDelay)
            {
                nextShoot = 0;
                Vector2 target;
                target.x = transform.position.x;
                target.y = transform.position.y + 1.2f;
                Instantiate(bullet, target, transform.rotation);
            }
        }
    }
}
