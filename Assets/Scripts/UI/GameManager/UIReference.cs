using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReference : MonoBehaviour
{
    #region Variables
    [HideInInspector] public UIManager managers;
    [HideInInspector] public Character charColl;
    [HideInInspector] public CharacterController charInput;
    int currendSpeed;
    #endregion
    #region Unity Method
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
        charColl = FindObjectOfType<Character>();
        charInput = FindObjectOfType<CharacterController>();
    }

    #endregion
    #region Class
    private void StartGame()
    {
        double kphSpeed = charColl.m_CurrentSpeed * 3.6;
        currendSpeed = (int)kphSpeed;
    }
    #endregion

}
