using System;
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

    [Tooltip("Set Object player")]
    [HideInInspector] public CharacterController charInput;
    [HideInInspector] public Character charColl;
    [HideInInspector] public ObstaclesManager obstacles;
    // Get player for get Speed;
    [HideInInspector] public GameObject m_Player;
    [HideInInspector] public BoostCount b_count;
    [HideInInspector] public RankManager rankManagers;

    [Tooltip("Sound Managers")]
    [HideInInspector] public SoundManagers audio_source;
    [HideInInspector] public SoundManagers audio_BGM;
    [HideInInspector] public SoundManagers audio_warning;
    [HideInInspector] public SoundManagers audio_player;

    [Header("Player Variables")]
    public int boostCount = 16;
    public float currentScore;
    public float currentSpeed;
    public float currentMilk;
    [HideInInspector] public float currentStamina;
    [HideInInspector] public int crystalCollected;
    [HideInInspector] public static int pinoSelected;
    [HideInInspector] public float healthDown;

    //Check to active UI & button;
    [Header("Check active")]
    [HideInInspector] public bool checkPause;
    [HideInInspector] public bool checkGameOver;
    [HideInInspector] public bool checkGameClear;
    [HideInInspector] public bool checkPlaying;
    [HideInInspector] public bool checkBoost;
    [HideInInspector] public bool checkRunning = false;
    [HideInInspector] public bool checkDashBoost = false;
    [HideInInspector] public bool startScene = true;
    [HideInInspector] public bool endGame;
    [HideInInspector] public bool m_Engine;
    private bool checkCount = true;
    private bool checkSoundOver = true;
    [SerializeField] private bool boostFail = true;
    private bool checkWarning = true;
    private bool checkEngine = true;
    private bool boostSuccess = true;

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
    //UI Game playing
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
    public float timeToWarning;
    
    [Header("CPU")]
    [SerializeField] private CPU cpuInput;
    #endregion
    #region Unity Method
    //Game Start
    void Start()
    {
        StartGame();
    }
    void Update()
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
            pauseUI.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(false);
            gameClearUI.gameObject.SetActive(false);
            boostSpeedGObj.gameObject.SetActive(false);
            GetMilk();
        }
        if (!checkRunning)
        {
            countText = boostCount.ToString();
            boostSpeedGObj.gameObject.SetActive(true);
            boostSpeedButton.gameObject.SetActive(true);
            mainSceneUI.gameObject.SetActive(false);
        }
        checkPlaying = true;
        GetComponent();
        audio_BGM.PlaySound(SoundType.BGM);
    }
    //Get component
    private void GetComponent()
    {
        clickAnim = FindObjectOfType<ClickAnimation>();
        screenShot = FindObjectOfType<HiresScreenShots>();
        obstacles = FindObjectOfType<ObstaclesManager>();
        b_count = FindObjectOfType<BoostCount>();
        audio_source = GameObject.FindGameObjectWithTag("SoundManagers").GetComponent<SoundManagers>();
        audio_BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<SoundManagers>();
        audio_warning = GameObject.FindGameObjectWithTag("SE_Warning").GetComponent<SoundManagers>();
        audio_player = GameObject.FindGameObjectWithTag("SE_Player").GetComponent<SoundManagers>();

        rankManagers = FindObjectOfType<RankManager>();
        displayScene = GameObject.Find("PanelWaitForDisplay");
    }

    //Active PauseUI
    public void PauseGame()
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
        }
    }

    //Check GamePlaying
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
            else
            {
                if (boostFail && b_count.boostCount != 0)
                {
                    charColl.animStuns.SetBool("boostFail", boostFail);
                    Invoke("DisableAnimation", 10f);
                    charInput.m_IsBoostSuccess = true;
                }
            }

            if (timeGo > 0)
            {
                timeGo -= Time.deltaTime;
            }
            TimeUp();
            GetVariables();

            mainSceneUI.gameObject.SetActive(true);
            charInput.GetComponent<CharacterController>().enabled = true;
            cpuInput.GetComponent<CPU>().enabled = true;
            boostSpeedButton.gameObject.SetActive(false);
            changeToRocketStart.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
                rankManagers.setRank();
            }

            AddEngineSE();
        }
        else
        {
            if (startScene == false)
            {
                displayScene.gameObject.SetActive(false);
                miniMap.gameObject.SetActive(true);
                lapsObjects.gameObject.SetActive(true);
                CountDown();
                if (checkCount)
                {
                    audio_source.PlaySound(SoundType.CountDown);
                    StartCoroutine(CountNumber());
                    checkCount = false;
                }
            }
            else
            {
                miniMap.gameObject.SetActive(false);
                lapsObjects.gameObject.SetActive(false);
            }
            BoostStart();
            mainSceneUI.gameObject.SetActive(false);
            charInput.GetComponent<CharacterController>().enabled = false;
            cpuInput.GetComponent<CPU>().enabled = false;
        }

        if (checkGameOver)
        {
            audio_warning.PlaySound(SoundType.Stop);
            audio_player.PlaySound(SoundType.Stop);
            m_Engine = false;
            TimeOut();
        }

        if (checkGameClear)
        {
            audio_warning.PlaySound(SoundType.Stop);
            audio_player.PlaySound(SoundType.Stop);
            m_Engine = false;
            GameClear();

        }
        CheckTimeScale();
        checkTimeToWarning();
    }

    //Add Engine SE
    void AddEngineSE()
    {
        if (checkEngine)
        {
            audio_player.PlaySound(SoundType.Engine);
            checkEngine = false;
        }
    }

    //Disable Animation when boost fail
    private void DisableAnimation()
    {
        boostFail = false;
        charColl.animStuns.SetBool("boostFail", boostFail);  
    }
    //Hide display when start
    public void waitForDisplay()
    {
        startScene = false;
    }

    //Check Time Scale
    void CheckTimeScale()
    {
        if (Time.timeScale == 0f)
        {
            checkPlaying = false;
        }
        else
        {
            checkPlaying = true;
        }

    }
    //Get Speed & Milk
    public void GetVariables()
    {
        //Get kph speed
        double kphSpeed = charInput.m_CurrentSpeed;
        kphText.text = Math.Round(kphSpeed) + "";
    }

    public void GetMilk()
    {
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
            endGame = true;
            checkGameClear = false;
        }
    }

    //Return to GameStart Scene
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Check Boost When tap 16 times
    public void BoostStart()
    {
        boostCount = b_count.boostCount;
        countBoostNumber_Text.text = boostCount + "";
        if (boostCount == 0)
        {
            if (boostSuccess)
            {
                boostSpeedButton.gameObject.SetActive(false);
                changeToRocketStart.gameObject.SetActive(true);
                audio_source.PlaySound(SoundType.DashBoost);
                checkDashBoost = true;
                boostSuccess = false;
            }
        }
        else
        {
            boostSpeedButton.gameObject.SetActive(true);
            changeToRocketStart.gameObject.SetActive(false);

        }
    }
    //Time to countdown when game start
    public void CountDown()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            charColl.GetComponent<Character>().enabled = false;
            mainSceneUI.gameObject.SetActive(false);
        }
        else
        {
            checkRunning = true;
            timeValue = 0;
            //charInput.m_Engine = true;
        }
        DisplayTimer(timeValue);
    }
    //Display Timer on UI
    public void DisplayTimer(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            obstacles.CallSpawnObstacles();
            mainSceneUI.gameObject.SetActive(true);
            charColl.GetComponent<Character>().enabled = true;
        }
        float seconds = Mathf.FloorToInt(timeToDisplay % 60) + 1;

        countdownTimer_Text.text = seconds + "";
    }

    public void DisableEngineSound()
    {
        StartCoroutine(EngineSE());
    }

    IEnumerator EngineSE()
    {
        audio_player.PlaySound(SoundType.Stop);
        yield return new WaitForSeconds(1f);
        audio_player.PlaySound(SoundType.Engine);
    }
    //Timer
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

    //Play Sound when game over
    void checkSoundGameOver()
    {
        if (checkSoundOver)
        {
            audio_source.PlaySound(SoundType.GameOverSE);
            audio_BGM.PlaySound(SoundType.Stop);
            audio_BGM.PlaySound(SoundType.GameOver);
            checkSoundOver = false;
        }

    }
    //Add sound warning
    void CheckSoundWarning()
    {
        if (checkWarning)
        {
            audio_warning.PlaySound(SoundType.Warning);
            checkWarning = false;
        }
    }

    void checkTimeToWarning()
    {
        if (currentTime >= timeToWarning)
        {
            CheckSoundWarning();
        }
    }
    //Show Timer
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
        gameOverScoreText.text = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }

    //Check GameOver
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
            checkSoundGameOver();
        }
    }
    IEnumerator CountNumber()
    {

        for (int i = 2; i <= ListCountdown.Count; i--)
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
                // Debug.Log(ListCountdown[i]);
            }
        }
    }
    #endregion
    #region Not using
    //
    //Set Variables when game start
    //private void StartStatusOfPino()
    //{
    //    healthPoint.value = healthPoint.maxValue;

    //}
    /**
     * 
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

     * 
     * 
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
    /**
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
    **/
    /**
    //Check BoostSpeed
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
    **/
    //BoostSpeed
    /**
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
    **/


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
