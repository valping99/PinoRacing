using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectManager : MonoBehaviour
{
    public CharacterSelected charSelect;
    public UIManager uiManagers;

    //check scene to active
    public bool isSelectScene_01;
    public bool isSelectScene_02;
    public bool isSelectScene_03;
    public bool isSelectScene_04;

    //check stage to play
    public bool isSelectStage_01;
    public bool isSelectStage_02;
    public bool isSelectStage_03;

    //check pino to play
    public bool isSelectPino_01;
    public bool isSelectPino_02;
    public bool isSelectPino_03;

    // to set active scene
    public GameObject scene_01;
    public GameObject scene_02;
    public GameObject scene_03;
    public GameObject scene_04;

    // to set active select stages
    public GameObject selectStage_01;
    public GameObject selectStage_02;
    public GameObject selectStage_03;

    //Show status of Pino
    public GameObject typeOfPino_01;
    public TextMeshProUGUI nameOfPino_01;
    public GameObject typeOfPino_02;
    public TextMeshProUGUI nameOfPino_02;
    public GameObject typeOfPino_03;
    public TextMeshProUGUI nameOfPino_03;

    public GameObject statusOfPino_01;
    public GameObject statusOfPino_02;
    public GameObject statusOfPino_03;

    //Text & Variables 
    public TextMeshProUGUI Text_TapToStart;
    public int selectedStage;
    public int selectedPino;

    //Onstart to open Scene1
    void Start()
    {
        isSelectScene_01 = true;
        isSelectScene_02 = false;
        isSelectScene_03 = false;
        isSelectScene_04 = false;
    }

    void Update()
    {
        checkScene();
    }

    //StartUI to select stage 
    public void TapToPlay()
    {
        if (isSelectScene_01)
        {
            isSelectScene_01 = false;
            scene_01.gameObject.SetActive(false);
            isSelectScene_02 = true;
        }
    }

    // Check Scene to active gameObject
    public void checkScene()
    {
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
        else if(isSelectScene_04)
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


    //Select stages
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

        scene_02.gameObject.SetActive(false);
    }


    // Select Pinos
    public void isSelectedPino()
    {
        if (isSelectPino_01)
        {
            selectedPino = 1;
            isSelectPino_02 = false;
            isSelectPino_03 = false;
            isSelectScene_03 = false;
            isSelectScene_04 = true;

            //Enable isSelectedPino & Disable unSelectedPino
            statusOfPino_01.gameObject.SetActive(true);
            statusOfPino_02.gameObject.SetActive(false);
            statusOfPino_03.gameObject.SetActive(false);
        }
        else if (isSelectPino_02)
        {
            selectedPino = 2;
            isSelectPino_01 = false;
            isSelectPino_03 = false;
            isSelectScene_03 = false;
            isSelectScene_04 = true;

            //Enable isSelectedPino & Disable unSelectedPino
            statusOfPino_01.gameObject.SetActive(false);
            statusOfPino_02.gameObject.SetActive(true);
            statusOfPino_03.gameObject.SetActive(false);
        }
        else if (isSelectPino_03)
        {
            selectedPino = 3;
            isSelectPino_02 = false;
            isSelectPino_01 = false;
            isSelectScene_03 = false;
            isSelectScene_04 = true;

            //Enable isSelectedPino & Disable unSelectedPino
            statusOfPino_01.gameObject.SetActive(false);
            statusOfPino_02.gameObject.SetActive(false);
            statusOfPino_03.gameObject.SetActive(true);
        }
        scene_03.gameObject.SetActive(false);
    }

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


    //Press button to play 
    public void AcceptPlay()
    {
        UIManager.pinoSelected = selectedPino;
        for(int i = 0; i<selectedStage; i++)
        {
            SceneManager.LoadScene(selectedStage);
        }
        Time.timeScale = 1f;
    }


    //Return to menu
    public void ReturnMenu()
    {
        scene_04.gameObject.SetActive(false);

        //Set default all & return scene 2

        isSelectStage_01 = false;
        isSelectStage_02 = false;
        isSelectStage_03 = false;

        isSelectPino_01 = false;
        isSelectPino_02 = false;
        isSelectPino_03 = false;

        isSelectScene_02 = true;
        isSelectScene_04 = false;
    }

}
