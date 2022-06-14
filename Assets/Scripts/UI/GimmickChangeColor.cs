using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickChangeColor : MonoBehaviour
{
    public CharacterCollider charColl;
    public Transform transformParent;
    public GameObject stickGimmeck;
    public GameObject rootObject;

    public UIManager uiManagers;

    [Tooltip("Animator")]
    public Animator animator;

    public GameObject currentSticker;
    const string m_AnimTimer = "Timer";
    // Start is called before the first frame update
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

    void ChangeColorStick()
    {
        uiManagers = FindObjectOfType<UIManager>();
        charColl = FindObjectOfType<CharacterCollider>();
        rootObject = GameObject.FindGameObjectWithTag("RootObject");
        Instantiate(stickGimmeck, charColl.transform.position, Quaternion.identity, transformParent);
    }

    void CheckTimeUI()
    {
        if(uiManagers.timeValueUp > 270)
        {
            animator.SetFloat(m_AnimTimer, uiManagers.timeValueUp);
        }
        currentSticker.transform.position = charColl.transform.position;
        transformParent.position = rootObject.transform.position;
        transformParent.rotation = rootObject.transform.rotation;
    }
   
}
