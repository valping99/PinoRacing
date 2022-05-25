using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectedUI : MonoBehaviour
{
    public SelectManager selected;

    public void OnStart()
    {
    }
    public void SelectStage()
    {
        selected.SelectPino();
    }
    public void SelectPino()
    {
        selected.ShowStatusPino();
    }

    public void GamePlay()
    {
        selected.AcceptPlay();
    }


    public void checkScene1()
    {
        selected.isSelectScene_02 = true;
        selected.isSelectScene_01 = false;
        selected.checkScene();
    }

    public void selectedStage01()
    {
        selected.isSelectStage_01 = true;
        selected.isSelectStage();
        Debug.Log("Stage1");
    }
    public void selectedStage02()
    {
        selected.isSelectStage_02 = true;
        selected.isSelectStage();
        Debug.Log("Stage2");
    }
    public void selectedStage03()
    {
        selected.isSelectStage_03 = true;
        selected.isSelectStage();
    }




    public void selectedPino_01()
    {
        selected.isSelectPino_01 = true;
        selected.isSelectedPino();
    }
    public void selectedPino_02()
    {
        selected.isSelectPino_02 = true;
        selected.isSelectedPino();
    }
    public void selectedPino_03()
    {
        selected.isSelectPino_03 = true;
        selected.isSelectedPino();
    }


    public void returnMenu()
    {
        selected.ReturnMenu();
    }
}
