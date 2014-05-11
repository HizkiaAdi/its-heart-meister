using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class DefenseEnemy : MonoBehaviour
    {

        public GameObject bullet;
        float shootDelay = 1.5f;
        float nextShoot = 0f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > nextShoot)
            {
                nextShoot = Time.time + shootDelay;
                Instantiate(bullet, new Vector2(transform.position.x - 1.1f, transform.position.y), transform.rotation);
            }
        }
    }
}
