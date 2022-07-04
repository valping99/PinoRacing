using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinoAnimatorRotate : MonoBehaviour
{
    [Header("Scripts")]
    public SelectManager selected;
    public Animator pinoAnimator;

    [Header("Outline")]
    public Outline chocolateOutline;
    public Outline almondOutline;
    public Outline strawberryOutline;
    public Outline stickOutline;

    [Header("Rotation")]
    public Transform chocolateCarRotation;
    public Transform almondCarRotation;
    public Transform strawberryCarRotation;

    [Header("Animator")]
    const string k_AnimRotatePino1 = "Pino1";
    const string k_AnimRotatePino2 = "Pino2";
    const string k_AnimRotatePino3 = "Pino3";

    // Start is called before the first frame update
    void Start()
    {
        selected = FindObjectOfType<SelectManager>();
        chocolateOutline.enabled = false;
        almondOutline.enabled = false;
        strawberryOutline.enabled = false;
        stickOutline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        CheckGlow();
    }

    void CheckAnimation()
    {
        pinoAnimator.SetBool(k_AnimRotatePino1, selected.isSelectPino_01);
        pinoAnimator.SetBool(k_AnimRotatePino2, selected.isSelectPino_02);
        pinoAnimator.SetBool(k_AnimRotatePino3, selected.isSelectPino_03);

        stickOutline.enabled = true;
    }

    void CheckGlow()
    {
        if (selected.isSelectPino_01)
        {
            chocolateOutline.enabled = true;
            almondOutline.enabled = false;
            strawberryOutline.enabled = false;
        }
        else if (selected.isSelectPino_02)
        {
            chocolateOutline.enabled = false;
            almondOutline.enabled = true;
            strawberryOutline.enabled = false;
        }
        else if (selected.isSelectPino_03)
        {
            chocolateOutline.enabled = false;
            almondOutline.enabled = false;
            strawberryOutline.enabled = true;
        }
        else
        {
            chocolateOutline.enabled = false;
            almondOutline.enabled = false;
            strawberryOutline.enabled = false;
            stickOutline.enabled = false;
        }
    }


}
