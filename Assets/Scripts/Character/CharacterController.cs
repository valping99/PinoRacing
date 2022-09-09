using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CharacterController : StateMachine
{
    #region Variables

#if !UNITY_STANDALONE
    [Header("Mobile Controller"), SerializeField]
    protected bool m_IsSwiping = false;
    [SerializeField] protected Vector2 m_StartingTouch;
#endif

    [Header("Variables")]
    public Character m_Character;
    public PathCreator m_PathCreator;
    public GameObject spawnerObject;
    public GameObject[] listSpawner;
    GameObject m_WallClearLag;
    UIManager uiManagers;

    [Header("Controls")]
    [Tooltip("The more you press, the faster the character will change lines"), Range(0, 1)]
    public float m_SecondChangeLine;
    [Tooltip("Speed of the character when you click boost"), Range(0, 300)]
    public float m_BoostSpeed;
    [Tooltip("Range of the character move when you swipe"), Range(0, 10)]
    public int slideLength;
    [HideInInspector] public bool m_IsRemainBoost;
    [HideInInspector] public bool m_UpSpeed;
    [HideInInspector] public bool m_IsBoosting;
    [HideInInspector] public bool m_PadsIsBoosting;
     public bool m_Stuns;
    [HideInInspector] public bool m_IsChangeLine;
    [HideInInspector] public bool m_IsGotMilk;
    [HideInInspector] public bool m_VelocityUp;
    [HideInInspector] public bool m_IsChangePosition;
    [HideInInspector] public bool m_IsDebugOn;
    [HideInInspector] public bool m_IsBoostSuccess;
    [HideInInspector, Range(0, 300)] public float m_CurrentSpeed;
    [HideInInspector, Range(0, 300)] public float m_MilkCollectSpeed;
    [HideInInspector] public float padTimer;
    [HideInInspector] public float stunTimer;
    [HideInInspector] public float delay;
    [Range(0, 30000)] public float m_DistanceLength;
    [Range(0, 4)] public float m_CharacterPosition;
    [Range(0, 3)] public int laneNumber;

    [Tooltip("Sound Manager")]
    public SoundManagers m_audioSource;
    public SoundManagers m_audioSource_ChangeLane;



    Vector3 m_Direction;
    Quaternion m_Rotation;

    float repeatRate;

    #endregion

    #region Unity Methods

    void Start()
    {
        GetComponentInGame();
        InitialComponent();
    }

    void Update()
    {
        WheelRotation();
        ChangePosition();
        
    }

    void FixedUpdate()
    {
        if (!spawnerObject && !m_Character && !m_WallClearLag)
            GetComponentInGame();

        MoveInput();

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.B))
            m_IsDebugOn = !m_IsDebugOn;

#else
        DebugLog();
