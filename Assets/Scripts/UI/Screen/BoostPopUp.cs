using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostPopUp : MonoBehaviour
{
    #region Variables
    public TextMeshProUGUI text;
    public UIManager uiManagers;
    #endregion
    #region Unity Method
    private void Start()
    {
        uiManagers = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
        text = uiManagers.countBoostNumber_Text;

    }
    #endregion
    #region Class
    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }
    #endregion
}
