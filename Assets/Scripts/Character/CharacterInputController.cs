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
    UIManager uiManagers;
    public CharacterCollider m_Character;
    public PathCreator m_PathCreator;
    // public PathCreator m_PathCreator1;
    // public PathCreator m_PathCreator2;
    GameObject m_WallClearLag;
    // Variables ====

    [Header("Controls")]
    [Tooltip("The more you press, the faster the character will change lines")]
    public float m_SecondChangeLine;
    [Tooltip("Range of the character move when you swipe")]
    public int slideLength;
    public float m_BoostSpeed;
    [Tooltip("Speed of the character when you click boost")]
    public bool m_IsBoosting;

    // Init number Items ====
    float m_CharacterPosition;
    [HideInInspector] public float m_MilkCollectSpeed;
    int m_TimeBoost;
    int laneNumber;

    // Init Bool ====
    bool m_IsChangeLine;
    bool m_IsGotMilk;
    bool IsFirstTime;
    bool change;
    [SerializeField] bool m_IsRemainBoost;

    Vector3 m_Direction;
    Quaternion m_Rotation;

    float speed;
    #endregion

    #region Unity Methods

#if !UNITY_STANDALONE
    protected Vector2 m_StartingTouch;
    protected bool m_IsSwiping = false;
#endif

    // Start is called before the first frame update
    void Start()
    {
        ChangeSpeed();

        m_MilkCollectSpeed = m_Character.m_InitialSpeed;

        laneNumber = 2; // 1 = left, 0 = middle, 2 = right
        m_CharacterPosition = 0;
        m_TimeBoost = 3;

        m_IsChangeLine = true;
        m_IsBoosting = false;
        m_IsRemainBoost = false;
        m_IsGotMilk = false;
        IsFirstTime = true;
        change = false;

        m_Character = gameObject.GetComponentInChildren<CharacterCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Character)
        {
            m_Character = gameObject.GetComponentInChildren<CharacterCollider>();
        }

        if (!m_WallClearLag)
        {
            m_WallClearLag = GameObject.FindGameObjectWithTag("ClearLag");
        }

        MoveInput();

    }

    #endregion

    #region Class

    public void ChangeLane(int _direction)
    {
        Rotation(_direction);
        StartCoroutine(ReturnRotation());
        change = true;

        m_CharacterPosition = _direction;
        StartCoroutine(StopMoving());
        m_IsChangeLine = false;
    }

    void MoveInput()
    {
        // m_Character.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, m_Character.m_CurrentSpeed);

        // if (laneNumber == 1 && laneNumber == 3)
        // {

        // }
        // else
        // {
        //     m_Character.transform.Translate(Vector3.right * Time.deltaTime * m_CharacterPosition);
        // }
        speed += (m_Character.m_CurrentSpeed * Time.deltaTime) / 10;
        // if (laneNumber == 1)
        // {


        // }
        Vector3 _tempDistance = m_PathCreator.path.GetPointAtDistance(speed);
        Quaternion _tempRotation = m_PathCreator.path.GetRotationAtDistance(speed);

        if (change)
        {
            m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(m_CharacterPosition, 0, 0), 2f * Time.deltaTime);
        }
        else
        {
            if (m_Character.rootObject.transform.localPosition.x < -3)
            {
                m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(-5, 0, 0), 2f * Time.deltaTime);
            }
            else if (m_Character.rootObject.transform.localPosition.x > 3)
            {
                m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(5, 0, 0), 2f * Time.deltaTime);
            }
            else
            {
                m_Character.rootObject.transform.localPosition = Vector3.Lerp(m_Character.rootObject.transform.localPosition, new Vector3(0, 0, 0), 2f * Time.deltaTime);
            }
        }


        m_Character.transform.localPosition = Vector3.Lerp(m_Character.transform.localPosition, _tempDistance, 2f * Time.deltaTime);
        m_Character.transform.localRotation = Quaternion.Lerp(m_Character.transform.localRotation, _tempRotation, 2f * Time.deltaTime);
        // else if (laneNumber == 3)
        // {
        //     Vector3 _tempDistance = m_PathCreator1.path.GetPointAtDistance(speed);
        //     Quaternion _tempRotation = m_PathCreator1.path.GetRotationAtDistance(speed);

        //     m_Character.transform.position = Vector3.Lerp(m_Character.transform.position, _tempDistance, 3f * Time.deltaTime);
        //     m_Character.transform.rotation = Quaternion.Lerp(m_Character.transform.rotation, _tempRotation, 3f * Time.deltaTime);

        // }
        // else
        // {
        //     Vector3 _tempDistance = m_PathCreator2.path.GetPointAtDistance(speed);
        //     Quaternion _tempRotation = m_PathCreator2.path.GetRotationAtDistance(speed);

        //     m_Character.transform.position = Vector3.Lerp(m_Character.transform.position, _tempDistance, 3f * Time.deltaTime);
        //     m_Character.transform.rotation = Quaternion.Lerp(m_Character.transform.rotation, _tempRotation, 3f * Time.deltaTime);
        // }

        // m_WallClearLag.transform.position = new Vector3(m_WallClearLag.transform.position.x, m_WallClearLag.transform.position.y, m_Character.transform.position.z - 15f);

        //Test boost in unity editor
        if (Input.GetKeyDown(KeyCode.R))
        {
            ClickBoost();
        }

        if (m_IsGotMilk)
        {
            if (!m_IsBoosting)
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

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneNumber > 1 && m_IsChangeLine)
        {
            ChangeLane(-slideLength);
            laneNumber -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && laneNumber < 3 && m_IsChangeLine)
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

                //we set the swip distance to trigger movement to 1% of the screen width
                if (diff.magnitude > 0.01f)
                {
                    if (diff.x < 0 && laneNumber > 1 && m_IsChangeLine)
                    {
                        ChangeLane(-slideLength);
                        laneNumber -= 1;
                    }
                    else if (diff.x >= 0 && laneNumber < 3 && m_IsChangeLine)
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

    void Rotation(int _direction)
    {
        m_Character.rootObject.transform.localRotation = Quaternion.Euler(0, _direction * 2f, 0);
    }
    public void ClickBoost()
    {
        if (!m_IsRemainBoost)
        {

        }
        StartCoroutine(CrystalBoost());
        m_IsRemainBoost = true;
        StartCoroutine(CheckRemainBoost());
    }

    public void ChangeSpeed()
    {
        if (m_IsBoosting)
        {
            m_Character.m_CurrentSpeed += m_BoostSpeed;
        }
        else
        {
            if (m_Character.m_CurrentBottleMilk >= 1)
            {
                if (IsFirstTime)
                {
                    m_MilkCollectSpeed = m_Character.m_InitialSpeed + 5;
                    IsFirstTime = false;
                }
                else
                {
                    m_MilkCollectSpeed = (m_Character.m_InitialSpeed + (m_Character.m_CurrentBottleMilk * 5));
                }
                m_IsGotMilk = true;
            }
            if (m_Character.m_CurrentBottleMilk == 0)
            {
                m_Character.m_CurrentSpeed = m_Character.m_InitialSpeed;
            }
        }
    }

    IEnumerator CheckBoost()
    {
        // m_Character.m_CrystalBoost -= 1;
        // if (m_Character.m_CrystalBoost <= 0)
        // {
        //     m_Character.m_CurrentCrystal = 0;
        // }

        int _TimePerSec = m_TimeBoost;
        // tempt speed
        float _temp = (m_BoostSpeed - m_MilkCollectSpeed) / (_TimePerSec * m_TimeBoost);


        while (m_Character.m_CurrentSpeed > m_MilkCollectSpeed)
        {
            yield return new WaitForSeconds(1f / _TimePerSec);
            m_Character.m_CurrentSpeed -= _temp;
        }
    }

    IEnumerator CheckRemainBoost()
    {
        yield return new WaitForSeconds(3f);
        m_IsRemainBoost = false;
    }

    IEnumerator CrystalBoost()
    {

        // if (m_Character.m_CrystalBoost > 0)
        // {
        //     m_IsBoosting = true;

        //     if (m_IsBoosting)
        //     {

        //     }
        // }

        ChangeSpeed();
        StartCoroutine(CheckBoost());
        yield return new WaitForSeconds(m_TimeBoost);
        m_IsBoosting = false;
    }

    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(m_SecondChangeLine);
        m_CharacterPosition = 0;
        m_IsChangeLine = true;
        change = false;

        //stop track

        //Set animation die
    }

    IEnumerator ReturnRotation()
    {
        yield return new WaitForSeconds(m_SecondChangeLine);

        m_Character.rootObject.transform.localRotation = Quaternion.identity;
    }

    #endregion
}
