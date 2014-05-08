using UnityEngine;
using System.Collections;

public class SpecialAttackGameManager : MonoBehaviour {

    public GUIText progressText, timeText, completeText, failedText;
    public static int progress;
    int finishTime, restTime;
    bool isGameOver, isComplete;

    // Use this for initialization
    void Start()
    {
        isGameOver = isComplete = false;
        completeText.enabled = failedText.enabled = false;
        progress = 0;
        finishTime = (int)Time.time + 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            UpdateTime();
            progressText.text = "S. Attack: " + (progress * 100 / 30).ToString() + "%";
            if (progress >= 30)
            {
                progressText.text = "S. Attack: 100%";
                isComplete = true;
                GameOver();
            }
        }
    }

    void UpdateTime()
    {
        restTime = finishTime - (int)Time.time;
        if (restTime > 0)
        {
            timeText.text = restTime.ToString();
        }
        else
        {
            timeText.text = "0";
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
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
