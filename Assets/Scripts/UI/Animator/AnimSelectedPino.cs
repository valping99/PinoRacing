using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSelectedPino : MonoBehaviour
{
    #region Variables
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
    #endregion
    // Start is called before the first frame update
    #region Unity Method
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
            }
            else if (selected.isSelectPino_02)
            {
                animator.SetTrigger(k_AnimIsPino2_Trig);
            }
            else if(selected.isSelectPino_03)
            {
                animator.SetTrigger(k_AnimIsPino3_Trig);
            }
        }
        else
        {
            if (selected.isSelectPino_01)
            {

                animator.SetTrigger(k_AnimIsPino1_Trig);
                animator.ResetTrigger(k_AnimIsPino2_Trig);
                animator.ResetTrigger(k_AnimIsPino3_Trig);
            }
            else if (selected.isSelectPino_02)
            {
                animator.SetTrigger(k_AnimIsPino2_Trig);
                animator.ResetTrigger(k_AnimIsPino1_Trig);
                animator.ResetTrigger(k_AnimIsPino3_Trig);
            }
            else if(selected.isSelectPino_03)
            {
                animator.SetTrigger(k_AnimIsPino3_Trig);
                animator.ResetTrigger(k_AnimIsPino2_Trig);
                animator.ResetTrigger(k_AnimIsPino1_Trig);
            }
        }
    }
    #endregion
    void CheckAnimation()
    {
        animator.SetBool(k_AnimNoAnim, none);
        //animator.SetBool(k_AnimIsPino1, isSelect1);
        //animator.SetBool(k_AnimIsPino2, isSelect2);
        //animator.SetBool(k_AnimIsPino3, isSelect3);
    }
}
