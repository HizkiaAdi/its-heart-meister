using UnityEngine;
using System.Collections;
namespace MainGameplay
{

    public class PlayerCollideBehavior : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D cd)
        {
            //Debug.Log("TEAM");
            DungeonTraversingEX.collideFlag = true;
            Collider2D c2d = cd.GetComponent<Collider2D>();
            c2d.enabled = false;
            StartCoroutine(Reviver(c2d));
        }

        IEnumerator Reviver(Collider2D c2d)
        {
            yield return new WaitForSeconds(2);
            c2d.enabled = true;
        }
    }
}
