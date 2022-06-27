using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIReference : MonoBehaviour
{

    [HideInInspector] public UIManager managers;
    [HideInInspector] public CharacterCollider charColl;
    [HideInInspector] public CharacterInputController charInput;

    int currendSpeed;
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
        charColl = FindObjectOfType<CharacterCollider>();
        charInput = FindObjectOfType<CharacterInputController>();
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
