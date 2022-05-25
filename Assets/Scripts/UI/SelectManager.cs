using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectManager : MonoBehaviour
{
    public bool isSelectScene_01;
    public bool isSelectScene_02;
    public bool isSelectScene_03;
    public bool isSelectScene_04;


    public GameObject scene_01;
    public GameObject scene_02;
    public GameObject scene_03;
    public GameObject scene_04;

    public GameObject selectStage_01;
    public GameObject selectStage_02;
    public GameObject selectStage_03;


    public GameObject typeOfPino_01;
    public TextMeshProUGUI nameOfPino_01;
    public GameObject typeOfPino_02;
    public TextMeshProUGUI nameOfPino_02;
    public GameObject typeOfPino_03;
    public TextMeshProUGUI nameOfPino_03;

    public GameObject statusOfPino_01;
    public GameObject statusOfPino_02;
    public GameObject statusOfPino_03;


    public TextMeshProUGUI Text_TapToStart;
    public int selectedStage;
    public int selectedPino;
    // Start is called before the first frame update
    void Start()
    {
        isSelectScene_01 = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SelectStage()
    {
        isSelectScene_02 = true;
        if (isSelectScene_02)
        {
            if (selectStage_01)
            {
                selectedStage = 1;
            }
            else if (selectStage_02)
            {
                selectedStage = 2;
            }
            else
            {
                selectedStage = 3;
            }
        }

        

        
    }
    public void SelectPino()
    {
        if (isSelectScene_03)
        {
            if (typeOfPino_01)
            {
                selectedPino = 1;
            }
            else if (selectStage_02)
            {
                selectedPino = 2;
            }
            else
            {
                selectedPino = 3;
            }
        }
        
    }

    public void ShowStatusPino()
    {
        if (isSelectScene_04)
        {
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
            else
            {
                statusOfPino_01.gameObject.SetActive(false);
                statusOfPino_02.gameObject.SetActive(false);
                statusOfPino_03.gameObject.SetActive(true);
            }
        }
       
    }

    public void AcceptPlay()
    {
        
    }

}
