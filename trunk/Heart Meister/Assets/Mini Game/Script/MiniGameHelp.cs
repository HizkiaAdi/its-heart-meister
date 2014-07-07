using UnityEngine;
using System.Collections;

namespace MiniGame
{
    public class MiniGameHelp : MonoBehaviour
    {
        public GameObject tutorial;
        public Sprite[] tutorialSkin;

        int index;
        // Use this for initialization
        void Start()
        {
            index = 0;
            SpriteRenderer renderer = tutorial.GetComponent<SpriteRenderer>();
            renderer.sprite = tutorialSkin[0];
        }

        // Update is called once per frame
        void Update()
        {

        }

        void ChangeTutorial()
        {
            SpriteRenderer renderer = tutorial.GetComponent<SpriteRenderer>();
            index = (index + 1) % 6;
            renderer.sprite = tutorialSkin[index];
        }

        void GoToMenu()
        {
            Application.LoadLevel("MiniGameMenu");
        }
    }
}