
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{

    #region Variables

    int sencondDestroy;

    #endregion

    #region Unity Function
    void Start()
    {
        sencondDestroy = 3;
        StartCoroutine(DestroyItem(sencondDestroy));
    }
    #endregion

    #region Class

    IEnumerator DestroyItem(int s)
    {
        yield return new WaitForSeconds(s);
        Destroy(gameObject);
        // Debug.Log(gameObject.name);
    }
    #endregion
}
