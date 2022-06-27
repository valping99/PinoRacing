using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetControllerInput : MonoBehaviour
{
    // Start is called before the first frame update

    public CharacterInputController charInput;
    public Character charColl;
    void Awake()
    {
        charColl = FindObjectOfType<Character>();
        charInput = (CharacterInputController)FindObjectOfType(typeof(CharacterInputController));
        checkInput();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void checkInput()
    {
        if (charColl.m_CharacterController == null && charInput.m_Character == null)
        {
            charInput.m_Character = charColl;
            charColl.m_CharacterController = charInput;
        }
    }
}