#endif
    }

    #endregion

    #region Class

    void DebugLog()
    {
        Debug.Log("Current Speed Controller: " + m_CurrentSpeed +
        "\nCurrent Speed: " + m_Character.m_CurrentSpeed +
        "\nDistance Length: " + m_DistanceLength + "\nMax Speed: " + m_Character.m_MaxSpeed);
    }
    void InitialComponent()
    {
        // Initialize the state machine
        SetState(new PlayerBehavior(this));

        m_MilkCollectSpeed = m_Character.m_InitialSpeed;

        m_CharacterPosition = 0;
        padTimer = 0;
        stunTimer = 0;
        laneNumber = 2;
        delay = 2;
        repeatRate = delay;

        m_IsChangeLine = true;
        m_VelocityUp = true;

        m_IsBoosting = false;
        m_IsRemainBoost = false;
        m_IsChangePosition = false;
        m_PadsIsBoosting = false;
        m_UpSpeed = false;
        m_Stuns = false;
        m_IsDebugOn = false;
        m_IsBoostSuccess = true;

        listSpawner[1].gameObject.transform.localPosition = new Vector3(slideLength, 0, 0);
        listSpawner[2].gameObject.transform.localPosition = new Vector3(-slideLength, 0, 0);

    }
    void MoveInput()
    {
        CharacterMove();
        GotStuns();
        SpeedUp();
    }
    void WheelRotation()
    {
        /*if (!m_Stuns && m_CurrentSpeed >= 1f)*/
        if (m_CurrentSpeed >= 1f)
        {
            foreach (var wheel in m_Character.wheelCream)
            {
                wheel.transform.Rotate(Vector3.right, 360 * m_Character.m_CurrentSpeed * Time.deltaTime);
            }
        }

    }
    void GetComponentInGame()
    {
        m_WallClearLag = GameObject.FindGameObjectWithTag("ClearLag");
        spawnerObject = GameObject.FindGameObjectWithTag("Spawner");
        m_audioSource = GameObject.FindGameObjectWithTag("SE_Player").GetComponent<SoundManagers>();
        m_audioSource_ChangeLane = GameObject.FindGameObjectWithTag("SE_ChangeLane").GetComponent<SoundManagers>();
        m_Character = gameObject.GetComponentInChildren<Character>();
    }
    void GotStuns()
    {
        if (m_Stuns)
        {
            m_Character.animStuns.applyRootMotion = false;
            m_Character.animShadow.applyRootMotion = false;
            m_Character.animStuns.SetBool("isCrash", m_Stuns);
            m_Character.animStuns.SetBool("FlipAgain", m_Character.m_Flip);
            m_Character.animShadow.SetBool("isCrash", m_Stuns);

            if (stunTimer < 0)
            {
                stunTimer = repeatRate;

                m_Character.m_Stuns = false;
                m_Stuns = false;
                m_Character.animStuns.applyRootMotion = true;
                m_Character.animShadow.applyRootMotion = true;

                m_Character.rootObject.transform.localRotation = Quaternion.identity;

                m_Character.animStuns.SetBool("isCrash", m_Stuns);
                m_Character.animStuns.SetBool("FlipAgain", m_Character.m_Flip);
                m_Character.animShadow.SetBool("isCrash", m_Stuns);

                // StartCoroutine(State.FallenStuns());
            }

        }
    }
    void SpeedUp()
    {
        //if (m_VelocityUp && !m_Stuns && m_CurrentSpeed < m_Character.m_MaxSpeed && m_Character.m_CurrentSpeed < m_Character.m_MaxSpeed)
        if (m_VelocityUp && m_CurrentSpeed < m_Character.m_MaxSpeed && m_Character.m_CurrentSpeed < m_Character.m_MaxSpeed)
        {
            //m_Character.m_CurrentSpeed += m_Character.m_InitialAcceleration; // Feedback 69
            m_Character.m_CurrentSpeed += m_Character.m_InitialAcceleration * 1.25f;
            m_MilkCollectSpeed += m_Character.m_InitialAcceleration;
            m_VelocityUp = false;
            StartCoroutine(State.AccelerationUp());
        }
    }
    void CharacterMove()
    {
        CheckSpeed();

        m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, m_Character.m_CurrentSpeed,Time.deltaTime);

        m_DistanceLength += (m_CurrentSpeed * Time.deltaTime) / 10;

        Vector3 _tempDistance = m_PathCreator.path.GetPointAtDistance(m_DistanceLength);
        Vector3 _tempDistanceClearLag = m_PathCreator.path.GetPointAtDistance(m_DistanceLength - 20f);
        Vector3 _tempDistanceSpawner = m_PathCreator.path.GetPointAtDistance(m_DistanceLength + 60f);

        Quaternion _tempRotation = m_PathCreator.path.GetRotationAtDistance(m_DistanceLength + 7f);
        Quaternion _tempRotationSpawner = m_PathCreator.path.GetRotationAtDistance(m_DistanceLength + 60f);
        Quaternion _tempRotationClearLag = m_PathCreator.path.GetRotationAtDistance(m_DistanceLength - 7f);

        m_Character.transform.localPosition = _tempDistance;
        spawnerObject.transform.position = _tempDistanceSpawner;
        m_WallClearLag.transform.localPosition = _tempDistanceClearLag;


        m_Character.transform.localRotation = Quaternion.Lerp(m_Character.transform.localRotation, _tempRotation, 7f * Time.deltaTime);
        spawnerObject.transform.localRotation = Quaternion.Lerp(spawnerObject.transform.localRotation, _tempRotationSpawner, 2f * Time.deltaTime);
        m_WallClearLag.transform.localRotation = Quaternion.Lerp(m_WallClearLag.transform.localRotation, _tempRotationClearLag, 7f * Time.deltaTime);

        spawnerObject.transform.localRotation = _tempRotationSpawner;

        //Test boost in unity editor
        if (Input.GetKey(KeyCode.R))
            m_PadsIsBoosting = true;

        if (Input.GetKey(KeyCode.M))
        {
            m_Character.m_CurrentBottleMilk += 500;
            ChangeSpeed();
            MediatorPlayer.GetMilk();
        }
        if (Input.GetKey(KeyCode.N))
        {
            if (m_Character.m_CurrentBottleMilk >= 500)
                m_Character.m_CurrentBottleMilk -= 500;
            ChangeSpeed();
            MediatorPlayer.GetMilk();
        }
        if (m_IsDebugOn)
            DebugLog();

