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

    public CharacterInputController controller;

    // [Header("Sound")]
    // public AudioClip milkSound;
    // public AudioClip premiumSound;

    BoxCollider m_Collider;
    AudioSource m_Audio;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update

    public void Init()
    {
        
    }

    void Start()
    {
        m_Collider = GetComponent<BoxCollider>();
        m_Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    #endregion

    #region Class

    #endregion
}
