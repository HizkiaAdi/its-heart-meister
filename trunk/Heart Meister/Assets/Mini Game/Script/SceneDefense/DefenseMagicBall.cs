using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class DefenseMagicBall : MonoBehaviour
    {

        void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}