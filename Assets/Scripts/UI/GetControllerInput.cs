using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetControllerInput : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterInputController charInput;
    public CharacterCollider charColl;
    void Start()
    {
        //charInput = FindObjectOfType<CharacterInputController>();
        //charColl = FindObjectOfType<CharacterCollider>();
        //checkInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkInput()
    {
        if(charColl.m_CharacterController == null)
        {
            charColl.m_CharacterController = charInput;
        }
    }
}
