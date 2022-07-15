using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    public GameObject instantiateDescription;
    public Transform descriptionParent;


    public void ShowDescription()
    {
        Instantiate(instantiateDescription, descriptionParent.position, Quaternion.identity, descriptionParent);
    }

    public void DeleteDescription()
    {
        GameObject description = GameObject.FindGameObjectWithTag("Description");
        Destroy(description);
    }
}
