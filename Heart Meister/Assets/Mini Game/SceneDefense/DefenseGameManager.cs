using UnityEngine;
using System.Collections;

public class DefenseGameManager : MonoBehaviour {

    public GUIText completeText, failedText;
    public static bool isGameOver, isComplete;
    // Use this for initialization
    void Start()
    {
        isGameOver = false;
        isComplete = false;
        completeText.enabled = false;
        failedText.enabled = false;

        //GameEventManager.GameOver += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            GameOver();
            //GameEventManager.TriggerGameOver();
        }
    }

    void GameOver()
    {
        if (isComplete)
        {
            completeText.enabled = true;
        }
        else
        {
            failedText.enabled = true;
        }

    }

    void OnGUI()
    {
        float buttonSize = Screen.height / 10;
        if (isGameOver)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - buttonSize / 2, Screen.height / 2, buttonSize, buttonSize), "OK"))
            {
                Application.LoadLevel("Home");
            }
        }
    }
}
