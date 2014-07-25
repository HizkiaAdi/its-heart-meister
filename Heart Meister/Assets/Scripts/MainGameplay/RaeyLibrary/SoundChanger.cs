using UnityEngine;
using System.Collections;

public class SoundChanger : MonoBehaviour
{

    public AudioClip NewMusic;

    void Awake()
    {
        GameObject go = GameObject.Find("RaeySoundManager");
        go.audio.clip = NewMusic;
        go.audio.Play();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
