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
    public CharacterInputController charInput;
    public CharacterCollider charColl;
    

    public bool checkPause;
    public bool checkGameOver;
    public bool checkPlaying;
    public bool checkBoost;

    public GameObject m_Player;

    public GameObject mainSceneUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;

    public Slider healthPoint;
    public GameObject boostSpeedGObj;
    public Button boostSpeedButton;
    public GameObject lockSpeedGObj;
    public Button LockBoostButton;
    public Button pauseButton;

    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI kphText;
    public TextMeshProUGUI milkNumberText;
    
    //Pause
    public Button resumeButton;
    public Button mainMenuButton;

    //UI GameOver
    public Button shareScoreButton;
    public Button gameOverMainMenuButton;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI messageText;

    //UI Playing
    public int score;
    public float currentScore;
    public float currentSpeed;
    public int crystalCollected;
    public double speedRun;
    public float healthDown;
    //Set rank
    public float toRankS;
    public float toRankA;
    public float toRankB;
    public float toRankC;
    public float toRankD;
    public float toRankE;
    public float toRankF;


    void Start()
    {
        checkPlaying = true;
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
        BoostSpeed();
        HealthUpdate();
        
    }


    public void StartGame()
    {
        if (checkPlaying)
        {
            mainSceneUI.gameObject.SetActive(true);
            pauseUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(false);
            boostSpeedButton.gameObject.SetActive(false);
        }
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
        currentScore = m_Player.transform.position.z;
        currentScore = Mathf.FloorToInt(currentScore);
        double kphSpeed = charInput.m_CurrentSpeed * 3.6;
        int currendSpeed = (int)kphSpeed;
        kphText.text = currendSpeed + "";


        score += scoreToAdd;
        scoreText.text = currentScore + " m";
        gameOverScoreText.text = currentScore + "m";
        if (currentScore >= toRankS)
        {
            rankText.text = "Rank S";
            messageText.text = "Perfect";
        }
        else if(currentScore >= toRankA)
        {
            rankText.text = "Rank A";
            messageText.text = "Awesome";
        }
        else if (currentScore >= toRankB)
        {
            rankText.text = "Rank B";
            messageText.text = "Cool";
        }
        else if (currentScore >= toRankC)
        {
            rankText.text = "Rank C";
            messageText.text = "Not bad";
        }
        else if (currentScore >= toRankD)
        {
            rankText.text = "Rank D";
            messageText.text = "One more time";
        }
        else if (currentScore >= toRankE)
        {
            rankText.text = "Rank E";
            messageText.text = "Try again";
        }
        else
        {
            rankText.text = "Rank F";
            messageText.text = "Never give up";
        }
    }

    public void HealthUpdate()
    {
        healthPoint.value -= healthDown * Time.deltaTime;
        if(healthPoint.value <= 0)
        {
            healthPoint.value = 0;
            checkGameOver = true;
            GameOver();
        }
    }

    public void BoostSpeed()
    {
        for (int i = 0; i < charInput.m_CurrentSpeed / 10; i++)
        {
            milkNumberText.text = i +"";
        }
        crystalCollected = charColl.m_CurrentCrystal;
        if (crystalCollected >= 6)
        {
            crystalCollected = 6;
            checkBoost = true;
        }
        else if(crystalCollected <=0)
        {
            crystalCollected = 0;
            checkBoost = false;
        }

        if(checkBoost)
        {
            boostSpeedGObj.gameObject.SetActive(true);
            lockSpeedGObj.gameObject.SetActive(false);
        }
        else
        {
            boostSpeedGObj.gameObject.SetActive(false);
            lockSpeedGObj.gameObject.SetActive(true);
        }
    }



   
}
