using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinoAnimatorRotate : MonoBehaviour
{
    #region Varibles
    [Header("Scripts")]
    public SelectManager selected;
    public Animator pinoAnimator;

    [Header("Outline")]
    public GameObject chocolateOutline;
    public GameObject almondOutline;
    public GameObject strawberryOutline;
    public GameObject stickOutline;

    [Header("Rotation")]
    public Transform chocolateCarRotation;
    public Transform almondCarRotation;
    public Transform strawberryCarRotation;

    [Header("Animator")]
    const string k_AnimRotatePino1 = "Pino1";
    const string k_AnimRotatePino2 = "Pino2";
    const string k_AnimRotatePino3 = "Pino3";
    #endregion
    #region Unity Method
    void Start()
    {
        selected = FindObjectOfType<SelectManager>();
        chocolateOutline.SetActive(false);
        almondOutline.SetActive(false);
        strawberryOutline.SetActive(false);
        stickOutline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
        CheckGlow();
    }
    #endregion
    #region Class
    void CheckAnimation()
    {
        pinoAnimator.SetBool(k_AnimRotatePino1, selected.isSelectPino_01);
        pinoAnimator.SetBool(k_AnimRotatePino2, selected.isSelectPino_02);
        pinoAnimator.SetBool(k_AnimRotatePino3, selected.isSelectPino_03);

        stickOutline.SetActive(true);
    }

    void CheckGlow()
    {
        if (selected.isSelectPino_01)
        {
            chocolateOutline.SetActive(true);
            almondOutline.SetActive(false);
            strawberryOutline.SetActive(false);
        }
        else if (selected.isSelectPino_02)
        {
            chocolateOutline.SetActive(false);
            almondOutline.SetActive(false);
            strawberryOutline.SetActive(true);
        }
        else if (selected.isSelectPino_03)
        {
            chocolateOutline.SetActive(false);
            almondOutline.SetActive(true);
            strawberryOutline.SetActive(false);
        }
        else
        {
            chocolateOutline.SetActive(false);
            almondOutline.SetActive(false);
            strawberryOutline.SetActive(false);
            stickOutline.SetActive(false);
        }
    }
    #endregion

}
