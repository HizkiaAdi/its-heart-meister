using UnityEngine;
using System.Collections;

public class SpeedGameManager : MonoBehaviour {

    public GUIText completeText, failedText, chanceText, scoreText;
    public static int score, chance;
    bool isComplete, isGameOver;
    // Use this for initialization
    void Start()
    {
        completeText.enabled = false;
        failedText.enabled = false;
        score = 0;
        chance = 3;
        isComplete = false;
        isGameOver = false;

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

        if (chance > 0)
            chanceText.text = "Chance: " + chance.ToString();
        else chanceText.text = "Chance: 0";

        if (score == 10 || chance == 0)
        {
            isGameOver = true;
            GameEventManager.TriggerGameOver();
        }

        RaycastHit2D tapEnemy = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonUp(0) && tapEnemy.collider != null)
        {
            if (tapEnemy.collider.tag == "Enemy")
            {
                Destroy(tapEnemy.collider.gameObject);
                score++;
            }

            else if (tapEnemy.collider.tag == "OtherObject")
            {
                Destroy(tapEnemy.collider.gameObject);
                chance--;
            }
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
