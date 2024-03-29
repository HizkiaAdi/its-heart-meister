﻿using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class SpeedEnemy : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector2(transform.position.x - 0.08f, transform.position.y + Random.Range(-0.1f, 0.1f));
        }

        void OnCollisionEnter2D(Collision2D collider)
        {
            if (collider.collider.tag == "Boundary")
            {
                SpeedGameManager.chance--;
                Destroy(gameObject);
            }
        }
    }
}