using UnityEngine;
using System.Collections;
namespace MainGameplay
{

    public class ScreenTransitionManager : MonoBehaviour
    {
        public LoaderBehavior lb;
        public static string targetName;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }

        void GoLoader(string target)
        {
            targetName = target;
            Application.LoadLevel("LoadScreen");
        }
    }
}