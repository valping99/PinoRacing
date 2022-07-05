using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetControllerInput : MonoBehaviour
{
    #region Variables
    public CharacterController charInput;
    public Character charColl;
    #endregion
    #region Unity Method
    void Awake()
    {
        charColl = FindObjectOfType<Character>();
        charInput = (CharacterController)FindObjectOfType(typeof(CharacterController));
        checkInput();
    }
    #endregion
    #region Class

    void checkInput()
    {
        if (charColl.m_CharacterController == null && charInput.m_Character == null)
        {
            charInput.m_Character = charColl;
            charColl.m_CharacterController = charInput;
        }
    }
    #endregion
}
