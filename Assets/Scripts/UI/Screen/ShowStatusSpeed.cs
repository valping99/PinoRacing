using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowStatusSpeed : MonoBehaviour
{
    public bool showStatus;
    public GameObject speedStatus;

    public void ShowStatus()
    {
        if (showStatus)
        {
            speedStatus.gameObject.SetActive(true);
        }
        else
        {
            speedStatus.gameObject.SetActive(false);
        }
    }

    public void ShowHide()
    {
        showStatus = !showStatus;
    }
}
