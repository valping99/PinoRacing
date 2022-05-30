using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectedUI : MonoBehaviour
{
    public SelectManager selected;

    /// <summary>
    /// //////////////////////////
    /// </summary>
    public void OnStart()
    {
        selected.TapToPlay();
    }

    /// //////////////////////////
    /// 
    /**
    public void SelectStage()
    {
        selected.SelectPino();
    }
    public void SelectPino()
    {
        selected.ShowStatusPino();
    }
    
    **/

    /// Select Stage

    public void selectedStage01()
    {
        selected.isSelectStage_01 = true;
        selected.isSelectStage();
    }
    public void selectedStage02()
    {
        selected.isSelectStage_02 = true;
        selected.isSelectStage();
    }
    public void selectedStage03()
    {
        selected.isSelectStage_03 = true;
        selected.isSelectStage();
    }


    // Select Pino


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

    /// Return button
    public void returnMenu()
    {
        selected.ReturnMenu();
    }
    /// Play button

    public void GamePlay()
    {
        selected.AcceptPlay();
    }
}
