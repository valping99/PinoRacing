/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollider : MonoBehaviour
{

    #region Variables

    [Header("Variables")]
    public CharacterInputController m_CharacterController;
    public GameObject rootObject;

    [Header("Items")]
    public int m_CurrentCrystal;
    public int m_CurrentBottleMilk;
    public int m_CrystalBoost;


    [Header("Initial Values")]

    [Tooltip("Max speed of the character")]
    public float m_MaxSpeed;
    [Tooltip("Initial Velocity of the character")]
    public int m_InitialVelocity;
    [Tooltip("Speed initial of the character - min speed")]
    public float m_InitialSpeed;

    [Header("Controls")]
    public float m_CurrentSpeed;
    public float m_MinSpeed;
    public float m_CurrentStamina;
    public bool m_IsEnoughBoost;

    [HideInInspector] public bool m_Stuns;

    GameObject m_RootItem;
    List<GameObject> crystalList = new List<GameObject>();

    // [Header("Sound")]
    // public AudioClip milkSound;

    AudioSource m_Audio;

    #endregion

    #region Unity Methods

    void Awake()
    {
        m_CurrentSpeed = m_InitialSpeed;
    }

    void Start()
    {
        m_Stuns = false;

        GetComponentInGame();
    }

    void FixedUpdate()
    {
        // CheckBoostCount();
        // FixSpeedUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        try
        {
            Obstacles(other);

            Item(other);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Error: " + ex.Message);
            Debug.Log("Object: " + other.gameObject.name);
        }
    }

    #endregion

    #region Class
    void Obstacles(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {

            m_CharacterController.m_PadsIsBoosting = false;

            m_RootItem = other.gameObject;

            if (m_CharacterController.m_IsBoosting)
                m_CharacterController.m_IsBoosting = false;

            if (m_CharacterController.m_IsRemainBoost)
                m_CharacterController.m_IsRemainBoost = false;

            foreach (Transform child in m_RootItem.transform)
            {
                if (child.CompareTag("Fire"))
                {
                    FirePickup fire = m_RootItem.GetComponent<FirePickup>();

                    if (!m_CharacterController.m_Stuns)
                    {
                        m_CurrentSpeed = 0;
                        m_CharacterController.m_MilkCollectSpeed = 0;

                        m_CharacterController.m_Stuns = true;
                        m_CharacterController.ChangeSpeed();
                    }

                    Destroy(m_RootItem.gameObject);
                }
                if (child.CompareTag("Stick"))
                {
                    StickPickup stick = m_RootItem.GetComponent<StickPickup>();
                    m_CurrentBottleMilk -= stick.StickAmount;

                    if (m_CurrentBottleMilk <= 0)
                    {
                        m_CurrentBottleMilk = 0;
                        m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, m_InitialSpeed, 5f);
                        m_CharacterController.m_MilkCollectSpeed = Mathf.Lerp(m_CharacterController.m_MilkCollectSpeed, m_InitialSpeed, 5f);
                    }

                    if (m_CurrentSpeed > m_InitialSpeed)
                    {
                        m_CurrentSpeed -= stick.HurtAmount;
                    }
                    m_CharacterController.ChangeSpeed();

                    Destroy(m_RootItem.gameObject);
                }

            }
        }
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
                    MilkPickup milk = other.GetComponent<MilkPickup>();

                    m_CurrentBottleMilk += milk.amountMilkBottle;
                    m_CharacterController.ChangeSpeed();

                    Destroy(m_RootItem.gameObject);
                }

                if (child.CompareTag("SpeedPads"))
                {
                    SpeedPads crystal = other.GetComponent<SpeedPads>();

                    if (!m_CharacterController.m_PadsIsBoosting)
                    {
                        if (m_CurrentSpeed < m_MaxSpeed)
                            m_CurrentSpeed = m_MaxSpeed;

                        m_CharacterController.m_PadsIsBoosting = true;
                        m_CharacterController.ChangeSpeed();
                    }

                    Destroy(m_RootItem.gameObject);
                }

            }
        }
    }
    void GetComponentInGame()
    {
        m_Audio = GetComponent<AudioSource>();
        m_CharacterController = GetComponentInParent<CharacterInputController>();
    }
    // void FixSpeedUpdate()
    // {
    //     if (m_CurrentSpeed <= m_InitialSpeed && !m_Stuns)
    //     {
    //         m_CurrentSpeed = m_InitialSpeed;
    //     }
    // }
    #endregion
}