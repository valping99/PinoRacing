using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickChangeColor : MonoBehaviour
{
    public CharacterCollider charColl;
    public Transform transformParent;
    public GameObject stickGimmeck;

    public UIManager uiManagers;

    [Tooltip("Animator")]
    public Animator animator;
    const string m_AnimTimer = "Timer";
    // Start is called before the first frame update
    void Start()
    {
        ChangeColorStick();
        animator = FindObjectOfType<Animator>();
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
        transformParent = charColl.transform;
        Instantiate(stickGimmeck, stickGimmeck.transform.position, Quaternion.identity, transformParent);
    }

    void CheckTimeUI()
    {
        if(uiManagers.timeValueUp > 180)
        {
            animator.SetFloat(m_AnimTimer, uiManagers.timeValueUp);
        }
    }
   
}
