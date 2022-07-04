using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCourse : MonoBehaviour
{
    #region Variables
    public Character m_charCollider;

    public SoundManagers audio_sources;
    public SoundManagers audio_BGM;
    //public GameObject playerPino;
    public int lapCourse;
    private UIManager uiManagers;
    private LapsNumber lapNums;
    public int lapToWin = 3;
    #endregion
    // Start is called before the first frame update
    #region UnityMethod
    void Start()
    {
        lapNums = FindObjectOfType<LapsNumber>();
        m_charCollider = FindObjectOfType<Character>();
        //playerPino = GameObject.FindGameObjectWithTag("RootObject");
        uiManagers = FindObjectOfType<UIManager>();
        lapCourse = 1;
        uiManagers.finishLap.gameObject.SetActive(false);
        audio_sources = GameObject.FindGameObjectWithTag("SoundManagers").GetComponent<SoundManagers>();
        audio_BGM = GameObject.FindGameObjectWithTag("BGM").GetComponent<SoundManagers>();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        uiManagers.lapsToGameOver = lapCourse;
        if (lapCourse == lapToWin)
        {
            Invoke("ShowFinishLap", 2f);
        }
    }

    private void ShowFinishLap()
    {
        uiManagers.finishLap.gameObject.SetActive(true);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RootObject"))
        {
            if (lapCourse >= lapToWin)
            {
                audio_sources.PlaySound("Finish");
                audio_BGM.PlaySound("Stop");
                audio_BGM.PlaySound("Clear");
                uiManagers.checkGameClear = true;
                lapCourse = 1;
            }
            else
            {
                // Debug.Log("True");
                lapCourse += 1;
                lapNums.checkLaps();

            }
        }
    }
    #endregion
}
