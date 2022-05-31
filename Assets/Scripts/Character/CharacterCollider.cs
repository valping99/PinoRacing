/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles everything related to the collider of the character. This is actually an empty game object, NOT on the character prefab
/// as for gameplay reason, we need a single size collider for every character.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class CharacterCollider : MonoBehaviour
{

    #region Variables

    [Header("Variables")]
    public CharacterInputController m_CharacterController;

    [Header("Items")]
    public int m_CurrentCrystal;
    public int m_CurrentBottleMilk;
    public int m_CrystalBoost;


    [Header("Initial Values")]
    [Tooltip("Speed initial of the character")]
    public float m_InitialSpeed;
    [Tooltip("Initial Def of the character")]
    public int m_InitialDef;
    [Tooltip("Initial Stamina of the character")]
    public int m_InitialStamina;

    [Header("Controls")]
    public float m_CurrentSpeed;
    public float m_CurrentStamina;
    public bool m_IsEnoughBoost;

    int m_InitialCrystal;
    GameObject m_RootItem;
    List<GameObject> crystalList = new List<GameObject>();


    // [Header("Sound")]
    // public AudioClip milkSound;

    AudioSource m_Audio;

    #endregion

    #region Unity Methods

    void Awake()
    {
        m_InitialCrystal = 0;
        m_CrystalBoost = 0;

        m_CurrentCrystal = m_InitialCrystal;
        m_CurrentSpeed = m_InitialSpeed;
        m_CurrentStamina = m_InitialStamina;
    }

    void Start()
    {
        // m_Collider = GetComponent<BoxCollider>();
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // m_CharacterController.BoostAvailable();
        CheckBoostCount();
        FixSpeedUpdate();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            // Debug.Log("Collision with obstacle");
            m_RootItem = other.gameObject;

            foreach (Transform child in m_RootItem.transform)
            {
                if (child.CompareTag("Fire"))
                {
                    FirePickup fire = m_RootItem.GetComponent<FirePickup>();
                    // Debug.Log("Collision with fire");
                    // m_CurrentSpeed -= fire.LostSpeed;

                    m_CurrentStamina -= fire.HurtAmount;

                    // m_CharacterController.ChangeSpeed();
                    Destroy(m_RootItem.gameObject);
                }
                if (child.CompareTag("Water"))
                {
                    WaterPickup water = m_RootItem.GetComponent<WaterPickup>();
                    // Debug.Log("Collision with water");
                    // m_CurrentSpeed -= water.LostSpeed;

                    m_CurrentStamina -= water.HurtAmount;

                    // m_CharacterController.ChangeSpeed();
                    Destroy(m_RootItem.gameObject);
                }
                if (child.CompareTag("Stick"))
                {
                    StickPickup stick = m_RootItem.GetComponent<StickPickup>();
                    // Debug.Log("Collision with stick");
                    m_CurrentBottleMilk -= stick.StickAmount;

                    if (m_CurrentBottleMilk <= 0)
                    {
                        m_CurrentBottleMilk = 0;
                        // m_CurrentSpeed = m_InitialSpeed;
                        m_CurrentSpeed = Mathf.Lerp(m_CurrentSpeed, m_InitialSpeed, 5f);
                        m_CharacterController.m_MilkCollectSpeed = Mathf.Lerp(m_CharacterController.m_MilkCollectSpeed, m_InitialSpeed, 5f);
                        // Debug.Log("Speed is " + m_CurrentSpeed);
                        // Debug.Log("Speed:  " + m_CharacterController.m_MilkCollectSpeed);
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
                if (child.CompareTag("Crystal"))
                {
                    if (m_CrystalBoost < 1)
                    {
                        m_CurrentCrystal += 1;
                        Destroy(m_RootItem.gameObject);
                    }
                }
                if (child.CompareTag("Milk"))
                {
                    MilkPickup milk = other.GetComponent<MilkPickup>();

                    m_CurrentBottleMilk += milk.amountMilkBottle;
                    m_CharacterController.ChangeSpeed();

                    Destroy(m_RootItem.gameObject);
                }
                if (child.CompareTag("Choco"))
                {
                    // Refill stamina
                    m_CurrentStamina += 10;
                    Destroy(m_RootItem.gameObject);
                }
            }
        }
    }


    #endregion

    #region Class

    void CheckBoostCount()
    {
        if (m_CurrentCrystal >= 6 && m_CrystalBoost < 1)
        {
            m_CurrentCrystal = 0;
            m_IsEnoughBoost = true;
            m_CrystalBoost = 16;
        }

        if (m_IsEnoughBoost)
        {
            StartCoroutine(GetBoost());
        }
    }

    IEnumerator GetBoost()
    {
        yield return new WaitForSeconds(0.1f);
        if (m_CrystalBoost == 0)
        {
            m_IsEnoughBoost = false;
            // m_CrystalBoost = 16; // BUG!!
        }
    }

    void FixSpeedUpdate()
    {
        if (m_CurrentSpeed <= 0)
        {
            m_CurrentSpeed = m_InitialSpeed;
        }
    }
    #endregion
}