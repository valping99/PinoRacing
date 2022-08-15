using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWater : MonoBehaviour
{
    #region Variables
    public GameObject waterDrop;
    public Transform transformParent;
    public Waterdrop waterObjects;
    private UIManager managers;
    private CharacterController charInput;
    private bool activeAnim = true;
    public GameObject rootObject;
    private bool checkStun = false;
    #endregion
    #region Unity Method
    void Start()
    {
        //transformParent = GameObject.FindGameObjectWithTag("RootObject").transform;
        //Instantiate(waterDrop, transformParent.transform.position, transformParent.transform.rotation, transformParent);
        rootObject = GameObject.FindGameObjectWithTag("Root");
        charInput = FindObjectOfType<CharacterController>();
        managers = FindObjectOfType<UIManager>();
        waterObjects = FindObjectOfType<Waterdrop>();
    }

    private void Update()
    {
        if (activeAnim == true && managers.timeValueUp >= waterObjects.timeToDrip)
        {
            waterObjects.enableAnim = true;
            activeAnim = false;
        }
        if (charInput.m_Stuns)
        {
            checkStun = true;
        }
        if(checkStun && charInput.m_Stuns == false)
        {
            StartCoroutine(FixPosition());
            checkStun = false;
        }
        CheckEnable();
    }
    #endregion
    void CheckEnable()
    {
        if (waterObjects.enableAnim)
        {
            waterObjects.gameObject.SetActive(true);
        }
        else
        {
            waterObjects.gameObject.SetActive(false);
        }
    }
    IEnumerator CheckEnableWater()
    {
        yield return new WaitForSeconds(.8f);

    }
    IEnumerator CheckDisableWater()
    {
        yield return new WaitForSeconds(.8f);

    }
    public void DisableWater()
    {
        StartCoroutine(EnableWater());
    }
    IEnumerator EnableWater()
    {
        waterObjects.enableAnim = false;
        yield return new WaitForSeconds(.8f);
        waterObjects.enableAnim = true;

    }
    IEnumerator FixPosition()
    {
        yield return new WaitForSeconds(.45f);
        rootObject.transform.localPosition = new Vector3(0,0,0);
        rootObject.transform.localRotation = Quaternion.identity;
    }
}
