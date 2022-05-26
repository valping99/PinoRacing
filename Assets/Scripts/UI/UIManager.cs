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
<<<<<<< HEAD
        if (checkPlaying)
        {
            //mainSceneUI.gameObject.SetActive(true);
            pauseUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(false);
            boostSpeedButton.gameObject.SetActive(false);
        }
        if (!checkRunning)
        {
            charColl.m_CurrentSpeed = 0;
            mainSceneUI.gameObject.SetActive(false);
        }


=======
        checkPlaying = true;
        pauseUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(false);
        boostSpeedButton.gameObject.SetActive(false);
>>>>>>> parent of 51497b6 (Merge pull request #13 from indigames/DatDiep)
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
        // double kphSpeed = charInput.m_CurrentSpeed * 3.6;
        // int currendSpeed = (int)kphSpeed;
        // kphText.text = currendSpeed + "";

<<<<<<< HEAD
        //Get kph speed
        double kphSpeed = charColl.m_CurrentSpeed * 3.6;
        int currendSpeed = (int)kphSpeed;
        kphText.text = currendSpeed + "";

        //Get score
=======
>>>>>>> parent of 51497b6 (Merge pull request #13 from indigames/DatDiep)
        score += scoreToAdd;
        scoreText.text = currentScore + " m";
        gameOverScoreText.text = currentScore + "m";
        if (currentScore >= toRankS)
        {
            rankText.text = "S-Rank";
            messageText.text = "Perfect";
        }
        else if(currentScore >= toRankA)
        {
            rankText.text = "A-Rank";
            messageText.text = "Awesome";
        }
        else if (currentScore >= toRankB)
        {
            rankText.text = "B-Rank";
            messageText.text = "Cool";
        }
        else if (currentScore >= toRankC)
        {
            rankText.text = "C-Rank";
            messageText.text = "Not bad";
        }
        else if (currentScore >= toRankD)
        {
            rankText.text = "D-Rank";
            messageText.text = "One more time";
        }
        else if (currentScore >= toRankE)
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
<<<<<<< HEAD
        //Get Item boost
        for (int i = 0; i < charColl.m_CurrentSpeed / 10; i++)
        {
            milkNumberText.text = i +"";
        }

        //Get crystal to unlock boost button
        crystalCollected = charColl.m_CurrentCrystal;
        if (crystalCollected >= 6)
=======
        milkNumberText.text = crystalCollected + "";
        if(crystalCollected >= 6)
>>>>>>> parent of 51497b6 (Merge pull request #13 from indigames/DatDiep)
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

<<<<<<< HEAD
    //Time to countdown
    public void CountDown()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            Debug.Log(timeValue);
        }
        else
        {
            timeValue = 0;
        }
        DisplayTimer(timeValue);
    }

    public void DisplayTimer(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            countdownTimer_Text.gameObject.SetActive(false);
            checkRunning = true;
            mainSceneUI.gameObject.SetActive(true);
            charColl.m_CurrentSpeed += Speed;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //countdownTimer_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);\
        countdownTimer_Text.text = seconds+"";
    }
=======
>>>>>>> parent of 51497b6 (Merge pull request #13 from indigames/DatDiep)


   
}
