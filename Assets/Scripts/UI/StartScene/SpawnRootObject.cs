using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRootObject : MonoBehaviour
{
    #region Variables
    public Transform transformParent;
    public Character charColl;
    public CharacterController charInput;
    public GameObject rootObject;
    public GameObject currentRootObject;
    #endregion
    #region Unity Method
    void Start()
    {
        transformParent = FindObjectOfType<CharacterController>().transform;
        charInput = FindObjectOfType<CharacterController>();
        charColl = FindObjectOfType<Character>();
        Instantiate(rootObject, transformParent.transform.position, Quaternion.identity, transformParent);
        currentRootObject = GameObject.FindGameObjectWithTag("RootObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (charInput.m_Stuns == false)
        {
            charColl.transform.position = currentRootObject.transform.position;
        }
        else
        {
            currentRootObject.transform.position = charColl.transform.position;
            currentRootObject.transform.rotation = charColl.transform.rotation;
        }
    }
    #endregion
}
