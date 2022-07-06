using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCourse : MonoBehaviour
{
    #region Variables
    public Character m_charCollider;
    public SoundManagers audio_sources;
    public SoundManagers audio_BGM;
    public int lapCourse;
    private UIManager uiManagers;
    private LapsNumber lapNums;
    public int lapToWin = 3;
    #endregion

    #region UnityMethod
    void Start()
    {
        GetVariables();
    }
    void Update()
    {
        CheckLapCourse();
        uiManagers.lapsToGameOver = lapCourse;
        if (lapCourse == lapToWin)
        {
            Invoke("ShowFinishLap", 2f);
        }
    }

    void CheckLapCourse()
    {
        if (uiManagers.startScene)
            lapCourse = 1;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RootObject"))
        {
            if (lapCourse >= lapToWin)
            {
                audio_sources.PlaySound(SoundType.Finish);
                audio_BGM.PlaySound(SoundType.Stop);
                audio_BGM.PlaySound(SoundType.Clear);
                uiManagers.checkGameClear = true;
                lapCourse = 1;
            }
            else
            {
                lapCourse += 1;
                lapNums.checkLaps();

            }
        }
    }
    #endregion

    #region Class
    void GetVariables()
    {
        lapNums = FindObjectOfType<LapsNumber>();
        m_charCollider = FindObjectOfType<Character>();
        uiManagers = FindObjectOfType<UIManager>();
        lapCourse = 1;
        uiManagers.finishLap.gameObject.SetActive(false);
        audio_sources = GameObject.FindGameObjectWithTag("SoundManagers").GetComponent<SoundManagers>();
        audio_BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<SoundManagers>();
    }

    // Update is called once per frame

    private void ShowFinishLap()
    {
        uiManagers.finishLap.gameObject.SetActive(true);

    }
    #endregion
}
