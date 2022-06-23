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
    public BoostCount b_count;
    private RankManager rankManagers;


    [Header("Player Variables")]
    public int boostCount = 16;
    public float currentScore;
    public float currentSpeed;
    public float currentMilk;
    public float currentStamina;
    public int crystalCollected;
    public static int pinoSelected;
    public float healthDown;

    //Check to active UI & button;
    [Header("Check active")]
    public bool checkPause;
    public bool checkGameOver;
    public bool checkGameClear;
    public bool checkPlaying;
    public bool checkBoost;
    public bool checkRunning = false;
    public bool checkDashBoost = false;
    private bool startScene = true;
    private bool checkCount = true;

    [Header("Object UI")]
    [SerializeField]
    private GameObject mainSceneUI;
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private GameObject gameClearUI;
    [SerializeField]
    private GameObject gameOverUI;

    [Header("PlayingUI")]
    //UI Gameplaying
    public Slider healthPoint;
    public GameObject boostSpeedGObj;
    public GameObject isBoosting;
    public GameObject lockSpeedGObj;
    public GameObject finishLap;
    public GameObject displayScene;
    public GameObject lapsObjects;
    public List<GameObject> ListCountdown;
    public Button boostSpeedButton;
    public Button changeToRocketStart;
    public Button LockBoostButton;
    public Button pauseButton;
    public string countText;
    public float timeValue = 3;
    public float currentTime;
    public float timeValueUp = 0;
    public float maxTimeValue = 300;
    //private float timeValueCountdown = 300;


    private ClickAnimation clickAnim;
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
    public TextMeshProUGUI countBoostNumber_Text;
    //public TextMeshProUGUI popUpNumber_Text;

    [Header("Minimap")]
    public GameObject miniMap;

    private HiresScreenShots screenShot;
    private int score;
    public int lapsToGameOver;
    public float timeGo = 0.5f;
    #endregion
    #region Unity Method
    //Game Start
    void Start()
    {
        checkPlaying = true;
        StartGame();
        //StartStatusOfPino();
        clickAnim = FindObjectOfType<ClickAnimation>();
        screenShot = FindObjectOfType<HiresScreenShots>();
        obstacles = FindObjectOfType<ObstaclesManager>();
        b_count = FindObjectOfType<BoostCount>();
        rankManagers = FindObjectOfType<RankManager>();
        displayScene = GameObject.Find("PanelWaitForDisplay");
    }


    void LateUpdate()
    {
        GamePlaying();
    }

    #endregion
    #region UIManager
    //Active when game start
    private void StartGame()
    {
        if (checkPlaying)
        {
            //mainSceneUI.gameObject.SetActive(true);
            pauseUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(false);
            gameClearUI.gameObject.SetActive(false);
            boostSpeedGObj.gameObject.SetActive(false);
        }
        if (!checkRunning)
        {
            countText = boostCount.ToString();
            boostSpeedGObj.gameObject.SetActive(true);
            boostSpeedButton.gameObject.SetActive(true);
            //charColl.m_CurrentSpeed = 0;
            mainSceneUI.gameObject.SetActive(false);
        }

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
                checkPause = !checkPause;
                miniMap.gameObject.SetActive(false);
                lapsObjects.gameObject.SetActive(false);
                Time.timeScale = 0f;
                Debug.Log("Pause");
            }
            else
            {
                //Disable PauseUI and enable other UI
                pauseUI.gameObject.SetActive(false);
                mainSceneUI.gameObject.SetActive(true);
                gameOverUI.gameObject.SetActive(false);
                lapsObjects.gameObject.SetActive(true);
                miniMap.gameObject.SetActive(true);
                checkPause = !checkPause;
                Time.timeScale = 1f;
                Debug.Log("Resume");
            }
        }

    }

    //private void setRank()
    //{
    //    if (currentTime <= toRankS)
    //    {
    //        rankText.text = "Rank S";
    //        messageText.text = "Perfect";
    //    }
    //    else if (currentTime <= toRankA)
    //    {
    //        rankText.text = "Rank A";
    //        messageText.text = "Awesome";
    //    }
    //    else if (currentTime <= toRankB)
    //    {
    //        rankText.text = "Rank B";
    //        messageText.text = "Cool";
    //    }
    //    else if (currentTime <= toRankC)
    //    {
    //        rankText.text = "Rank C";
    //        messageText.text = "Not bad";
    //    }
    //    else if (currentTime <= toRankD)
    //    {
    //        rankText.text = "Rank D";
    //        messageText.text = "One more time";
    //    }
    //    else if (currentTime <= toRankE)
    //    {
    //        rankText.text = "Rank E";
    //        messageText.text = "Try again";
    //    }
    //    else
    //    {
    //        rankText.text = "Rank F";
    //        messageText.text = "Never give up";
    //    }
    //}

    private void GamePlaying()
    {
        if (b_count.boostCount < 16)
        {
            startScene = false;
        }
        if (checkRunning)
        {
            if (checkDashBoost)
            {
                charInput.DashBoost();
                checkDashBoost = false;
            }
            //BoostSpeed();
            //HealthUpdate();
            //UpdateScore(0);
            if (timeGo > 0)
            {
                //countdownTimer_Text.text = "GO";
                timeGo -= Time.deltaTime;
            }
            else
            {
                //countdownTimer_Text.gameObject.SetActive(false);
            }
            TimeUp();
            GetVariables();

            mainSceneUI.gameObject.SetActive(true);
            charInput.GetComponent<CharacterInputController>().enabled = true;
            boostSpeedButton.gameObject.SetActive(false);
            changeToRocketStart.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
                rankManagers.setRank();
            }

        }
        else
        {
            if (startScene == false)
            {
                displayScene.gameObject.SetActive(false);
                miniMap.gameObject.SetActive(true);
                //countdownTimer_Text.gameObject.SetActive(true);
                lapsObjects.gameObject.SetActive(true);
                CountDown();
                if (checkCount)
                {
                    Debug.Log("False");
                    StartCoroutine(CountNumber());
                    checkCount = false;
                }
            }
            else
            {
                //countdownTimer_Text.gameObject.SetActive(false);
                miniMap.gameObject.SetActive(false);
                lapsObjects.gameObject.SetActive(false);
            }
            //popUpNumber_Text.text = boostCount + "";
            //countBoostNumber_Text.text = boostCount + "";
            BoostStart();
            //charColl.m_CurrentSpeed = 0;
            mainSceneUI.gameObject.SetActive(false);
            charInput.GetComponent<CharacterInputController>().enabled = false;
        }

        if (checkGameOver)
        {
            TimeOut();
        }

        if (checkGameClear)
        {
            GameClear();
        }
    }

    public void waitForDisplay()
    {
        startScene = false;
    }
    private void GetVariables()
    {
        //Get kph speed
        double kphSpeed = charInput.m_CurrentSpeed;
        int currendSpeed = (int)kphSpeed;
        kphText.text = currendSpeed + "";

        //Get current milk
        currentMilk = charColl.m_CurrentBottleMilk;
        milkNumberText.text = currentMilk + "";


    }

    //Active GameClearUI
    private void GameClear()
    {
        if (checkGameClear)
        {
            //Enable GameOver UI & Disable other UI
            gameClearUI.gameObject.SetActive(true);
            gameOverUI.gameObject.SetActive(false);
            pauseUI.gameObject.SetActive(false);
            lapsObjects.gameObject.SetActive(false);
            mainSceneUI.gameObject.SetActive(false);
            miniMap.gameObject.SetActive(false);
            screenShot.checkUI();
            if (rankManagers.checkRank)
            {
                rankManagers.setRank();
            }
            Time.timeScale = 0f;
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
    public void BoostStart()
    {
        boostCount = b_count.boostCount;
        //popUpNumber_Text.text = boostCount + "";
        countBoostNumber_Text.text = boostCount + "";
        if (boostCount == 0)
        {
            boostSpeedButton.gameObject.SetActive(false);
            changeToRocketStart.gameObject.SetActive(true);
            checkDashBoost = true;
            clickAnim.gameObject.SetActive(false);
            //popUpNumber_Text.gameObject.SetActive(false);
            //countBoostNumber_Text.gameObject.SetActive(false);
        }
        else
        {
            boostSpeedButton.gameObject.SetActive(true);
            changeToRocketStart.gameObject.SetActive(false);
        }
    }
    //Time to countdown
    public void CountDown()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            charColl.GetComponent<CharacterCollider>().enabled = false;
            mainSceneUI.gameObject.SetActive(false);
            //obstacles.GetComponent<ObstaclesManager>().enabled = false;
        }
        else
        {
            checkRunning = true;
            timeValue = 0;

        }
        DisplayTimer(timeValue);
    }
    //DisplayTimer
    public void DisplayTimer(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            obstacles.CallSpawnObstacles();
            mainSceneUI.gameObject.SetActive(true);
            //obstacles.StartSpawnObjects();
            charColl.GetComponent<CharacterCollider>().enabled = true;
            //charInput.GetComponent<CharacterInputController>().enabled = true;
            //obstacles.GetComponent<ObstaclesManager>().enabled = true;
            //charColl.m_CurrentSpeed += charColl.m_InitialSpeed;
        }
        //float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60) + 1;

        //countdownTimer_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);\
        countdownTimer_Text.text = seconds + "";
    }
    //TimeCountUp
    private void TimeUp()
    {
        if (timeValueUp < maxTimeValue)
        {
            timeValueUp += Time.deltaTime;

        }
        else
        {
            checkGameOver = true;
        }
        DisplayTimerCountUp(timeValueUp);
    }
    private void DisplayTimerCountUp(float timeToDisplayCountUp)
    {
        if (timeToDisplayCountUp == maxTimeValue)
        {
            timeToDisplayCountUp = 0;
            //GameOver();
        }
        float minutes = Mathf.FloorToInt(timeToDisplayCountUp / 60);
        float seconds = Mathf.FloorToInt(timeToDisplayCountUp % 60);
        float milliSeconds = (timeToDisplayCountUp % 1) * 1000;

        currentTime = timeToDisplayCountUp;

        limitedTimer_Text.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
        gameOverScoreText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void TimeOut()
    {
        if (checkGameOver)
        {
            gameClearUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(true);
            lapsObjects.gameObject.SetActive(false);
            pauseUI.gameObject.SetActive(false);
            mainSceneUI.gameObject.SetActive(false);
            Time.timeScale = 0f;
            miniMap.gameObject.SetActive(false);
        }
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
    #region Not using
    //Set Variables when game start
    private void StartStatusOfPino()
    {
        healthPoint.value = healthPoint.maxValue;

    }
    /**
    //Update Score, speed, item...
    public void UpdateScore(int scoreToAdd)
    {
        //Get currentSpeed pino
        currentSpeed = charColl.m_CurrentSpeed;
        //Get score & convert float to int
        currentScore = m_Player.transform.position.z;
        currentScore = Mathf.FloorToInt(currentScore);
        //TimeCountUp
        //Get kph speed
        double kphSpeed = charColl.m_CurrentSpeed * 3.6;
        int currendSpeed = (int)kphSpeed;
        kphText.text = currendSpeed + "";

        //Get score
        score += scoreToAdd;
        scoreText.text = currentScore + " m";
        gameOverScoreText.text = currentScore + "m";
    }
    **/
    //Set HP Decrease 
    public void HealthUpdate()
    {
        if (checkRunning)
        {
            //CountDownMinutes();

            //HP decrease by time & initial def
            //charColl.m_CurrentStamina = (int) currentStamina;

            //TimeUp();
            // charColl.m_CurrentStamina -= healthDown * Time.deltaTime;
            // currentStamina = charColl.m_CurrentStamina;
            healthPoint.value = currentStamina;
            // if (charColl.m_CurrentStamina >= healthPoint.maxValue)
            // {
            //     charColl.m_CurrentStamina = healthPoint.maxValue;
            // }
            if (currentStamina > healthPoint.maxValue)
            {
                currentStamina = healthPoint.maxValue;
                healthPoint.value = healthPoint.maxValue;
            }
            if (healthPoint.value <= 0)
            {
                healthPoint.value = 0;
                checkGameClear = true;
                GameClear();
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
        // crystalCollected = charColl.m_CurrentCrystal;
        if (charColl.m_IsEnoughBoost == true)
        {
            //crystalCollected = 6;
            checkBoost = true;
        }
        else if (charColl.m_IsEnoughBoost == false)
        {
            //crystalCollected = 0;
            checkBoost = false;
        }

        //Check Unlock Button
        if (checkBoost)
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

    IEnumerator CountNumber()
    {

        for(int i = 3; i <= ListCountdown.Count; i--)
        {
            if (i < 0)
            {
                break;
            }
            else
            {
                ListCountdown[i].gameObject.SetActive(true);
                yield return new WaitForSeconds(1f);
                ListCountdown[i].gameObject.SetActive(false);
                Debug.Log(ListCountdown[i]);
            }
        }
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
    #endregion
}
