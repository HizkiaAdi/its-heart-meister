using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpeedEnemySpawner : MonoBehaviour
    {

        public GameObject[] enemy;
        float spawnDelay = 1.5f;
        float nextSpawn = 0f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnDelay;
                int maxSpawn = Random.Range(1, 5);
                for (int i = 0; i < maxSpawn; i++)
                {
                    int rand = Random.Range(0, 7);
                    if (rand != 5)
                        Instantiate(enemy[0], new Vector2(transform.position.x, transform.position.y + Random.Range(-3f, 3f)), transform.rotation);
                    else Instantiate(enemy[1], new Vector2(transform.position.x, transform.position.y + Random.Range(-3f, 3f)), transform.rotation);
                }
            }
        }
    }
}