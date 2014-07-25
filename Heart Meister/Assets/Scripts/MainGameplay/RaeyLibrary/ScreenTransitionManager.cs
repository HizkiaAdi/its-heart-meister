using UnityEngine;
using System.Collections;
namespace MainGameplay
{

    public class ScreenTransitionManager : MonoBehaviour
    {
        public static string targetName;
        float fadeSpeed = 2f;
        private bool sceneStarting = true;
        private bool sceneEnding = false;
        public GUITexture screenCover;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (sceneStarting)
            {
                StartScene();
            }
            if (sceneEnding)
            {
                FadeBlack();
                if (screenCover.color.a >= 0.99f)
                {
                    Application.LoadLevel("LoadScreen");
                }
            }
        }

        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
            screenCover.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
        }

        void OnLevelWasLoaded(int level)
        {
            if (level != 0)
            {
                sceneStarting = true;
                sceneEnding = false;
            }
        }

        void FadeClear()
        {
            screenCover.color = Color.Lerp(screenCover.color, Color.clear, fadeSpeed * Time.deltaTime);
        }

        void FadeBlack()
        {
            screenCover.enabled = true;
            screenCover.color = Color.Lerp(screenCover.color, Color.black, fadeSpeed * Time.deltaTime);
        }

        void StartScene()
        {
            FadeClear();
            if (screenCover.color.a <= 0.01f)
            {
                screenCover.color = Color.clear;
                screenCover.enabled = false;
                sceneStarting = false;
                ButtonScript.buttonsEnabled = true;
                ButtonSript.buttonsEnabled = true;
            }
        }

        void EndScene(string target)
        {
            targetName = target;
            sceneEnding = true;
            ButtonScript.buttonsEnabled = false;
            ButtonSript.buttonsEnabled = false;
        }
    }
}