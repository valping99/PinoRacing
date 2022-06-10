using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostPopUp : MonoBehaviour
{
    public TextMeshProUGUI text;
    public UIManager uiManagers;

    private void Start()
    {
        uiManagers = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
        text = uiManagers.countBoostNumber_Text;

    }
    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }

}
