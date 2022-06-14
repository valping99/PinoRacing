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

    GameObject m_RootItem;
    List<GameObject> crystalList = new List<GameObject>();

    // [Header("Sound")]
    // public AudioClip milkSound;

    AudioSource m_Audio;

    #endregion

    #region Unity Methods

    void Awake()
    {
        m_MaxSpeed = 100f;

        m_CurrentSpeed = m_InitialSpeed;
    }

    void Start()
    {
        m_Audio = GetComponent<AudioSource>();
        m_CharacterController = GetComponentInParent<CharacterInputController>();
    }

    // Update is called once per frame
    void Update()
    {
        // CheckBoostCount();
        FixSpeedUpdate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            m_RootItem = other.gameObject;

            if (m_CharacterController.m_IsBoosting)
                m_CharacterController.m_IsBoosting = false;

            foreach (Transform child in m_RootItem.transform)
            {
                if (child.CompareTag("Fire"))
                {
                    FirePickup fire = m_RootItem.GetComponent<FirePickup>();

                    if (!m_CharacterController.m_Stuns)
                    {
                        m_CurrentSpeed = 0;
                        m_CharacterController.m_Stuns = true;
                        m_CharacterController.ChangeSpeed();
                        Debug.Log("Stun");
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

        if (other.gameObject.tag == "Item")
        {
            m_RootItem = other.gameObject;

            foreach (Transform child in m_RootItem.transform)
            {

                if (child.CompareTag("Milk"))
                {
                    MilkPickup milk = other.GetComponent<MilkPickup>();
                    if (m_CurrentSpeed > m_MaxSpeed)
                    {
                        m_CurrentBottleMilk += milk.amountMilkBottle;
                    }
                    else
                    {
                        m_CurrentBottleMilk += milk.amountMilkBottle;
                        m_CharacterController.ChangeSpeed();
                    }
                    Destroy(m_RootItem.gameObject);
                }

                if (child.CompareTag("SpeedPads"))
                {
                    SpeedPads crystal = other.GetComponent<SpeedPads>();

                    if (!m_CharacterController.m_PadsIsBoosting)
                    {
                        m_CurrentSpeed = m_MaxSpeed;
                        m_CharacterController.m_PadsIsBoosting = true;
                        m_CharacterController.ChangeSpeed();
                    }

                    Destroy(m_RootItem.gameObject);
                    // Debug.Log("Boosting");
                }

            }
        }

        // Debug.Log("Object: " + other.gameObject.name);
    }

    #endregion

    #region Class

    IEnumerator GetBoost()
    {
        yield return new WaitForSeconds(0.1f);
        // if (m_CrystalBoost == 0)
        // {
        //     m_IsEnoughBoost = false;
        // }
    }
    void CheckBoostCount()
    {
        // if (m_CurrentCrystal >= 6 && m_CrystalBoost < 1)
        // {
        //     m_CurrentCrystal = 0;
        //     m_IsEnoughBoost = true;
        //     m_CrystalBoost = 16;
        // }

        // if (m_IsEnoughBoost)
        // {
        //     StartCoroutine(GetBoost());
        // }
    }
    void FixSpeedUpdate()
    {
        if (m_CurrentSpeed <= 0 && !m_CharacterController.m_Stuns)
        {
            m_CurrentSpeed = m_InitialSpeed;
            Debug.Log("Speed is 0");
        }

        if (m_CurrentSpeed > m_MaxSpeed)
        {
            m_CurrentSpeed = m_MaxSpeed;
            Debug.Log("Speed is max");
        }
    }
    #endregion
}