using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterdrop : MonoBehaviour
{
    public GameObject waterDrop;
    private UIManager managers;
    public Animator animWaterDrop;

    public float timerToDrip;

    const string k_AnimDropWater = "WaterDrop";
    public bool enableAnim = false;
    // Start is called before the first frame update
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
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
    }

    void CheckAnimation()
    {
        animWaterDrop.SetBool(k_AnimDropWater, enableAnim);
    }
}
