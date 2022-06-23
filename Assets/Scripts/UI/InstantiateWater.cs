using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWater : MonoBehaviour
{
    public GameObject waterDrop;
    public Transform transformParent;
    // Start is called before the first frame update
    void Start()
    {
        transformParent = GameObject.FindGameObjectWithTag("RootObject").transform;
        Instantiate(waterDrop, transformParent.transform.position, transformParent.transform.rotation, transformParent);
    }

}
