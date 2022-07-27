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
    #endregion
    #region Unity Method
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
        if (activeAnim == true && managers.timeValueUp >= waterObjects.timeToDrip)
        {
            waterObjects.enableAnim = true;
            activeAnim = false;
        }
        if (waterObjects.enableAnim)
        {
            waterObjects.gameObject.SetActive(true);
        }
        else
        {
            waterObjects.gameObject.SetActive(false);
        }
    }
    #endregion
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
}
