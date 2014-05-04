using UnityEngine;
using System.Collections;

public class SpecialDefenseShield : MonoBehaviour {

    float interval = 3f;
    float delay;
    // Use this for initialization
    void Start()
    {
        delay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        delay += Time.deltaTime;
        if (delay > interval)
        {
            Destroy(gameObject);
            delay = 0;
        }
    }
}
