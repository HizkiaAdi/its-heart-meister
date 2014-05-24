using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class HealthBirdSpawner : MonoBehaviour
    {
        public GameObject bird;
        float interval, delay;

        // Use this for initialization
        void Start()
        {
            delay = 0f;
            interval = 2.5f;
        }

        // Update is called once per frame
        void Update()
        {
            delay += Time.deltaTime;
            if(delay > interval)
            {
                Instantiate(bird, new Vector2(9f, Random.Range(-3f, 4f)), transform.rotation);
                interval = Random.Range(4f, 6f);
                delay = 0;
            }
        }
    }
}