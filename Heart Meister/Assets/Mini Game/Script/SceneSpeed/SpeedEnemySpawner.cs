using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpeedEnemySpawner : MonoBehaviour
    {

        GameObject enemy;
        float spawnDelay = 1.5f;
        float nextSpawn = 0f;

        // Use this for initialization
        void Start()
        {
            enemy = Resources.Load("MiniGamePrefabs/SpeedEnemy") as GameObject;
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnDelay;
                int maxSpawn = Random.Range(1, 4);

                for (int i = 0; i < maxSpawn; i++)
                {
                    Instantiate(enemy, new Vector2(transform.position.x, transform.position.y + Random.Range(-3f, 3f)), transform.rotation);
                }
            }
        }
    }
}