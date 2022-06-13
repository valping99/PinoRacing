using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickChangeColor : MonoBehaviour
{
    public CharacterCollider charColl;
    public Transform transformParent;
    public GameObject stickGimmeck;
    public GameObject rootObjects;

    public UIManager uiManagers;

    [Tooltip("Animator")]
    public Animator animator;
    const string m_AnimTimer = "Timer";
    // Start is called before the first frame update
    void Start()
    {
        ChangeColorStick();
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeUI();
    }

    void ChangeColorStick()
    {
        animator = FindObjectOfType<Animator>();
        uiManagers = FindObjectOfType<UIManager>();
        charColl = FindObjectOfType<CharacterCollider>();
        rootObjects = GameObject.FindGameObjectWithTag("RootObject");
        transformParent = charColl.transform;
        Instantiate(stickGimmeck, stickGimmeck.transform.position, Quaternion.identity, transformParent);
    }

    void CheckTimeUI()
    {
        if(uiManagers.timeValueUp > 180)
        {
            animator.SetFloat(m_AnimTimer, uiManagers.timeValueUp);
        }
        stickGimmeck.transform.position = new Vector3(10,0,0);
    }
   
}
