/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour
{
    UIManager uiManagers;
    #region Variables

    // Animation =====

    // Scripts ====
    [SerializeField] CharacterCollider m_CharacterCollider;
    // Variables ====
    float m_CharacterPosition;

    [Header("Controls")]

    float m_InitialSpeed = 10f;
    int laneNumber = 2;
    public float m_CurrentSpeed;
    public int slideLength = 5;
    public double Speed;

    // Get - set Items ====

    // Init number Items ====

    // Init Bool ====


    #endregion

    #region Unity Methods

    void Awake()
    {
        m_CharacterPosition = 0;
        m_CurrentSpeed = m_InitialSpeed;
    }

#if !UNITY_STANDALONE
    protected Vector2 m_StartingTouch;
	protected bool m_IsSwiping = false;
#endif

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
    }


    #endregion

    #region Class

    public void Init()
    {


        //Set Hp for Pino

        //Init audio

        //Init obstacle
    }


    public void Begin()
    {
        //Set animaton run

        //Init Collider


    }

    public void StartMoving()
    {

    }

    public void StartRunning()
    {


    }

    IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(0.5f);
        m_CharacterPosition = 0;

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
    }

    void MoveInput()
    {
        m_CharacterCollider.GetComponent<Rigidbody>().velocity = new Vector3(m_CharacterPosition, 0, m_CurrentSpeed);
        Speed = m_CurrentSpeed * 3.6f;
        uiManagers.speedRun = Speed;
        uiManagers.kphText.text = Speed + "kph";
#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneNumber > 1)
        {
            ChangeLane(-slideLength);
            laneNumber -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && laneNumber < 3)
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
						if(diff.x < 0 && laneNumber > 1)
						{
							ChangeLane(-slideLength);
						}
						else if (diff.x >= 0 && laneNumber < 3)
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
    #endregion
}
