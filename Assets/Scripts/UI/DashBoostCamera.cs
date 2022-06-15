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
        if(charInput.m_IsRemainBoost)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 100, 3f * Time.deltaTime);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 70, 1f * Time.deltaTime);
        }

        if (charInput.m_PadsIsBoosting)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 100, 4f * Time.deltaTime);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 70, 1.5f * Time.deltaTime);
        }
        if (charInput.m_Stuns)
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 40, 2.5f * Time.deltaTime);
        }
        else
        {
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, 70, 1.5f * Time.deltaTime);
        }
    }
}
