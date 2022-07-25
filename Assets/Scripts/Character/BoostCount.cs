using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoostCount : MonoBehaviour
{
    #region Variables
    public GameObject popUpBoostNumber;

    public CharacterController charInput;

    public UIManager uiManagers;

    public Transform transformParent;

    public RectTransform positionTransform;
    public string textToDisplay;

    public int countPopup;

    public int boostCount = 16;


    #endregion

    #region Unity Method
    void Start()
    {
        charInput = FindObjectOfType<CharacterController>();
    }
    void Update()
    {
        countPopup = uiManagers.boostCount;
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K))
        {
            NumberPopup();
            Count();
        }
    }
    #endregion

    #region Function
    public void NumberPopup()
    {

        textToDisplay = countPopup.ToString();

        GameObject TextBoostPopup = Instantiate(popUpBoostNumber, popUpBoostNumber.transform.localPosition, Quaternion.identity, transformParent);
        RectTransform rt = TextBoostPopup.GetComponent<RectTransform>();
        rt.localPosition = new Vector3(0, 15, 0);
        TextBoostPopup.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(textToDisplay);
    }

    public void Count()
    {
        if (boostCount <= 0)
        {
            //uiManagers.audio_warning.PlaySound(SoundType.DashBoost);
            boostCount = 0;
        }
        else
        {
            boostCount -= 1;
            uiManagers.audio_source.PlaySound(SoundType.Stroke);
        }
    }

    #endregion
}
