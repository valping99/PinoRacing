using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectedUI : MonoBehaviour
{
    #region Variables
    public SelectManager selected;

    public GameObject ActiveStage1;
    public GameObject ActiveStage2;

    public bool timeCheckCD;

    public float timer = 0.8f;
    #endregion
    #region Select Button
    public void OnStart()
    {
        selected.TapToPlay();
    }
    private void Start()
    {

        timeCheckCD = true;
    }

    public void selectedStage01()
    {
        selected.isSelectStage_01 = true;
        selected.isSelectStage_02 = false;
        ActiveStage1.gameObject.SetActive(true);
        ActiveStage2.gameObject.SetActive(false);
    }
    public void selectedStage02()
    {
        selected.isSelectStage_02 = true;
        selected.isSelectStage_01 = false;
        ActiveStage1.gameObject.SetActive(false);
        ActiveStage2.gameObject.SetActive(true);
    }
    public void selectedStage03()
    {
        selected.isSelectStage_03 = true;
    }

    public void SelectStageAction()
    {
        selected.SelectPinos.gameObject.SetActive(true);
        selected.isSelectStage();
    }

    public void selectedPino_01()
    {
        if (timeCheckCD)
        {
            timeCheckCD = false;
            StartCoroutine(timeToTap());
            selected.isSelectPino_02 = false;
            selected.isSelectPino_03 = false;
            selected.isSelectPino_01 = true;
            selected.isSelectedPino();
        }
    }
    public void selectedPino_02()
    {
        if (timeCheckCD)
        {
            timeCheckCD = false;
            StartCoroutine(timeToTap());
            selected.isSelectPino_01 = false;
            selected.isSelectPino_03 = false;
            selected.isSelectPino_02 = true;
            selected.isSelectedPino();
        }
    }
    public void selectedPino_03()
    {
        if (timeCheckCD)
        {
            timeCheckCD = false;
            StartCoroutine(timeToTap());
            selected.isSelectPino_01 = false;
            selected.isSelectPino_02 = false;
            selected.isSelectPino_03 = true;
            selected.isSelectedPino();
        }
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


    IEnumerator timeToTap()
    {
        yield return new WaitForSeconds(timer);
        timeCheckCD = true;
    }
    #endregion
}
