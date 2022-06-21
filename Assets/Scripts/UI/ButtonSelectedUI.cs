using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectedUI : MonoBehaviour
{
    public SelectManager selected;

    #region Select Variables
    public void OnStart()
    {
        selected.TapToPlay();
    }

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

    public void selectedStage01()
    {
        selected.isSelectStage_01 = true;
        selected.SelectPinos.gameObject.SetActive(true);
        selected.isSelectStage();
    }
    public void selectedStage02()
    {
        selected.isSelectStage_02 = true;
        selected.SelectPinos.gameObject.SetActive(true);
        selected.isSelectStage();
    }
    public void selectedStage03()
    {
        selected.isSelectStage_03 = true;
        selected.SelectPinos.gameObject.SetActive(true);
        selected.isSelectStage();
    }


    // Select Pino


    public void selectedPino_01()
    {
        if (selected.isSelectPino_01)
        {
            selected.SelectPinos.gameObject.SetActive(false);
            selected.isSelectedPino();
        }
        selected.isSelectPino_02 = false;
        selected.isSelectPino_03 = false;
        selected.isSelectPino_01 = true;
        //selected.isSelectedPino();
    }
    public void selectedPino_02()
    {
        if (selected.isSelectPino_02)
        {
            selected.SelectPinos.gameObject.SetActive(false);
            selected.isSelectedPino();
        }
        selected.isSelectPino_01 = false;
        selected.isSelectPino_03 = false;
        selected.isSelectPino_02 = true;
        //selected.isSelectedPino();
    }
    public void selectedPino_03()
    {
        if (selected.isSelectPino_03)
        {
            selected.SelectPinos.gameObject.SetActive(false);
            selected.isSelectedPino();
        }
        selected.isSelectPino_01 = false;
        selected.isSelectPino_02 = false;
        selected.isSelectPino_03 = true;
        //selected.isSelectedPino();
    }



    /// Return button
    public void returnMenu()
    {
        selected.ReturnMenu();
        selected.Pino_01.gameObject.SetActive(false);
        selected.Pino_02.gameObject.SetActive(false);
        selected.Pino_03.gameObject.SetActive(false);

    }
    /// Play button

    public void GamePlay()
    {
        selected.AcceptPlay();
    }
    #endregion
}
