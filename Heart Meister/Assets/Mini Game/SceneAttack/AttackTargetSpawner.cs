using UnityEngine;
using System.Collections;

public class AttackTargetSpawner : MonoBehaviour {

    public float spawnTime, spawnDelay;
    public GameObject[] target;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        int rand = Random.Range(0, 6);
        if (rand != 5)
            Instantiate(target[0], transform.position, transform.rotation);
        else Instantiate(target[1], transform.position, transform.rotation);
    }
}
