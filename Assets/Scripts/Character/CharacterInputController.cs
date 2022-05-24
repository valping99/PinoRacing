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
    [SerializeField] CharacterCollider m_CharacterCollider;
    // Variables ====
    float m_Position;

    [Header("Controls")]

    float m_InitialSpeed = 10f;
    public float m_CurrentSpeed;
    public float slideLength = 7f;

    // Get - set Items ====

    // Init number Items ====

    // Init Bool ====


    #endregion

    #region Unity Methods

    void Awake()
    {
        m_Position = 0;
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
        m_Position = 0;

        //stop track

        //Set animation die
    }

    public void End()
    {
        // Delete something... 
    }

    public void ChangeLane(float _direction)
    {
        m_Position = _direction;
    }

    void MoveInput()
    {
        m_CharacterCollider.GetComponent<Rigidbody>().velocity = new Vector3(m_Position, 0, m_CurrentSpeed);

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLane(-slideLength);
            StartCoroutine(StopMoving());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLane(slideLength);
            StartCoroutine(StopMoving());
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
						if(diff.x < 0)
						{
							ChangeLane(-slideLength);
                            StartCoroutine(StopMoving());
						}
						else
						{
							ChangeLane(slideLength);
                            StartCoroutine(StopMoving());
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
