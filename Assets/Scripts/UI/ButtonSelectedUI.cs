using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectedUI : MonoBehaviour
{
    public SelectManager selected;

    public void OnStart()
    {
        selected.SelectStage();
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
    }
}
