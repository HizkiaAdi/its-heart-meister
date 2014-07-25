using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public float currVolume;

    private static SoundManager instance;

    public static SoundManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void BGMChanger(string newBGM)
    {

    }
}
