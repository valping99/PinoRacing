using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostCount : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform boostPopup;

    public GameObject popUpBoostNumber;

    public int boostCount = 16;

    protected UIManager uiManagers;

    public Transform transformParent;

    public string textToDisplay;

    Vector3 popUpPosition;

    float timeCountDown;
    #endregion
    private void Start()
    {
        popUpPosition = popUpBoostNumber.transform.position;
    }

    public void NumberPopup()
    {
        GameObject TextBoostPopup = Instantiate(popUpBoostNumber, popUpBoostNumber.transform.position, Quaternion.identity);
        TextBoostPopup.transform.GetComponent<TextMeshProUGUI>().SetText(textToDisplay);
    }

    public void DestroyParent()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        Destroy(parent);
    }

    public void Count()
    {
        if (boostCount <= 0)
        {
            boostCount = 0;
        }
        else
        {
            timeCountDown = 0.5f;
            boostCount -= 1;
             
            Debug.Log("None");
            Instantiate(popUpBoostNumber, popUpBoostNumber.transform.position, popUpBoostNumber.transform.rotation,transformParent);
            if (timeCountDown > 0)
            {
                timeCountDown -= Time.deltaTime;
            }
            else
            {
                Destroy(popUpBoostNumber);
            }
        }
    }
}
