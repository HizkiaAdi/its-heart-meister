using UnityEngine;
using System.Collections;

public class HealthGameManager : MonoBehaviour {

    public GUIText completeText, failedText, scoreText;
    public static int score;
    bool isComplete, isGameOver;
    public static bool playerFall;

    // Use this for initialization
    void Start()
    {
        completeText.enabled = false;
        failedText.enabled = false;
        score = 0;
        isGameOver = false;
        isComplete = false;
        playerFall = false;

        GameEventManager.GameOver += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 10)
        {
            scoreText.text = score.ToString() + "/10";
        }
        else
        {
            scoreText.text = "10/10";
            isComplete = true;
        }

        if (score == 10 || playerFall)
        {
            isGameOver = true;
            GameEventManager.TriggerGameOver();
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
        if (isGameOver)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.height / 2 + 20, 40, 30), "OK"))
            {
                Application.LoadLevel("Home");
            }
        }
    }
}
