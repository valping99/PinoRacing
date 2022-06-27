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

    const string m_AnimTimer = "Timer";

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
    #region Function
    void ChangeColorStick()
    {
        animator = GameObject.FindGameObjectWithTag("GimmeckSticker").GetComponent<Animator>();
        currentSticker = GameObject.FindGameObjectWithTag("GimmeckSticker");
        uiManagers = FindObjectOfType<UIManager>();
        //charInput = FindObjectOfType<CharacterInputController>();
        //charColl = FindObjectOfType<CharacterCollider>();
        //rootObject = GameObject.FindGameObjectWithTag("RootObject");
        //Instantiate(stickGimmeck, charColl.transform.position, Quaternion.identity, transformParent);
    }

    void CheckTimeUI()
    {
        if (uiManagers.timeValueUp > 240)
        {
            animator.SetFloat(m_AnimTimer, uiManagers.timeValueUp);
        }
        //currentSticker.transform.rotation = rootObject.transform.rotation;
        //transformParent.position = charColl.transform.position;
        //transformParent.rotation = charColl.transform.rotation;
        //if (charinput.m_stuns)
        //{
        //    currentsticker.transform.position = rootobject.transform.position;
        //}
        //else
        //{
        //    currentsticker.transform.position = new vector3(rootobject.transform.position.x, rootobject.transform.position.y + 1.5f, rootobject.transform.position.z);
        //}
    }
    #endregion
}
