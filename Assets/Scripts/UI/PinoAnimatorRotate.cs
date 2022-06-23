using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinoAnimatorRotate : MonoBehaviour
{
    public SelectManager selected;
    public Animator pinoAnimator;

    [Tooltip("Animator")]
    const string k_AnimRotatePino1 = "Pino1";
    const string k_AnimRotatePino2 = "Pino2";
    const string k_AnimRotatePino3 = "Pino3";
    // Start is called before the first frame update
    void Start()
    {
        selected = FindObjectOfType<SelectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAnimation();
    }

    void CheckAnimation()
    {
        pinoAnimator.SetBool(k_AnimRotatePino1, selected.isSelectPino_01);
        pinoAnimator.SetBool(k_AnimRotatePino2, selected.isSelectPino_02);
        pinoAnimator.SetBool(k_AnimRotatePino3, selected.isSelectPino_03);
    }

}
