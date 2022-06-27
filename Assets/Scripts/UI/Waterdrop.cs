using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdrop : MonoBehaviour
{
    public GameObject waterDrop;
    private UIManager managers;
    public Animator animWaterDrop;
    public CharacterController charInput;

    public float timerToDrip;

    const string k_AnimDropWater = "WaterDrop";
    const string k_AnimStun = "Stun";
    public bool enableAnim = false;
    // Start is called before the first frame update
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
        if (managers.timeValueUp >= timerToDrip)
        {
            enableAnim = true;
        }
        else
        {
            enableAnim = false;
        }
        if (managers.timeValueUp >= timerToDrip + 60f)
        {
            animWaterDrop.speed += 0.005f * Time.deltaTime;
        }
    }

    void CheckAnimation()
    {
        animWaterDrop.SetBool(k_AnimDropWater, enableAnim);
        animWaterDrop.SetBool(k_AnimStun, charInput.m_Stuns);
    }
}
