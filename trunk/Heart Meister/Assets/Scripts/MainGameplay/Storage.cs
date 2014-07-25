using UnityEngine;
using System.Collections;
namespace MainGameplay
{
    public class Storage : MonoBehaviour
    {
        public static int playerPosition = 0;

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}