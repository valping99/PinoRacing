using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBoostCamera : MonoBehaviour
{
    [SerializeField]
    private CharacterInputController charInput;

    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        charInput = FindObjectOfType<CharacterInputController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charInput.m_IsBoosting == true)
        {
            mainCamera.fieldOfView = 90;
            Debug.Log("isboost");
        }
        else if(charInput.m_IsBoosting == false)
        {
            mainCamera.fieldOfView = 70;
            Debug.Log("none");
        }
    }
}
