using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool checkPause;
    public bool checkGameOver;
    public bool checkPlaying;

    public GameObject mainSceneUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;

    public Slider healthPoint;
    public Button boostSpeedButton;
    public Button pauseButton;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI kphText;
    public TextMeshProUGUI milkNumberText;

    public Button resumeButton;
    public Button mainMenuButton;

    public Button shareScoreButton;
    public Button gameOverMainMenuButton;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI messageText;

    public int score;

    public float toRankS;
    public float toRankA;
    public float toRankB;
    public float toRankC;
    public float toRankD;
    public float toRankE;
    public float toRankF;


    void Start()
    {
        StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        UpdateScore(0);
        HealthUpdate();
        
    }


    public void StartGame()
    {
        checkPlaying = true;
        pauseUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        if (checkPlaying)
        {
            if (!checkPause)
            {
                pauseUI.gameObject.SetActive(true);
                mainSceneUI.gameObject.SetActive(false);
                gameOverUI.gameObject.SetActive(false);
                checkPause = !checkPause;
                Time.timeScale = 0f;
                Debug.Log("Pause");
            }
            else
            {
                pauseUI.gameObject.SetActive(false);
                mainSceneUI.gameObject.SetActive(true);
                gameOverUI.gameObject.SetActive(false);
                checkPause = !checkPause;
                Time.timeScale = 1f;
                Debug.Log("Not pause");
            }
        }
        
    }

    
    public void GameOver()
    {
        if (checkPlaying && !checkPause)
        {
            if (checkGameOver)
            {
                gameOverUI.gameObject.SetActive(true);
                pauseUI.gameObject.SetActive(false);
                mainSceneUI.gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
            else
            {
                gameOverUI.gameObject.SetActive(false);
                pauseUI.gameObject.SetActive(false);
                mainSceneUI.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score + " m";
        gameOverScoreText.text = score + "m";
        if(score >= toRankS)
        {
            rankText.text = "S-Rank";
            messageText.text = "Perfect";
        }
        else if(score >= toRankA)
        {
            rankText.text = "A-Rank";
            messageText.text = "Awesome";
        }
        else if (score >= toRankB)
        {
            rankText.text = "B-Rank";
            messageText.text = "Cool";
        }
        else if (score >= toRankC)
        {
            rankText.text = "C-Rank";
            messageText.text = "Not bad";
        }
        else if (score >= toRankD)
        {
            rankText.text = "D-Rank";
            messageText.text = "One more time";
        }
        else if (score >= toRankE)
        {
            rankText.text = "E-Rank";
            messageText.text = "Try again";
        }
        else
        {
            rankText.text = "F-Rank";
            messageText.text = "Never give up";
        }
    }

    public void HealthUpdate()
    {
        if(healthPoint.value <= 0)
        {
            checkGameOver = true;
            GameOver();
        }
    }


   
}
