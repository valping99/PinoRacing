using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostCount : MonoBehaviour
{
    public GameObject popUpBoostNumber;

    public UIManager uiManagers;

    public Transform transformParent;

    public RectTransform positionTransform;
    public string textToDisplay;

    public int countPopup;

    public int boostCount = 16;

    private void Start()
    {

    }
    void Update()
    {
        countPopup = uiManagers.boostCount;
    }
    public void NumberPopup()
    {

        textToDisplay = countPopup.ToString();
        
        GameObject TextBoostPopup = Instantiate(popUpBoostNumber, popUpBoostNumber.transform.localPosition, Quaternion.identity,transformParent);
        RectTransform rt = TextBoostPopup.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0,15,0);
        TextBoostPopup.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(textToDisplay);
    }

    public void Count()
    {
        if (boostCount <= 0)
        {
            boostCount = 0;
        }
        else
        {
            boostCount -= 1;            
        }
    }
}
