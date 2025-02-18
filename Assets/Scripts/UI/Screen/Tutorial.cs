using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    #region Variables
    [Header("Set Button")]
    public bool enableTutorialButton;

    [Header("List GameObject")]
    public List<GameObject> titleList;
    public List<GameObject> tutorialList;
    public List<GameObject> contentList;
    public List<GameObject> sheetList;
    public List<Transform> transformList;

    [Header("Instantiate Object")]
    public GameObject instantiateTitle;
    public GameObject instantiateSheet;
    public GameObject instantiateContent;

    [Header("Sheet")]
    public int currentSheet;
    public int totalSheet;

    [Header("Check Active")]
    public bool checkActive;
    public GameObject buttonToActive;
    public GameObject tutorialBackground;

    [Header("Object Active")]
    public GameObject isActiveSheet;
    public RectTransform sheetTransform;
    public GameObject moveLeft;
    public GameObject moveRight;
    public GameObject tapToStart;

    [Header("Transform Parent")]
    public Transform titleParent;
    public Transform sheetParent;
    public Transform contentParent;
    public Transform TutorialParent;

    [Tooltip("Tutorial")]
    private GameObject tutorialScene;
    #endregion
    #region Unity Method
    void Start()
    {
        StartTutorial();
        GetVariables();
    }

    void Update()
    {
        //EnableButton();
        GetVariables();
        //ActiveTutorialSheet();
        CheckChangeSheet();
        //ShowCurrentSheet();
    }
    #endregion
    #region Use for Button
    public void BackToMenu()
    {
        checkActive = false;
        tapToStart.gameObject.SetActive(true);
        ActiveTutorialSheet();
        SetDefault();
    }
    public void TutorialButton()
    {
        checkActive = true;
        tapToStart.gameObject.SetActive(false);
        ActiveTutorialSheet();
    }
    public void ChangeLeft()
    {
        currentSheet--;
        SetInstantiate();
        SetActiveCurrentDot();
    }
    public void ChangeRight()
    {
        currentSheet++;
        SetInstantiate();
        SetActiveCurrentDot();
    }
    #endregion
    #region Class
    //Set Active
    void SetInstantiate()
    {
        for (int i = 0; i <= sheetList.Count; i++)
        {
            if (i == currentSheet)
            {
                Destroy(instantiateTitle);
                Destroy(instantiateContent);
                Destroy(instantiateSheet);


                Instantiate(titleList[i - 1], titleParent.position, Quaternion.identity, titleParent);
                Instantiate(tutorialList[i - 1], sheetParent.position, Quaternion.identity, sheetParent);
                Instantiate(contentList[i - 1], contentParent.position, Quaternion.identity, contentParent);

                return;
            }
        }
    }

    void SetDefault()
    {
        currentSheet = 1;
        SetInstantiate();
        SetActiveCurrentDot();
    }

    //Show current sheet
    void SetActiveCurrentDot()
    {
        for (int i = 0; i <= sheetList.Count; i++)
        {
            if (i == currentSheet)
            {
                sheetTransform.SetParent(transformList[i-1]);
                sheetTransform.localPosition = new Vector3(0, 0, 0);

                return;
            }
        }
    }
    //Enable/Hide Button when click
    public void EnableButton()
    {
        if (enableTutorialButton)
        {
            //Remove show button
            //buttonToActive.gameObject.SetActive(true);
        }
        else
        {
            buttonToActive.gameObject.SetActive(false);
        }
    }

    //Show - Hide Button
    void ActiveTutorialSheet()
    {
        if (checkActive)
        {
            buttonToActive.gameObject.SetActive(false);
            tutorialScene.gameObject.SetActive(true);
        }
        else
        {
            //Remove show button
            buttonToActive.gameObject.SetActive(true);
            tutorialScene.gameObject.SetActive(false);
        }
        
    }

    //Active Arrow Object
    void CheckChangeSheet()
    {
        for(int i = 0; i <= sheetList.Count; i++)
        {
            totalSheet = i;
        }

        if(currentSheet <= 1)
        {
            moveLeft.gameObject.SetActive(false);
            moveRight.gameObject.SetActive(true);
        }
        else if(currentSheet == totalSheet)
        {
            moveRight.gameObject.SetActive(false);
            moveLeft.gameObject.SetActive(true);
        }
        else
        {
            moveLeft.gameObject.SetActive(true);
            moveRight.gameObject.SetActive(true);
        }
    }
    //Run when start
    void StartTutorial()
    {
        currentSheet = 1;
        tutorialScene = GameObject.FindGameObjectWithTag("TutorialSheet");
        tutorialScene.gameObject.SetActive(false);
        tutorialBackground.gameObject.SetActive(true);
        Instantiate(titleList[0], titleParent.position, Quaternion.identity, titleParent);
        Instantiate(tutorialList[0], sheetParent.position, Quaternion.identity, sheetParent);
        Instantiate(contentList[0], contentParent.position, Quaternion.identity, contentParent);
    }


    //Get Variables objects
    void GetVariables()
    {
        instantiateTitle = GameObject.FindGameObjectWithTag("Title_Tutorial");
        instantiateContent = GameObject.FindGameObjectWithTag("Content_Tutorial");
        instantiateSheet = GameObject.FindGameObjectWithTag("Sheet_Tutorial");
    }

    #endregion
}
