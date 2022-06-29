using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    CharacterController charColl;

    public bool checkCrash;
    [Header("Animator")]
    const string k_AnimCrash = "isCrash";
    // Start is called before the first frame update
    void Start()
    {
        charColl = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        checkCrash = charColl.m_Stuns;
        animator.SetBool(k_AnimCrash, checkCrash);
    }
}