#if UNITY_EDITOR || UNITY_STANDALONE
        /*if (Input.GetKeyDown(KeyCode.LeftArrow) && laneNumber > 1 && m_IsChangeLine && !m_Stuns && !m_IsBoostSuccess)*/
        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneNumber > 1 && m_IsChangeLine /*&& !m_IsBoostSuccess*/ && m_Character.m_Flip == false)
        {
            ChangeLane(-slideLength);
            laneNumber -= 1;
        }
        /*else if (Input.GetKeyDown(KeyCode.RightArrow) && laneNumber < 3 && m_IsChangeLine && !m_Stuns && !m_IsBoostSuccess)*/
        else if (Input.GetKeyDown(KeyCode.RightArrow) && laneNumber < 3 && m_IsChangeLine /*&& !m_IsBoostSuccess*/ && m_Character.m_Flip == false)
        {
            ChangeLane(slideLength);
            laneNumber += 1;
        }
#else
        // Use touch input on mobile
        if (Input.touchCount == 1)
        {
            if (m_IsSwiping)
            {
                Vector2 diff = Input.GetTouch(0).position - m_StartingTouch;

                // Put difference in Screen ratio, but using only width, so the ratio is the same on both
                // axes (otherwise we would have to swipe more vertically...)
                diff = new Vector2(diff.x / Screen.width, diff.y / Screen.width);

                // we set the swip distance to trigger movement to 1% of the screen width
                if (diff.magnitude > 0.01f)
                {
                    /*if (!m_Stuns && diff.x < 0 && laneNumber > 1 && m_IsChangeLine && !m_IsBoostSuccess)*/
                    if (diff.x < 0 && laneNumber > 1 && m_IsChangeLine && m_Character.m_Flip == false)
                    {
                        ChangeLane(-slideLength);
                        laneNumber -= 1;
                    }
                    /*else if (!m_Stuns && diff.x >= 0 && laneNumber < 3 && m_IsChangeLine && !m_IsBoostSuccess)*/
                    else if (diff.x >= 0 && laneNumber < 3 && m_IsChangeLine && m_Character.m_Flip == false)
                    {
                        ChangeLane(slideLength);
                        laneNumber += 1;
                    }
                    m_IsSwiping = false;
                }
            }

            // Input check is AFTER the swip test, that way if TouchPhase.Ended happen a single frame after the Began Phase
            // a swipe can still be registered (otherwise, m_IsSwiping will be set to false and the test wouldn't happen for that began-Ended pair)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                m_StartingTouch = Input.GetTouch(0).position;
                m_IsSwiping = true;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                m_IsSwiping = false;
            }
        }
#endif
    }
    void CheckSpeed()
    {
        if (m_Character.m_CurrentSpeed > m_Character.m_MaxSpeed)
            m_Character.m_CurrentSpeed = m_Character.m_MaxSpeed;

        CheckBoostPad();

        if (m_PadsIsBoosting)
        {
            bool _isBoosting = true;

            if (_isBoosting)
            {
                float _speed = m_Character.m_CurrentSpeed * 0.2f;
                m_Character.m_CurrentSpeed += _speed;
                _isBoosting = false;
            }
        }

        padTimer -= Time.deltaTime;
        stunTimer -= Time.deltaTime;

        if (m_IsBoostSuccess)
            StartCoroutine(State.ReturnNormal());

    }

    //

    //
    void ChangeLane(int _direction)
    {
        m_CharacterPosition = _direction;

        ChangeRotation(_direction);
        StartCoroutine(State.ReturnRotation());
        StartCoroutine(State.StopMoving());

        m_IsChangePosition = true;
        m_IsChangeLine = false;

        m_audioSource_ChangeLane.PlaySound(SoundType.LaneMove);
    }
    void ChangeRotation(int _direction)
    {
        m_Character.rootObject.transform.localRotation = Quaternion.Euler(0, _direction * 2f, 0);

        m_Character.wheelCream[0].transform.localRotation = Quaternion.Euler(0, _direction * 7f, 0);
        m_Character.wheelCream[1].transform.localRotation = Quaternion.Euler(0, _direction * 7f, 0);

    }
    void ChangePosition()
    {
        if (m_IsChangePosition)
        {
            m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(m_CharacterPosition, 0, 0), 2f * Time.deltaTime);
        }
        else
        {
            if (laneNumber == 1)
            {
                m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(-slideLength, 0, 0), 2f * Time.deltaTime);
            }
            else if (laneNumber == 3)
            {
                m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(slideLength, 0, 0), 2f * Time.deltaTime);
            }
            else
            {
                m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(0, 0, 0), 2f * Time.deltaTime);
            }
        }
    }
    public void ChangeSpeed()
    {
        if (m_PadsIsBoosting || m_Stuns)
            StartCoroutine(State.CheckRemainBoost());

        m_UpSpeed = true;
    }
    public void DashBoost()
    {
        if (!m_IsBoosting)
            m_Character.m_CurrentSpeed = m_Character.m_MaxSpeed;

        m_IsRemainBoost = true;
    }
    void CheckBoostPad()
    {
        if (padTimer < 0)
        {
            padTimer = repeatRate;
            m_PadsIsBoosting = false;
        }
    }

    #endregion
}
