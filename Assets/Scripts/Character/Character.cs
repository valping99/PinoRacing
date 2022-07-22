using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region Variables

    [Header("Variables")]
    public GameObject[] wheelCream;
    public CharacterController m_CharacterController;
    public Animator animStuns;
    public Animator animShadow;


    [Header("Items")]
    public GameObject m_CarShadow;
    public GameObject rootObject;
    public GameObject childRootObject;
    public GameObject m_MilkPrefabs;

    [Header("Initial Values"), Tooltip("Initial acceleration of the character"), Range(0, 5)]
    public int m_InitialAcceleration;
    [Tooltip("Speed initial of the character - min speed"), Range(0, 300)]
    public float m_InitialSpeed;
    [Tooltip("Max speed of the character"), Range(0, 300)]
    public float m_MaxSpeed;

    [Header("Controls")]
    [Range(0, 10)] public int m_CurrentBottleMilk;
    [Range(0, 300)] public float m_CurrentSpeed;
    public bool m_IsEnoughBoost;
    public bool m_Stuns;
    public bool m_Engine;

    [Range(0, 300)] float m_SpeedMilk;
    [Range(0, 300)] float m_InitialMaxSpeed;
    GameObject m_RootItem;
    AudioSource m_Audio;

    #endregion

    #region Unity Methods

    void Start()
    {
        GetComponentInGame();
        InitialComponent();
    }

    void FixedUpdate()
    {
        FixSpeedUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        try
        {
            Obstacles(other);
            Item(other);
            Sound(other);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Error: " + ex.Message);
            Debug.Log("Object: " + other.gameObject.name);
        }
    }

    #endregion

    #region Class
    void GetComponentInGame()
    {
        m_CharacterController = GetComponentInParent<CharacterController>();
        m_Audio = GetComponent<AudioSource>();
    }
    void InitialComponent()
    {
        m_Stuns = false;

        m_InitialMaxSpeed = m_MaxSpeed;
        m_CurrentSpeed = m_InitialSpeed;

        m_SpeedMilk = 0.05f;
    }
    void Obstacles(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            m_CharacterController.m_UpSpeed = true;
            m_CharacterController.m_PadsIsBoosting = false;

            m_RootItem = other.gameObject;

            if (m_CharacterController.m_IsBoosting)
                m_CharacterController.m_IsBoosting = false;

            if (m_CharacterController.m_IsRemainBoost)
                m_CharacterController.m_IsRemainBoost = false;

            foreach (Transform child in m_RootItem.transform)
            {
                if (child.CompareTag("Ice"))
                {
                    m_CharacterController.stunTimer = 10;

                    MediatorPlayer.DisableEngineSound();

                    if (!m_CharacterController.m_Stuns)
                    {
                        m_CurrentSpeed = m_InitialSpeed;
                        m_CharacterController.m_CurrentSpeed = m_InitialSpeed;

                        m_CharacterController.m_Stuns = true;
                        m_CharacterController.ChangeSpeed();

                        if (m_CurrentBottleMilk <= 0)
                            m_MaxSpeed = m_InitialMaxSpeed;

                    }

                    Destroy(m_RootItem.gameObject);
                    Invoke("EnableEngine", 4f);
                }

                if (child.CompareTag("Stick"))
                {
                    StickPickup stick = m_RootItem.GetComponent<StickPickup>();
                    if (m_CurrentBottleMilk >= 2)
                    {
                        m_CurrentBottleMilk -= stick.StickAmount;

                        Instantiate(m_MilkPrefabs, new Vector3(rootObject.transform.position.x + (m_CharacterController.slideLength / 2), rootObject.transform.position.y + 2f, rootObject.transform.position.z),
                        rootObject.transform.rotation);
                        Instantiate(m_MilkPrefabs, new Vector3(rootObject.transform.position.x - (m_CharacterController.slideLength / 2), rootObject.transform.position.y + 2f, rootObject.transform.position.z),
                        rootObject.transform.rotation);
                    }
                    else if (m_CurrentBottleMilk == 1)
                    {
                        m_CurrentBottleMilk -= 1;
                        Instantiate(m_MilkPrefabs, new Vector3(rootObject.transform.position.x, rootObject.transform.position.y + 2f, rootObject.transform.position.z),
                        rootObject.transform.rotation);
                    }

                    if (m_CurrentBottleMilk <= 0)
                    {
                        m_CurrentBottleMilk = 0;
                        m_MaxSpeed = m_InitialMaxSpeed;
                    }
                    m_CharacterController.ChangeSpeed();

                    MediatorPlayer.GetMilk();
                    Destroy(m_RootItem.gameObject);
                }

            }
        }
    }

    void EnableEngine()
    {
        m_Engine = true;
    }
    void Item(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            m_RootItem = other.gameObject;

            foreach (Transform child in m_RootItem.transform)
            {

                if (child.CompareTag("Milk"))
                {
                    m_CharacterController.m_UpSpeed = true;

                    MilkPickup milk = other.GetComponent<MilkPickup>();

                    if (m_CurrentBottleMilk < 10)
                    {
                        m_CurrentBottleMilk += milk.amountMilkBottle;
                    }
                    m_CharacterController.ChangeSpeed();

                    MediatorPlayer.GetMilk();
                    Destroy(m_RootItem.gameObject);
                }

                if (child.CompareTag("SpeedPads"))
                {
                    m_CharacterController.padTimer = m_CharacterController.delay;

                    if (m_CurrentSpeed < m_MaxSpeed)
                        m_CurrentSpeed = m_MaxSpeed;

                    m_CharacterController.m_PadsIsBoosting = true;

                    Destroy(m_RootItem.gameObject);
                }

            }
        }
    }

    void Sound(Collider other)
    {
        if (other.gameObject.name == "New Game Object")
        {
            m_RootItem = other.gameObject;
            Destroy(m_RootItem.gameObject);
        }
    }
    void FixSpeedUpdate()
    {
        if (m_CharacterController.m_UpSpeed)
        {
            m_CharacterController.m_UpSpeed = false;

            StartCoroutine(SpeedUp());
        }

    }
    IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(.01f);
        m_MaxSpeed = (m_InitialMaxSpeed * m_SpeedMilk * m_CurrentBottleMilk) + m_InitialMaxSpeed;
    }
    #endregion
}