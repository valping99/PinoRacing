using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectedUI : MonoBehaviour
{
    public SelectManager selected;

    public GameObject ActiveStage1;
    public GameObject ActiveStage2;


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
        selected.isSelectStage_02 = false;
        ActiveStage1.gameObject.SetActive(true);
        ActiveStage2.gameObject.SetActive(false);
        //selected.SelectPinos.gameObject.SetActive(true);
        //selected.isSelectStage();
    }
    public void selectedStage02()
    {
        selected.isSelectStage_02 = true;
        selected.isSelectStage_01 = false;
        ActiveStage1.gameObject.SetActive(false);
        ActiveStage2.gameObject.SetActive(true);
        //selected.SelectPinos.gameObject.SetActive(true);
        //selected.isSelectStage();
    }
    public void selectedStage03()
    {
        selected.isSelectStage_03 = true;
        //selected.SelectPinos.gameObject.SetActive(true);
        //selected.isSelectStage();
    }

    public void SelectStageAction()
    {
        selected.SelectPinos.gameObject.SetActive(true);
        selected.isSelectStage();
    }


    // Select Pino


    public void selectedPino_01()
    {
        //if (selected.isSelectPino_01)
        //{
        //    selected.SelectPinos.gameObject.SetActive(false);
        //    //selected.isSelectedPino();
        //}
        selected.isSelectPino_02 = false;
        selected.isSelectPino_03 = false;
        selected.isSelectPino_01 = true;
        selected.isSelectedPino();
    }
    public void selectedPino_02()
    {
        //if (selected.isSelectPino_02)
        //{
        //    selected.SelectPinos.gameObject.SetActive(false);
        //    //selected.isSelectedPino();
        //}
        selected.isSelectPino_01 = false;
        selected.isSelectPino_03 = false;
        selected.isSelectPino_02 = true;
        selected.isSelectedPino();
    }
    public void selectedPino_03()
    {
        //if (selected.isSelectPino_03)
        //{
        //    selected.SelectPinos.gameObject.SetActive(false);
        //    //selected.isSelectedPino();
        //}
        selected.isSelectPino_01 = false;
        selected.isSelectPino_02 = false;
        selected.isSelectPino_03 = true;
        selected.isSelectedPino();
    }



    /// Return button
    public void returnMenu()
    {
        selected.SelectPinos.gameObject.SetActive(false);

        selected.Pino_01.gameObject.SetActive(false);
        selected.Pino_02.gameObject.SetActive(false);
        selected.Pino_03.gameObject.SetActive(false);

        selected.pinoAnimatorRotate.chocolateCarRotation.rotation = new Quaternion(0, 160, 0, 0);
        selected.pinoAnimatorRotate.almondCarRotation.rotation = new Quaternion(0, 180, 0, 0);
        selected.pinoAnimatorRotate.strawberryCarRotation.rotation = new Quaternion(0, 210, 0, 0);

        selected.ReturnMenu();

    }
    /// Play button

    public void GamePlay()
    {
        selected.AcceptPlay();
    }
    #endregion
}
