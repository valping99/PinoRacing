using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdrop : MonoBehaviour
{
    #region Variables
    private UIManager managers;

    public GameObject waterDrop;
    public Animator animWaterDrop;
    public CharacterController charInput;

    public float timeToDrip;
    public float timeToFaster = 60f;

    public bool enableAnim = false;
    public bool fasterAnim = false;

    const string k_AnimDropWater = "WaterDrop";
    const string k_AnimStun = "Stun";
    const string k_AnimFaster = "Faster";
    #endregion

    #region Unity Method
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
        waterDrop.gameObject.SetActive(false);
        charInput = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        if (managers.timeValueUp >= timeToDrip)
        {
            enableAnim = true;
        }
        else
        {
            enableAnim = false;
        }
        if (managers.timeValueUp >= timeToDrip + timeToFaster)
        {
            fasterAnim = true;
        }
        else
        {
            fasterAnim = false;
        }
    }

    #endregion

    #region Class
    void EnableWaterDrop()
    {
        waterDrop.gameObject.SetActive(true);
    }
    void DisableWaterDrop()
    {
        waterDrop.gameObject.SetActive(false);
    }

    void CheckAnimation()
    {
        animWaterDrop.SetBool(k_AnimDropWater, enableAnim);
        animWaterDrop.SetBool(k_AnimStun, charInput.m_Stuns);
        animWaterDrop.SetBool(k_AnimFaster, fasterAnim);
    }
    #endregion
}
