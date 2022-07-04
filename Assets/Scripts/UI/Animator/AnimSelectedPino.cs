using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSelectedPino : MonoBehaviour
{
    public SelectManager selected;

    public bool none = true;
    public bool isSelect1 = false;
    public bool isSelect2 = false;
    public bool isSelect3 = false;

    public Animator animator;


    [Tooltip("Animator")]
    const string k_AnimNoAnim = "NoSelect";
    const string k_AnimIsPino1 = "Select_1";
    const string k_AnimIsPino2 = "Select_2";
    const string k_AnimIsPino3 = "Select_3";

    const string k_AnimIsPino1_Trig = "Pino_1_Trig";
    const string k_AnimIsPino2_Trig = "Pino_2_Trig";
    const string k_AnimIsPino3_Trig = "Pino_3_Trig";
    // Start is called before the first frame update
    void Start()
    {
        selected = FindObjectOfType<SelectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        if(selected.isSelectPino_01 == false && selected.isSelectPino_02 == false && selected.isSelectPino_03 == false)
        {
            if (selected.isSelectPino_01)
            {
                animator.SetTrigger(k_AnimIsPino1_Trig);
                Debug.Log("Trig1");
            }
            else if (selected.isSelectPino_02)
            {
                animator.SetTrigger(k_AnimIsPino2_Trig);
                Debug.Log("Trig2");
            }
            else
            {
                animator.SetTrigger(k_AnimIsPino3_Trig);
                Debug.Log("Trig3");
            }
        }
        else
        {
            if (selected.isSelectPino_01)
            {

                animator.SetTrigger(k_AnimIsPino1_Trig);
                animator.ResetTrigger(k_AnimIsPino2_Trig);
                animator.ResetTrigger(k_AnimIsPino3_Trig);
                Debug.Log("Trigggggg1");
            }
            else if (selected.isSelectPino_02)
            {
                animator.SetTrigger(k_AnimIsPino2_Trig);
                animator.ResetTrigger(k_AnimIsPino1_Trig);
                animator.ResetTrigger(k_AnimIsPino3_Trig);
                Debug.Log("Trigggggg2");
            }
            else
            {
                animator.SetTrigger(k_AnimIsPino3_Trig);
                animator.ResetTrigger(k_AnimIsPino2_Trig);
                animator.ResetTrigger(k_AnimIsPino1_Trig);
                Debug.Log("Trigggggg3");
            }
        }
        //if(isSelect1)
        //{
        //    isSelect2 = false;
        //    isSelect3 = false;
        //}else if (isSelect2)
        //{
        //    isSelect1 = false;
        //    isSelect3 = false;
        //}
        //else if(isSelect3)
        //{
        //    isSelect2 = false;
        //    isSelect1 = false;
        //}
        //else
        //{
        //    isSelect1 = false;
        //    isSelect2 = false;
        //    isSelect3 = false;
        //}
    }
    void CheckAnimation()
    {
        animator.SetBool(k_AnimNoAnim, none);
        //animator.SetBool(k_AnimIsPino1, isSelect1);
        //animator.SetBool(k_AnimIsPino2, isSelect2);
        //animator.SetBool(k_AnimIsPino3, isSelect3);
    }
}
