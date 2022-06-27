using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWater : MonoBehaviour
{
    public GameObject waterDrop;
    public Transform transformParent;
    public Waterdrop waterObjects;
    private UIManager managers;
    private CharacterController charInput;

    // Start is called before the first frame update
    void Start()
    {
        transformParent = GameObject.FindGameObjectWithTag("RootObject").transform;
        Instantiate(waterDrop, transformParent.transform.position, transformParent.transform.rotation, transformParent);
        charInput = FindObjectOfType<CharacterController>();
        managers = FindObjectOfType<UIManager>();
        waterObjects = FindObjectOfType<Waterdrop>();
    }

    private void Update()
    {
        if (managers.timeValueUp >= 180)
        {
            if (charInput.m_Stuns)
            {
                waterObjects.gameObject.SetActive(false);
            }
            else
            {
                waterObjects.gameObject.SetActive(true);
            }
        }
    }

}
