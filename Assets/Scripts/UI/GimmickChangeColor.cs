using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickChangeColor : MonoBehaviour
{
    #region Variables
    public CharacterCollider charColl;
    public Transform transformParent;
    public GameObject stickGimmeck;
    public GameObject currentSticker;
    public GameObject rootObject;

    public UIManager uiManagers;

    [Tooltip("Animator")]
    public Animator animator;

    const string m_AnimTimer = "Timer";

    #endregion
    #region Unity Method

    void Start()
    {
        ChangeColorStick();
        animator = GameObject.FindGameObjectWithTag("GimmeckSticker").GetComponent<Animator>();
        currentSticker = GameObject.FindGameObjectWithTag("GimmeckSticker");
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
        uiManagers = FindObjectOfType<UIManager>();
        charColl = FindObjectOfType<CharacterCollider>();
        rootObject = GameObject.FindGameObjectWithTag("RootObject");
        Instantiate(stickGimmeck, charColl.transform.position, Quaternion.identity, transformParent);
    }

    void CheckTimeUI()
    {
        if(uiManagers.timeValueUp > 240)
        {
            animator.SetFloat(m_AnimTimer, uiManagers.timeValueUp);
        }
        currentSticker.transform.position =new Vector3(rootObject.transform.position.x, rootObject.transform.position.y + .7f, rootObject.transform.position.z);
        transformParent.position = rootObject.transform.position;
        transformParent.rotation = rootObject.transform.rotation;
    }
    #endregion
}
