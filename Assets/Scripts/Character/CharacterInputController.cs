/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    #region Variables

    // Animation =====

    // Scripts ====
    [Header("Variables")]
    UIManager uiManagers;
    public CharacterCollider m_Character;
    GameObject m_WallClearLag;
    // Variables ====

    [Header("Controls")]
    [Tooltip("The more you press, the faster the character will change lines")]
    public float m_SecondChangeLine;
    [Tooltip("Range of the character move when you swipe")]
    public int slideLength = 5;
    public float m_BoostSpeed;
    [Tooltip("Speed of the character when you click boost")]
    public bool m_IsBoosting;

    // Get - set Items ====

    // Init number Items ====
    float m_CharacterPosition;
    float m_MilkCollectSpeed;
    int m_TimeBoost;
    int laneNumber;

    // Init Bool ====
    bool m_IsChangeLine;
    bool m_IsGotMilk;
    bool IsFirstTime;
    [SerializeField] bool m_IsRemainBoost;


    #endregion

    #region Unity Methods

    void Awake()
    {
        m_MilkCollectSpeed = m_Character.m_InitialSpeed;

        laneNumber = 2; // 1 = left, 0 = middle, 2 = right
        m_CharacterPosition = 0;
        m_TimeBoost = 3;

        m_IsChangeLine = true;
        m_IsBoosting = false;
        m_IsRemainBoost = false;
        m_IsGotMilk = false;
        IsFirstTime = true;

        m_WallClearLag = GameObject.FindGameObjectWithTag("ClearLag");
        m_Character = gameObject.GetComponentInChildren<CharacterCollider>();
    }

#if !UNITY_STANDALONE
    protected Vector2 m_StartingTouch;
	protected bool m_IsSwiping = false;
#endif

    // Start is called before the first frame update
    void Start()
    {
        ChangeSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }


    #endregion

    #region Class

    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(m_SecondChangeLine);
        m_CharacterPosition = 0;
        m_IsChangeLine = true;

        //stop track

        //Set animation die
    }

    public void End()
    {
        // Delete something... 
    }

    public void ChangeLane(int _direction)
    {
        m_CharacterPosition = _direction;
        StartCoroutine(StopMoving());
        m_IsChangeLine = false;
    }

    void MoveInput()
    {
        m_Character.GetComponent<Rigidbody>().velocity = new Vector3(m_CharacterPosition, 0, m_Character.m_CurrentSpeed);

        m_WallClearLag.transform.position = new Vector3(m_WallClearLag.transform.position.x, m_WallClearLag.transform.position.y, m_Character.transform.position.z - 15f);

        //Test boost in unity editor
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!m_IsRemainBoost)
            {
                StartCoroutine(CrystalBoost());
                m_IsRemainBoost = true;
                StartCoroutine(CheckRemainBoost());
            }

        }

        if (m_IsGotMilk)
        {
            m_Character.m_CurrentSpeed = m_MilkCollectSpeed;
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
			if(m_IsSwiping)
			{
				Vector2 diff = Input.GetTouch(0).position - m_StartingTouch;

				// Put difference in Screen ratio, but using only width, so the ratio is the same on both
                // axes (otherwise we would have to swipe more vertically...)
				diff = new Vector2(diff.x/Screen.width, diff.y/Screen.width);

				if(diff.magnitude > 0.01f) //we set the swip distance to trigger movement to 1% of the screen width
				{
					else if(TutorialMoveCheck(0))
					{
						if(diff.x < 0 && laneNumber > 1 && m_IsChangeLine)
						{
							ChangeLane(-slideLength);
                        }
						else if (diff.x >= 0 && laneNumber < 3 && m_IsChangeLine)
						{
							ChangeLane(slideLength);
                        }
					}
						
					m_IsSwiping = false;
				}
            }

        	// Input check is AFTER the swip test, that way if TouchPhase.Ended happen a single frame after the Began Phase
			// a swipe can still be registered (otherwise, m_IsSwiping will be set to false and the test wouldn't happen for that began-Ended pair)
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				m_StartingTouch = Input.GetTouch(0).position;
				m_IsSwiping = true;
			}
			else if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				m_IsSwiping = false;
			}
        }
#endif
    }

    public void ChangeSpeed()
    {
        if (m_IsBoosting)
        {
            m_Character.m_CurrentSpeed += m_BoostSpeed;
        }

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
            Debug.Log("Speed up: " + m_Character.m_CurrentSpeed);
        }
        // else if (m_Character.m_CurrentBottleMilk >= 2)
        // {
        //     m_MilkCollectSpeed = m_Character.m_InitialSpeed * m_Character.m_CurrentBottleMilk;
        //     m_IsGotMilk = true;
        //     Debug.Log("Speed up: " + m_Character.m_CurrentSpeed);
        // }


    }

    IEnumerator CrystalBoost()
    {

        if (m_Character.m_CrystalBoost > 0)
        {
            m_IsBoosting = true;

            if (m_IsBoosting)
            {
                ChangeSpeed();
                StartCoroutine(CheckBoost());
                yield return new WaitForSeconds(1f);
                m_IsBoosting = false;
            }
        }
    }

    IEnumerator CheckBoost()
    {
        m_Character.m_CrystalBoost -= 1;
        if (m_Character.m_CrystalBoost <= 0)
        {
            m_Character.m_CurrentCrystal = 0;
        }

        int _TimePerSec = m_TimeBoost;
        float _temp = (m_BoostSpeed - m_MilkCollectSpeed) / (_TimePerSec * m_TimeBoost); // tempt speed


        while (m_Character.m_CurrentSpeed > m_MilkCollectSpeed)
        {
            yield return new WaitForSeconds(1f / _TimePerSec);
            m_Character.m_CurrentSpeed -= _temp;
        }

        ChangeSpeed();
    }

    IEnumerator CheckRemainBoost()
    {
        yield return new WaitForSeconds(3f);
        m_IsRemainBoost = false;
    }

    #endregion
}
