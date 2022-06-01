using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRespawn : MonoBehaviour
{
    public GameManager gameManagers;
    public UIManager uiManagers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(uiManagers.checkRunning == false)
        {
            gameManagers.gameObject.SetActive(false);
            Debug.Log("False");
        }
        else
        {
            gameManagers.gameObject.SetActive(true);
            Debug.Log("True");
        }
    }
}
