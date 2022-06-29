using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "CheckSpawnX")
        {
            Debug.Log("WTF");
        }
    }
}
