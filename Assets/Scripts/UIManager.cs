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

    public Button boostSpeedButton;

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

    private int score;


    void Start()
    {
        StartGame();
    }
    // Update is called once per frame
    void Update()
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
                    PauseGame();
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
                    PauseGame();
                    Debug.Log("Not pause");
                }
            }
        } 
    }

    public void StartGame()
    {
        checkPlaying = true;
    }

    public void PauseGame()
    {
        if (checkPause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
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
   
}
