using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpeedOtherObjectSpawner : MonoBehaviour
    {
        GameObject otherObject;
        float spawnDelay = 2.0f;
        float nextSpawn = 0f;

        // Use this for initialization
        void Start()
        {
            otherObject = Resources.Load("MiniGamePrefabs/SpeedOtherObject") as GameObject;
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
                    Instantiate(otherObject, new Vector2(transform.position.x, transform.position.y + Random.Range(-3f, 3f)), transform.rotation);
                }
            }
        }
    }
}