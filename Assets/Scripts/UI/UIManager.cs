using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    #region UIVariables
    // Start is called before the first frame update

    [Header("Set Object player")]
    public CharacterInputController charInput;
    public CharacterCollider charColl;
    public ObstaclesManager obstacles;
    // Get player for get Speed;
    public GameObject m_Player;


    [Header("Player Variables")]
    public float currentScore;
    public float currentSpeed;
    public float currentMilk;
    public float currentStamina;
    public int crystalCollected;
    public float healthDown;
    public static int pinoSelected;

    //Check to active UI & button;
    [Header("Check active")]
    public bool checkPause;
    public bool checkGameOver;
    public bool checkGameClear;
    public bool checkPlaying;
    public bool checkBoost;
    public bool checkRunning = false;

    [Header("Object UI")]
    //Get UI to Active
    public GameObject mainSceneUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject gameClearUI;

    [Header("PlayingUI")]
    //UI Gameplaying
    public Slider healthPoint;
    public GameObject boostSpeedGObj;
    public GameObject isBoosting;
    public GameObject lockSpeedGObj;
    public Button boostSpeedButton;
    public Button LockBoostButton;
    public Button pauseButton;
    private float timeValue = 5;
    private float timeValueCountdown = 300;
    public float timeValueUp = 0;
    public float maxTimeValue = 300;


    [Header("Button")]
    //GameOverUI
    public Button shareScoreButton;
    public Button gameOverMainMenuButton;
    //PauseUI
    public Button resumeButton;
    public Button mainMenuButton;


    [Header("TextMesh")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI kphText;
    public TextMeshProUGUI milkNumberText;
    public TextMeshProUGUI countdownTimer_Text;
    public TextMeshProUGUI limitedTimer_Text;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI rankText;
    public TextMeshProUGUI messageText;

    //Set rank
    [Header("Set Rank (Seconds)")]
    public float toRankS;
    public float toRankA;
    public float toRankB;
    public float toRankC;
    public float toRankD;
    public float toRankE;
    public float toRankF;

    private HiresScreenShots screenShot;
    private int score;
    #endregion

    //Game Start
    void Start()
    {
        checkPlaying = true;
        StartGame();
        StartStatusOfPino();
        screenShot = FindObjectOfType<HiresScreenShots>();
        obstacles = FindObjectOfType<ObstaclesManager>();
    }

 
    void Update()
    {
        if (!checkRunning)
        {
            CountDown();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        UpdateScore(0);
        BoostSpeed();
        //HealthUpdate();
        TimeOut();
    }


    #region UIManager
    //Active when game start
    private void StartGame()
    {
        if (checkPlaying)
        {
            //mainSceneUI.gameObject.SetActive(true);
            pauseUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(false);
            boostSpeedButton.gameObject.SetActive(false);
            gameClearUI.gameObject.SetActive(false);
        }
        if (!checkRunning)
        {
            charColl.m_CurrentSpeed = 0;
            mainSceneUI.gameObject.SetActive(false);
        }

    }


    //Set Variables when game start
    private void StartStatusOfPino()
    {
        healthPoint.maxValue = charColl.m_InitialStamina;
        healthPoint.value = healthPoint.maxValue;

        healthDown -= charColl.m_InitialDef;
        charColl.m_CurrentStamina = (int) healthPoint.value;
    }



    //Active PauseUI
    public void PauseGame()
    {
        if (checkPlaying)
        {
            if (!checkPause)
            {
                //Enable PauseUI and disable other UI
                pauseUI.gameObject.SetActive(true);
                mainSceneUI.gameObject.SetActive(false);
                gameOverUI.gameObject.SetActive(false);
                countdownTimer_Text.gameObject.SetActive(false);
                checkPause = !checkPause;
                Time.timeScale = 0f;
                Debug.Log("Pause");
            }
            else
            {
                //Disable PauseUI and enable other UI
                pauseUI.gameObject.SetActive(false);
                mainSceneUI.gameObject.SetActive(true);
                gameOverUI.gameObject.SetActive(false);
                checkPause = !checkPause;
                Time.timeScale = 1f;
                if (!checkRunning)
                {
                    countdownTimer_Text.gameObject.SetActive(true);
                }
                Debug.Log("Resume");
            }
        }
        
    }

    

    //Active GameOverUI
    private void GameOver()
    {
        if (checkPlaying && !checkPause)
        {
            if (checkGameOver)
            {
                //Enable GameOver UI & Disable other UI
                gameOverUI.gameObject.SetActive(true);
                pauseUI.gameObject.SetActive(false);
                mainSceneUI.gameObject.SetActive(false);
                gameClearUI.gameObject.SetActive(false);
                screenShot.checkUI();

                Time.timeScale = 0f;
            }
            else
            {
                //Disable GameOver UI & Enable other UI
                gameOverUI.gameObject.SetActive(false);
                pauseUI.gameObject.SetActive(false);
                gameClearUI.gameObject.SetActive(false);
                mainSceneUI.gameObject.SetActive(true);
                Time.timeScale = 1f;
            }
        }
    }
    //private void GameClear()
    //{
    //    if (checkPlaying && !checkPause)
    //    {
    //        if (checkGameClear)
    //        {
    //            //Enable GameOver UI & Disable other UI
    //            gameOverUI.gameObject.SetActive(false);
    //            pauseUI.gameObject.SetActive(false);
    //            mainSceneUI.gameObject.SetActive(false);
    //            gameClearUI.gameObject.SetActive(true);
    //            screenShot.checkUI();
    //            Time.timeScale = 0f;
    //        }
    //        else
    //        {
    //            gameOverUI.gameObject.SetActive(false);
    //            pauseUI.gameObject.SetActive(false);
    //            gameClearUI.gameObject.SetActive(false);
    //            mainSceneUI.gameObject.SetActive(true);
    //            Time.timeScale = 1f;
    //        }
    //    }
    //}


    //Return to GameStart Scene
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //Update Score, speed, item...
    public void UpdateScore(int scoreToAdd)
    {
        //Get currentSpeed pino
        currentSpeed = charColl.m_CurrentSpeed;
        //Get score & convert float to int
        currentScore = m_Player.transform.position.z;
        currentScore = Mathf.FloorToInt(currentScore);
        //TimeCountUp
        TimeUp();
        //Get kph speed
        double kphSpeed = charColl.m_CurrentSpeed * 3.6;
        int currendSpeed = (int)kphSpeed;
        kphText.text = currendSpeed + "";

        //Get score
        score += scoreToAdd;
        scoreText.text = currentScore + " m";
        gameOverScoreText.text = currentScore + "m";

        /**
        //Set rank
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
        **/
    }


    //Set HP Decrease 
    public void HealthUpdate()
    {
        if (checkRunning)
        {
            //CountDownMinutes();

            //HP decrease by time & initial def
            //charColl.m_CurrentStamina = (int) currentStamina;

            charColl.m_CurrentStamina -= healthDown * Time.deltaTime;
            currentStamina = charColl.m_CurrentStamina;
            healthPoint.value = currentStamina;
            if(charColl.m_CurrentStamina >= healthPoint.maxValue)
            {
                charColl.m_CurrentStamina = healthPoint.maxValue;
            }
            if (currentStamina > healthPoint.maxValue)
            {
                currentStamina = healthPoint.maxValue;
                healthPoint.value = healthPoint.maxValue;
            }
            if (healthPoint.value <= 0)
            {
                healthPoint.value = 0;
                checkGameOver = true;
                GameOver();
            }
        }
    }




    //BoostSpeed
    public void BoostSpeed()
    {
        currentMilk = charColl.m_CurrentBottleMilk;
        milkNumberText.text = currentMilk + "";
        IsBoostingSpeed();
        //Get crystal to unlock boost button
        crystalCollected = charColl.m_CurrentCrystal;
        if (charColl.m_IsEnoughBoost == true)
        {
            //crystalCollected = 6;
            checkBoost = true;
        }
        else if(charColl.m_IsEnoughBoost == false)
        {
            //crystalCollected = 0;
            checkBoost = false;
        }

        //Check Unlock Button
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

    //Time to countdown
    public void CountDown()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            charColl.m_CurrentSpeed = 0;
            charInput.GetComponent<CharacterInputController>().enabled = false;
            //obstacles.GetComponent<ObstaclesManager>().enabled = false;
        }
        else
        {
            timeValue = 0;
        }
        DisplayTimer(timeValue);
    }

    //DisplayTimer
    public void DisplayTimer(float timeToDisplay)
    {
        if(timeToDisplay == 1)
        {
            countdownTimer_Text.text = "GO";
        }
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            countdownTimer_Text.gameObject.SetActive(false);
            checkRunning = true;
            mainSceneUI.gameObject.SetActive(true);
            obstacles.StartSpawnObjects();
            charInput.GetComponent<CharacterInputController>().enabled = true;
            //obstacles.GetComponent<ObstaclesManager>().enabled = true;
            charColl.m_CurrentSpeed += charColl.m_InitialSpeed;
        }
        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        //countdownTimer_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);\
        countdownTimer_Text.text = seconds+"";
    }

    /**
    //TimeOver
    public void CountDownMinutes()
    {
        if (timeValueCountdown > 0)
        {
            timeValueCountdown -= Time.deltaTime;
        }
        else
        {
            timeValueCountdown = 0;
        }
        DisplayTimerCountDown(timeValueCountdown);
    }

    //Display TimeOver
    public void DisplayTimerCountDown(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            GameOver();
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        limitedTimer_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    **/
    //TimeCountUp
    private void TimeUp()
    {
        if (timeValueUp < maxTimeValue)
        {
            timeValueUp += Time.deltaTime;
            
        }
        else
        {
            checkGameClear = true;
        }
        DisplayTimerCountUp(timeValueUp);
    }

    private void TimeOut()
    {
        if (checkGameClear)
        {
            gameClearUI.gameObject.SetActive(true);
            gameOverUI.gameObject.SetActive(false);
            pauseUI.gameObject.SetActive(false);
            mainSceneUI.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            gameClearUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(false);
            pauseUI.gameObject.SetActive(false);
            mainSceneUI.gameObject.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    public void DisplayTimerCountUp(float timeToDisplayCountUp)
    {
        if (timeToDisplayCountUp == maxTimeValue)
        {
            timeToDisplayCountUp = 0;
            //GameOver();
        }
        float minutes = Mathf.FloorToInt(timeToDisplayCountUp / 60);
        float seconds = Mathf.FloorToInt(timeToDisplayCountUp % 60);
        float milliSeconds = (timeToDisplayCountUp % 1) * 1000;

        limitedTimer_Text.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds,milliSeconds);
    }

    void IsBoostingSpeed()
    {
        if (charInput.m_IsBoosting)
        {
            isBoosting.gameObject.SetActive(true);
            boostSpeedGObj.gameObject.SetActive(false);
        }
        else
        {
            isBoosting.gameObject.SetActive(false);
            boostSpeedGObj.gameObject.SetActive(true);
        }
    }



    #endregion
}
