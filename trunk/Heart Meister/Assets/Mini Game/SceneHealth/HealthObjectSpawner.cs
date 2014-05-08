﻿using UnityEngine;
using System.Collections;

public class HealthObjectSpawner : MonoBehaviour {

    public GameObject ground, health;
    float interval;
    float delay, previousY, nextY;
    // Use this for initialization
    void Start()
    {
        delay = 0.8f;
        previousY = -4.5f;
        interval = 1.0f;
        Instantiate(ground, new Vector2(-5.8f, -4.5f), transform.rotation);
        Instantiate(ground, new Vector2(2.5f, -4.5f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (delay > interval)
        {
            nextY = Random.Range(previousY - 2f, previousY + 2f);
            if (nextY < -4.5f)
                nextY = -4.5f;
            if (nextY > 2f)
                nextY = 2f;

            SpawnGround(transform.position.x, nextY);
            SpawnHealth(transform.position.x, nextY + 2.5f);

            interval = Random.Range(1.0f, 2.0f);
        }
    }

    void SpawnGround(float x, float y)
    {
        Instantiate(ground, new Vector2(x, y), transform.rotation);
        previousY = nextY;
        delay = 0;
    }

    void SpawnHealth(float x, float y)
    {
        int rand = Random.Range(0, 3);
        if (rand == 2)
            Instantiate(health, new Vector2(x, y), transform.rotation);
    }
}