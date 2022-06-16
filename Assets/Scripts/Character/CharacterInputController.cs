using System;
/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CharacterInputController : MonoBehaviour
{
    #region Variables

    // Animation =====

    // Scripts ====
    [Header("Variables")]
    public CharacterCollider m_Character;
    public PathCreator m_PathCreator;
    public GameObject spawnerObject;
    GameObject m_WallClearLag;
    UIManager uiManagers;
    // Variables ====

    [Header("Controls")]
    [Tooltip("The more you press, the faster the character will change lines")]
    public float m_SecondChangeLine;
    [Tooltip("Speed of the character when you click boost")]
    public float m_BoostSpeed;
    [Tooltip("Range of the character move when you swipe")]
    public int slideLength;
    public bool m_IsRemainBoost;
    [HideInInspector] public bool m_IsBoosting;
    [HideInInspector] public bool m_PadsIsBoosting;
    [HideInInspector] public bool m_Stuns;

    // Init number Items ====
    [HideInInspector] public float m_CurrentSpeed;
    [HideInInspector] public float m_MilkCollectSpeed;
    float m_CharacterPosition;
    public float m_DriveSpeed;
    int m_TimeBoost;
    int laneNumber;

    // Init Bool ====
    bool m_IsChangeLine;
    bool m_IsGotMilk;
    bool m_VelocityUp;
    bool m_IsChangePosition;

    Vector3 m_Direction;
    Quaternion m_Rotation;

    public bool m_UpSpeed;

#if !UNITY_STANDALONE
    protected Vector2 m_StartingTouch;
    protected bool m_IsSwiping = false;
#endif

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        m_MilkCollectSpeed = m_Character.m_InitialSpeed;
        m_Character.m_CurrentSpeed = m_Character.m_InitialSpeed;
        m_CurrentSpeed = m_Character.m_InitialSpeed;

        laneNumber = 2;
        m_CharacterPosition = 0;
        m_TimeBoost = 3;

        m_IsChangeLine = true;
        m_VelocityUp = true;

        m_IsBoosting = false;
        m_IsRemainBoost = false;
        m_IsGotMilk = false;
        m_IsChangePosition = false;
        m_PadsIsBoosting = false;
        m_UpSpeed = false;
        m_Stuns = false;

        GetComponentInGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnerObject && !m_Character && !m_WallClearLag)
            GetComponentInGame();

        MoveInput();

        // Debug.Log("m_CurrentSpeed: " + m_CurrentSpeed + " m_Character.m_CurrentSpeed: " + m_Character.m_CurrentSpeed);
    }

    #endregion

    #region Class

    void MoveInput()
    {
        CharacterMove();

        GotMilkSpeed();

        ChangePosition();

        GotStuns();

        SpeedUp();
    }
    void GetComponentInGame()
    {
        spawnerObject = GameObject.FindGameObjectWithTag("Spawner");
        m_Character = gameObject.GetComponentInChildren<CharacterCollider>();
        m_WallClearLag = GameObject.FindGameObjectWithTag("ClearLag");
    }
    void GotStuns()
    {
        if (m_Stuns)
        {
            m_Character.rootObject.transform.Rotate(Vector3.up, 720 * Time.deltaTime, Space.Self);
            StartCoroutine(ReturnRotationStun());
        }
    }
    void SpeedUp()
    {
        if (m_VelocityUp && !m_Stuns && m_CurrentSpeed < m_Character.m_MaxSpeed && m_Character.m_CurrentSpeed < m_Character.m_MaxSpeed)
        {
            m_Character.m_CurrentSpeed += (m_Character.m_InitialVelocity + (m_Character.m_CurrentBottleMilk * 5f));
            m_CurrentSpeed += (m_Character.m_InitialVelocity + (m_Character.m_CurrentBottleMilk * 5f));
            m_MilkCollectSpeed += (m_Character.m_InitialVelocity + (m_Character.m_CurrentBottleMilk * 5f));
            m_VelocityUp = false;
            StartCoroutine(VelocityUp());
        }
    }
    void GotMilkSpeed()
    {
        if (m_IsGotMilk)
        {
            if (!m_IsBoosting && !m_PadsIsBoosting && !m_Stuns)
            {
                if (m_Character.m_CurrentSpeed < m_MilkCollectSpeed)
                {
                    m_Character.m_CurrentSpeed = m_MilkCollectSpeed;
                }
                else
                {
                    int _TimePerSec = m_TimeBoost;
                    float _temp = (m_BoostSpeed - m_MilkCollectSpeed) / (_TimePerSec * m_TimeBoost); // tempt speed

                    while (m_Character.m_CurrentSpeed > m_MilkCollectSpeed)
                    {
                        m_Character.m_CurrentSpeed -= _temp;
                        if (m_Character.m_CurrentSpeed < m_MilkCollectSpeed)
                        {
                            m_Character.m_CurrentSpeed = m_MilkCollectSpeed;
                        }
                    }
                }
            }
        }
    }
    void CharacterMove()
    {
        if (m_Character.m_CurrentSpeed >= m_CurrentSpeed)
        {
            m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, m_Character.m_CurrentSpeed, m_Character.m_InitialVelocity * Time.deltaTime);
        }

        m_DriveSpeed += (m_CurrentSpeed * Time.deltaTime) / 10;

        Vector3 _tempDistance = m_PathCreator.path.GetPointAtDistance(m_DriveSpeed);
        Vector3 _tempDistanceClearLag = m_PathCreator.path.GetPointAtDistance(m_DriveSpeed - 20f);
        Vector3 _tempDistanceSpawner = m_PathCreator.path.GetPointAtDistance(m_DriveSpeed + 60f);

        Quaternion _tempRotation = m_PathCreator.path.GetRotationAtDistance(m_DriveSpeed + 7f);
        Quaternion _tempRotationSpawner = m_PathCreator.path.GetRotationAtDistance(m_DriveSpeed + 70f);

        m_Character.transform.localPosition = _tempDistance;
        spawnerObject.transform.localPosition = _tempDistanceSpawner;
        m_WallClearLag.transform.localPosition = _tempDistanceClearLag;


        m_Character.transform.localRotation = Quaternion.Lerp(m_Character.transform.localRotation, _tempRotation, 2f * Time.deltaTime);
        m_WallClearLag.transform.localRotation = Quaternion.Lerp(m_WallClearLag.transform.localRotation, _tempRotationSpawner, 7f * Time.deltaTime);

        spawnerObject.transform.localRotation = _tempRotationSpawner;

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneNumber > 1 && m_IsChangeLine && !m_Stuns)
        {
            ChangeLane(-slideLength);
            laneNumber -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && laneNumber < 3 && m_IsChangeLine && !m_Stuns)
        {
            ChangeLane(slideLength);
            laneNumber += 1;
        }

        //Test boost in unity editor
        if (Input.GetKeyDown(KeyCode.R))
            DashBoost();


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

                //we set the swip distance to trigger movement to 1% of the screen width
                if (diff.magnitude > 0.01f)
                {
                    if (!m_Stuns && diff.x < 0 && laneNumber > 1 && m_IsChangeLine)
                    {
                        ChangeLane(-slideLength);
                        laneNumber -= 1;
                    }
                    else if (!m_Stuns && diff.x >= 0 && laneNumber < 3 && m_IsChangeLine)
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
    void ChangeLane(int _direction)
    {
        ChangeRotation(_direction);
        StartCoroutine(ReturnRotation());
        m_IsChangePosition = true;

        m_CharacterPosition = _direction;
        StartCoroutine(StopMoving());
        m_IsChangeLine = false;
    }
    void ChangeRotation(int _direction)
    {
        m_Character.rootObject.transform.localRotation = Quaternion.Euler(0, _direction * 2f, 0);
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
        {
            StartCoroutine(CheckRemainBoost());
        }
        else
        {
            if (m_Character.m_CurrentBottleMilk >= 1)
            {
                m_MilkCollectSpeed = m_Character.m_CurrentSpeed + 5f;
                m_IsGotMilk = true;
            }
        }
    }
    public void DashBoost()
    {
        if (!m_IsBoosting)
        {
            m_Character.m_CurrentSpeed = m_Character.m_MaxSpeed;
        }
        m_IsRemainBoost = true;
    }
    IEnumerator CheckRemainBoost()
    {
        yield return new WaitForSeconds(2f);

        ChangeSpeed();
    }
    IEnumerator ReturnRotation()
    {
        yield return new WaitForSeconds(m_SecondChangeLine);

        m_Character.rootObject.transform.localRotation = Quaternion.identity;
    }
    IEnumerator ReturnRotationStun()
    {
        yield return new WaitForSeconds(1f);

        m_Character.rootObject.transform.localRotation = Quaternion.identity;
        m_Character.m_CurrentSpeed = m_Character.m_InitialSpeed;

        m_Character.m_Stuns = false;
        m_Stuns = false;
    }
    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(m_SecondChangeLine);

        m_CharacterPosition = 0;
        m_IsChangeLine = true;
        m_IsChangePosition = false;

        //stop track

        //Set animation die

    }
    IEnumerator VelocityUp()
    {
        yield return new WaitForSeconds(1f);
        m_VelocityUp = true;
        m_UpSpeed = false;
    }
    #endregion
}
