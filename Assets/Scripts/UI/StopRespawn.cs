using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRespawn : MonoBehaviour
{
    public ObstaclesManager obstacles;
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
            obstacles.GetComponent<ObstaclesManager>().enabled = false;
            Debug.Log("False");
        }
        else
        {
            obstacles.GetComponent<ObstaclesManager>().enabled = true;
            Debug.Log("True");
        }
    }
}
