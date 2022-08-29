using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickChangeColor : MonoBehaviour
{
    #region Variables
    //public CharacterCollider charColl;
    //public Transform transformParent;
    //public GameObject stickGimmeck;
    //public GameObject rootObject;
    //public CharacterInputController charInput;

    [Tooltip("Variables")]
    public GameObject currentSticker;
    public UIManager uiManagers;
    public Animator animator;
    public bool warning;
    const string m_AnimTimer = "CheckTimer";

    #endregion
    #region Unity Method

    void Start()
    {
        ChangeColorStick();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeUI();
    }
    #endregion
    #region Class
    void ChangeColorStick()
    {
        animator = GameObject.FindGameObjectWithTag("GimmeckSticker").GetComponent<Animator>();
        currentSticker = GameObject.FindGameObjectWithTag("GimmeckSticker");
        uiManagers = FindObjectOfType<UIManager>();
    }

    void CheckTimeUI()
    {
        if (uiManagers.timeValueUp > uiManagers.timeToWarning)
        {
            warning = true;
            animator.SetBool(m_AnimTimer, warning);
            //animator.SetFloat(m_AnimTimer, uiManagers.timeValueUp);
        }
    }
    #endregion
}
