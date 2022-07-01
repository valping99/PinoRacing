using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSelectedPino : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        if(isSelect1)
        {
            isSelect2 = false;
            isSelect3 = false;
        }else if (isSelect2)
        {
            isSelect1 = false;
            isSelect3 = false;
        }
        else if(isSelect3)
        {
            isSelect2 = false;
            isSelect1 = false;
        }
        else
        {
            isSelect1 = false;
            isSelect2 = false;
            isSelect3 = false;
        }
    }
    void CheckAnimation()
    {
        animator.SetBool(k_AnimNoAnim, none);
        animator.SetBool(k_AnimIsPino1, isSelect1);
        animator.SetBool(k_AnimIsPino2, isSelect2);
        animator.SetBool(k_AnimIsPino3, isSelect3);
    }
}
