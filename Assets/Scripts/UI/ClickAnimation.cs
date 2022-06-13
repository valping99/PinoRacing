using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    public UIManager uiManagers;

    public Animator animator_Cursor;

    public Animator animator_Clicky;

    const string m_AnimActive = "Active";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }

    void Click()
    {
        if(uiManagers.checkRunning == false)
        {
            animator_Cursor.SetBool(m_AnimActive, true);
            animator_Clicky.SetBool(m_AnimActive, true);
            gameObject.SetActive(true);
        }
        else
        {
            animator_Cursor.SetBool(m_AnimActive, false);
            animator_Clicky.SetBool(m_AnimActive, false);
            gameObject.SetActive(false);
        }
    }
}
