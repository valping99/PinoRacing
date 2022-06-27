using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReference : MonoBehaviour
{

    [HideInInspector] public UIManager managers;
    [HideInInspector] public Character charColl;
    [HideInInspector] public CharacterController charInput;

    int currendSpeed;
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
        charColl = FindObjectOfType<Character>();
        charInput = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void StartGame()
    {
        double kphSpeed = charColl.m_CurrentSpeed * 3.6;
        currendSpeed = (int)kphSpeed;
    }
    private void UpdateUI()
    {

    }


}
