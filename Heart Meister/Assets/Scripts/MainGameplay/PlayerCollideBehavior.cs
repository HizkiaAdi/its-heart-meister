using UnityEngine;
using System.Collections;
namespace MainGameplay
{

    public class PlayerCollideBehavior : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter2D(Collider2D cd)
        {
            Debug.Log("TEAM");
            DungeonTraversingEX.collideFlag = true;
            Collider2D c2d = cd.GetComponent<Collider2D>();
            c2d.enabled = false;
        }
    }
}
