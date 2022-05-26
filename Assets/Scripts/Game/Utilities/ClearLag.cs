/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearLag : MonoBehaviour
{
    #region Unity Methods

    void OnTriggerEnter(Collider other)
    {
        
        //Wall delete all things when it touch 
        if (other.gameObject.tag == "Item" || other.gameObject.tag == "Obstacle")
        {
            Destroy(other.gameObject);
            // Debug.Log("Clear trash name: " + other.name);
        }
    }
    
    #endregion

}
