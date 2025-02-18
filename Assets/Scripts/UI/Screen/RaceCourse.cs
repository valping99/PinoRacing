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

    public CPU _CPUInput;
    public int _CPUCourse = 1;
    [SerializeField]private Rigidbody _CPURigid;
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
            audio_BGM.m_AudioSource.pitch = 1.08f;
        }
        else
        {
            uiManagers.finishLap.gameObject.SetActive(false);
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
                audio_sources.PlaySound(SoundType.FinishLap);
                lapCourse += 1;
                lapNums.checkLaps();
            }

        }

        if (other.CompareTag("CPU"))
        {
            _CPUCourse += 1;
            Debug.Log("+1 Race Course");
            if(_CPUCourse > lapToWin)
            {
                _CPUInput.CurrentSpeed = 0;
                Debug.Log("CPU finished!");
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
