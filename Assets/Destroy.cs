using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void DestroyParent()
    {
        GameObject parent = this.gameObject;
        Destroy(parent);
    }
}
