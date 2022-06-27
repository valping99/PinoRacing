using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdrop : MonoBehaviour
{
    public GameObject waterDrop;
    private UIManager managers;
    public Animator animWaterDrop;
    public CharacterInputController charInput;

    public float timeToDrip;
    public float timeToFaster = 60f;

    const string k_AnimDropWater = "WaterDrop";
    const string k_AnimStun = "Stun";
    const string k_AnimFaster = "Faster";
    public bool enableAnim = false;
    public bool fasterAnim = false;
    // Start is called before the first frame update
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
        waterDrop.gameObject.SetActive(false);
        charInput = FindObjectOfType<CharacterInputController>();
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
        if(managers.timeValueUp >= timeToDrip + timeToFaster)
        {
            fasterAnim = true;
        }
        else
        {
            fasterAnim = false;
        }
    }

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
}
