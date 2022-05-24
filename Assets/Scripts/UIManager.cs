using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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


    void Start()
    {
        StartGame();
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore(0);
        
    }


    public void StartGame()
    {
        checkPlaying = true;
    }

    public void PauseGame()
    {
        if (checkPlaying)
        {
            if (!checkPause)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseUI.gameObject.SetActive(true);
                    mainSceneUI.gameObject.SetActive(false);
                    checkPause = !checkPause;
                    Time.timeScale = 0f;
                    Debug.Log("Pause");
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    pauseUI.gameObject.SetActive(false);
                    mainSceneUI.gameObject.SetActive(true);
                    checkPause = !checkPause;
                    Time.timeScale = 1f;
                    Debug.Log("Not pause");
                }
            }
        }
    }

    public void GameOver()
    {
        if (checkGameOver)
        {
            gameOverUI.gameObject.SetActive(true);
            pauseUI.gameObject.SetActive(false);
            mainSceneUI.gameObject.SetActive(false);
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
    }

    public void HealthUpdate()
    {
        if(healthPoint)
        {

        }
    }
   
}
