using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectManager : MonoBehaviour
{
    #region Variables & GameObjects
    [Header("Get Scripts")]
    public CharacterSelected charSelect;
    public UIManager uiManagers;
    public AnimSelectedPino animatorSelected;
    public PinoAnimatorRotate pinoAnimatorRotate;
    public GameObject buttonAction;
    public GameObject buttonSelectStage;
    public ButtonSelectedUI selectedUI;

    [Header("Sound Managers")]
    public SoundManagers audio_source;

    [Header("Variables")]
    public int selectedStage;
    public int selectedPino;

    [Header("Selected Scene")]
    public bool isSelectScene_01;
    public bool isSelectScene_02;
    public bool isSelectScene_03;
    public bool isSelectScene_04;


    [Header("Selected Stage")]
    public bool isSelectStage_01;
    public bool isSelectStage_02;
    public bool isSelectStage_03;

    [Header("Selected Pino")]
    public bool isSelectPino_01;
    public bool isSelectPino_02;
    public bool isSelectPino_03;

    [Header("Select Pino & Show Pino")]
    public GameObject SelectPinos;
    public GameObject Pino_01;
    public GameObject Pino_02;
    public GameObject Pino_03;

    // to set active scene
    [Header("G_Scenes ")]
    public GameObject scene_01;
    public GameObject scene_02;
    public GameObject scene_03;
    public GameObject scene_04;
    [Header("G_Stages")]
    public GameObject selectStage_01;
    public GameObject selectStage_02;
    public GameObject selectStage_03;

    [Header("Pino Variables")]
    public GameObject typeOfPino_01;
    public TextMeshProUGUI nameOfPino_01;
    public GameObject typeOfPino_02;
    public TextMeshProUGUI nameOfPino_02;
    public GameObject typeOfPino_03;
    public TextMeshProUGUI nameOfPino_03;

    [Header("GameObject Pino Status")]
    public GameObject statusOfPino_01;
    public GameObject statusOfPino_02;
    public GameObject statusOfPino_03;

    [Header("Text & Variables ")]
    public TextMeshProUGUI Text_TapToStart;

    #endregion
    #region Unity Method
    void Start()
    {
        GetEnableStart();
        audio_source = FindObjectOfType<SoundManagers>();
        pinoAnimatorRotate = SelectPinos.GetComponent<PinoAnimatorRotate>();
    }

    void Update()
    {
        checkScene();
        checkAnimation();
    }

    #endregion
    #region Selected
    void GetEnableStart()
    {
        isSelectScene_01 = true;
        isSelectScene_02 = false;
        isSelectScene_03 = false;
        isSelectScene_04 = false;
        SelectPinos.gameObject.SetActive(false);
    }

    [Tooltip("StartUI to select stage")]
    public void TapToPlay()
    {
        if (isSelectScene_01)
        {
            isSelectScene_01 = false;
            scene_01.gameObject.SetActive(false);
            isSelectScene_02 = true;
            Time.timeScale = 1f;
        }
    }


    [Tooltip("Check Scene to active gameObject")] 
    public void checkScene()
    {
        //Check Stage is selected or not
        if (!isSelectStage_01 && !isSelectStage_02 && !isSelectStage_03)
        {
            buttonSelectStage.gameObject.SetActive(false);
        }
        else
        {
            buttonSelectStage.gameObject.SetActive(true);
        }
        //Check Pino is selected or not
        if (!isSelectPino_01 && !isSelectPino_02 && !isSelectPino_03)
        {
            buttonAction.gameObject.SetActive(false);
        }
        else
        {
            buttonAction.gameObject.SetActive(true);
        }

        //Active scene when select 
        if (isSelectScene_01)
        {
            scene_01.gameObject.SetActive(true);
            scene_02.gameObject.SetActive(false);
            scene_03.gameObject.SetActive(false);
            scene_04.gameObject.SetActive(false);
        }
        else if (isSelectScene_02)
        {
            scene_02.gameObject.SetActive(true);
            scene_01.gameObject.SetActive(false);
            scene_03.gameObject.SetActive(false);
            scene_04.gameObject.SetActive(false);
        }
        else if (isSelectScene_03)
        {
            scene_03.gameObject.SetActive(true);
            scene_02.gameObject.SetActive(false);
            scene_01.gameObject.SetActive(false);
            scene_04.gameObject.SetActive(false);
        }
        else if (isSelectScene_04)
        {
            scene_04.gameObject.SetActive(true);
            scene_02.gameObject.SetActive(false);
            scene_03.gameObject.SetActive(false);
            scene_01.gameObject.SetActive(false);
        }
        else
        {
            isSelectScene_01 = true;
        }
    }


    [Tooltip("Check Pino Selected")]
    public void checkAnimation()
    {
        if (isSelectPino_01)
        {
            animatorSelected.isSelect1 = true;
            animatorSelected.isSelect2 = false;
            animatorSelected.isSelect3 = false;
            animatorSelected.none = false;
        }
        else if (isSelectPino_02)
        {
            animatorSelected.isSelect1 = false;
            animatorSelected.isSelect2 = true;
            animatorSelected.isSelect3 = false;
            animatorSelected.none = false;
        }
        else if (isSelectPino_03)
        {
            animatorSelected.isSelect1 = false;
            animatorSelected.isSelect2 = false;
            animatorSelected.none = false;
            animatorSelected.isSelect3 = true;
        }
    }


    [Tooltip("Select stages")]
    public void isSelectStage()
    {
        if (isSelectStage_01)
        {
            selectedStage = 1;
            isSelectStage_02 = false;
            isSelectStage_03 = false;
            isSelectScene_02 = false;
            isSelectScene_03 = true;
        }
        else if (isSelectStage_02)
        {
            selectedStage = 2;
            isSelectStage_01 = false;
            isSelectStage_03 = false;
            isSelectScene_02 = false;
            isSelectScene_03 = true;
        }
        else if (isSelectStage_03)
        {
            selectedStage = 3;
            isSelectStage_02 = false;
            isSelectStage_01 = false;
            isSelectScene_02 = false;
            isSelectScene_03 = true;
        }
        else
        {
            selectedStage = 1;
        }

        scene_02.gameObject.SetActive(false);
    }

    [Tooltip("Select Pinos")]
    public void isSelectedPino()
    {
        if (isSelectPino_01)
        {
            selectedPino = 1;
            isSelectPino_02 = false;
            isSelectPino_03 = false;
        }
        else if (isSelectPino_02)
        {
            selectedPino = 2;
            isSelectPino_01 = false;
            isSelectPino_03 = false;
        }
        else if (isSelectPino_03)
        {
            selectedPino = 3;
            isSelectPino_02 = false;
            isSelectPino_01 = false;
        }
    }


    [Tooltip("Press button to play")]
    public void AcceptPlay()
    {
        UIManager.pinoSelected = selectedPino;
        SceneManager.LoadScene(selectedStage);
        Time.timeScale = 1f;
    }


    [Tooltip("Return to menu")]
    public void ReturnMenu()
    {
        scene_04.gameObject.SetActive(false);

        isSelectStage_01 = false;
        isSelectStage_02 = false;
        isSelectStage_03 = false;


        isSelectPino_01 = false;
        isSelectPino_02 = false;
        isSelectPino_03 = false;

        isSelectScene_02 = true;
        isSelectScene_03 = false;
        isSelectScene_04 = false;

        selectedUI.ActiveStage1.gameObject.SetActive(false);
        selectedUI.ActiveStage2.gameObject.SetActive(false);
    }

    public void TapSE()
    {
        audio_source.PlaySound(SoundType.Tap);
    }


    #endregion
    #region Backup

    /** ---------> Backup <---------
    public void isSelectedPino()
    {
        if (isSelectPino_01)
        {
            //SelectPinos.gameObject.SetActive(false);
            selectedPino = 1;
            isSelectPino_02 = false;
            isSelectPino_03 = false;
            //isSelectScene_03 = false;
            //isSelectScene_04 = true;
            //Pino_01.gameObject.SetActive(true);
            //Pino_02.gameObject.SetActive(false);
            //Pino_03.gameObject.SetActive(false);

            //Enable isSelectedPino & Disable unSelectedPino
            //statusOfPino_01.gameObject.SetActive(true);
            //statusOfPino_02.gameObject.SetActive(false);
            //statusOfPino_03.gameObject.SetActive(false);
        }
        else if (isSelectPino_02)
        {
            //SelectPinos.gameObject.SetActive(false);
            selectedPino = 2;
            isSelectPino_01 = false;
            isSelectPino_03 = false;
            //isSelectScene_03 = false;
            //isSelectScene_04 = true;
            //Pino_01.gameObject.SetActive(false);
            //Pino_02.gameObject.SetActive(true);
            //Pino_03.gameObject.SetActive(false);

            ////Enable isSelectedPino & Disable unSelectedPino
            //statusOfPino_01.gameObject.SetActive(false);
            //statusOfPino_02.gameObject.SetActive(true);
            //statusOfPino_03.gameObject.SetActive(false);
        }
        else if (isSelectPino_03)
        {
            //SelectPinos.gameObject.SetActive(false);
            selectedPino = 3;
            isSelectPino_02 = false;
            isSelectPino_01 = false;
            //isSelectScene_03 = false;
            //isSelectScene_04 = true;
            //Pino_01.gameObject.SetActive(false);
            //Pino_02.gameObject.SetActive(false);
            //Pino_03.gameObject.SetActive(true);

            ////Enable isSelectedPino & Disable unSelectedPino
            //statusOfPino_01.gameObject.SetActive(false);
            //statusOfPino_02.gameObject.SetActive(false);
            //statusOfPino_03.gameObject.SetActive(true);
        }
        //scene_03.gameObject.SetActive(false);
    }
    **/
    /**
    public void SelectPino()
    {
        isSelectScene_02 = false;
        isSelectScene_03 = true;
        if (isSelectScene_03)
        {
            scene_02.gameObject.SetActive(false);
            if (typeOfPino_01)
            {
                selectedPino = 1;
            }
            else if (typeOfPino_02)
            {
                selectedPino = 2;
            }
            else if(typeOfPino_03)
            {
                selectedPino = 3;
            }
        }
        ShowStatusPino();
        
    }
    **/


    /**
    //Show infomation of Pinos
    public void ShowStatusPino()
    {
        isSelectScene_03 = false;
        isSelectScene_04 = true;

        if (isSelectScene_04)
        {
            scene_03.gameObject.SetActive(false);
            if (selectedPino == 1)
            {
                statusOfPino_01.gameObject.SetActive(true);
                statusOfPino_02.gameObject.SetActive(false);
                statusOfPino_03.gameObject.SetActive(false);
            }
            else if (selectedPino == 2)
            {
                statusOfPino_01.gameObject.SetActive(false);
                statusOfPino_02.gameObject.SetActive(true);
                statusOfPino_03.gameObject.SetActive(false);
            }
            else if(selectedPino == 3)
            {
                statusOfPino_01.gameObject.SetActive(false);
                statusOfPino_02.gameObject.SetActive(false);
                statusOfPino_03.gameObject.SetActive(true);
            }
        }
       
    }
    **/
    #endregion
}
