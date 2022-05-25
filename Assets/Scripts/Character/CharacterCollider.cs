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

    int m_InitialCrystal;
    public int m_CurrentCrystal;

    public CharacterInputController controller;

    // [Header("Sound")]
    // public AudioClip milkSound;
    // public AudioClip premiumSound;

    // BoxCollider m_Collider;
    AudioSource m_Audio;

    #endregion

    #region Unity Methods

    void Awake()
    {
        m_InitialCrystal = 0;
        m_CurrentCrystal = m_InitialCrystal;
    }


    public void Init()
    {

    }

    void Start()
    {
        // m_Collider = GetComponent<BoxCollider>();
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BoostAvailable();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collision with obstacle");
        }

        if (other.gameObject.tag == "Item")
        {
            // Debug.Log("Collision with Item");

            if (other.gameObject.name == "Loot_Milk")
            {
                controller.m_CurrentSpeed += 2;
            }
            if (other.gameObject.name == "Loot_Choco")
            {
                // Refill health
                Debug.Log("Pickup_Choco");
            }
            if (other.gameObject.name == "Loot_Crystal")
            {
                Debug.Log("Collision with Crystal");
                Destroy(other.gameObject);
                m_CurrentCrystal += 1;
            }
        }

    }


    #endregion

    #region Class

    void BoostAvailable()
    {
        if (m_CurrentCrystal != 16)
            return;

        controller.m_CurrentSpeed *= 2;

    }
    #endregion
}