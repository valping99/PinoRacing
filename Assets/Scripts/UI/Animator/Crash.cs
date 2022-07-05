using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Animator animator;

    CharacterController charColl;

    public bool checkCrash;
    [Header("Animator")]
    const string k_AnimCrash = "isCrash";
    #endregion
    #region Unity Method
    void Start()
    {
        charColl = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkCrash = charColl.m_Stuns;
        animator.SetBool(k_AnimCrash, checkCrash);
    }
    #endregion
}
