using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdrop : MonoBehaviour
{
    #region Variables
    private UIManager managers;

    [SerializeField] private Animator animWaterDrop;
    [SerializeField] private GameObject waterDrop;
    [SerializeField] private CharacterController charInput;
    [SerializeField] private Character m_Char;

    public float timeToDrip;
    [SerializeField] private float TimedStage1;
    [SerializeField] private float TimedStage2;
    [SerializeField] private float timeToFaster;
    [HideInInspector] private int SelectedStage;

    public bool enableAnim = false;
    public bool fasterAnim = false;
    private bool activeAnim = true;
    [SerializeField] private GameObject rootObject;

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
        TimeToDrip();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        if (activeAnim == true && managers.timeValueUp >= timeToDrip)
        {
            enableAnim = true;
            activeAnim = false;
        }
        if (managers.timeValueUp >= timeToDrip + timeToFaster)
        {
            fasterAnim = true;
        }
        else
        {
            fasterAnim = false;
        }
        if (enableAnim)
        {
            waterDrop.gameObject.SetActive(true);
        }
        else
        {

            waterDrop.gameObject.SetActive(false);
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

    void TimeToDrip()
    {
        SelectedStage = SelectManager.selectedStage;
        Debug.Log(SelectedStage);
        if(SelectedStage == 1)
        {
            timeToDrip = TimedStage1;
        }
        else
        {
            timeToDrip = TimedStage2;
        }
    }
    #endregion
}
