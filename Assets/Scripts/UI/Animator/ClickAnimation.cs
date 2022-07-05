using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    #region Variables
    public UIManager uiManagers;

    public Animator animator_Cursor;


    const string m_AnimActive = "Active";
    #endregion

    #region Unity Method
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
            gameObject.SetActive(true);
        }
        else
        {
            animator_Cursor.SetBool(m_AnimActive, false);
            gameObject.SetActive(false);
        }
    }
    #endregion
}
