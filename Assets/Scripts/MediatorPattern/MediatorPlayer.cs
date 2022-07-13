using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediatorPlayer : MonoBehaviour
{
    public static void GetMilk()
    {
        UIManager _managers = FindObjectOfType<UIManager>();
        _managers.GetMilk();
    }
    public static void DisableEngineSound()
    {
        UIManager _managers = FindObjectOfType<UIManager>();
        _managers.DisableEngineSound();
    }

}
