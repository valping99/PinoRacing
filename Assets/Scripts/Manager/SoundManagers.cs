using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagers : MonoBehaviour
{
    #region Variables
    [Header("Audio Source")]
    public AudioSource audio_source;

    [Header("BGM")]
    public AudioClip clearBGM;
    public AudioClip gameBGM;
    public AudioClip topScreen;

    [Header("Item Sound Effect")]
    public AudioClip itemSE;
    public AudioClip damageSE;
    public AudioClip dashBoardSE;
    public AudioClip stingPickSE;

    [Header("UI Sound Effect")]
    public AudioClip tapSE;
    public AudioClip countDownSE;
    public AudioClip finishSE;
    public AudioClip itemIndication;
    public AudioClip rankDisplay;

    private Command hit,stop,loop;

    #endregion
    #region Unity Method
    void Start()
    {
        GetResourcesAudio();
    }

    #endregion
    #region Class

    void GetResourcesAudio()
    {
        tapSE = Resources.Load<AudioClip>("Audio/No1");
        topScreen = Resources.Load<AudioClip>("Audio/No2");
        countDownSE = Resources.Load<AudioClip>("Audio/No3");
        itemSE = Resources.Load<AudioClip>("Audio/No4");
        damageSE = Resources.Load<AudioClip>("Audio/No5");
        finishSE = Resources.Load<AudioClip>("Audio/No6");
        gameBGM = Resources.Load<AudioClip>("Audio/No7");
        clearBGM = Resources.Load<AudioClip>("Audio/No8");
        itemIndication = Resources.Load<AudioClip>("Audio/No9");
        rankDisplay = Resources.Load<AudioClip>("Audio/No10");
        dashBoardSE = Resources.Load<AudioClip>("Audio/No11");
        stingPickSE = Resources.Load<AudioClip>("Audio/No12");

        hit = new PlaySound();
        stop = new StopSound();
        loop = new PlayLoopSound();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Tap":
                hit.Execute(audio_source,tapSE,0.6f);
                break;
            case "TopScreen":
                loop.Execute(audio_source,topScreen,0.2f);
                break;
            case "CountDown":
                hit.Execute(audio_source,countDownSE,0.6f);
                break;
            case "No4":
                hit.Execute(audio_source,itemSE,0.2f);
                break;
            case "No5":
                hit.Execute(audio_source,damageSE,0.6f);
                break;
            case "Finish":
                hit.Execute(audio_source,finishSE,0.6f);
                break;
            case "BGM":
                loop.Execute(audio_source,gameBGM,0.2f);
                break;
            case "Clear":
                loop.Execute(audio_source,clearBGM,0.2f);
                break;
            case "Indication":
                hit.Execute(audio_source,itemIndication,0.6f);
                break;
            case "Rank":
                hit.Execute(audio_source,rankDisplay,0.6f);
                break;
            case "No11":
                hit.Execute(audio_source,dashBoardSE,0.6f);
                break;
            case "Stop":
                stop.Execute(audio_source,null,0);
                break;
            case "No12":
                hit.Execute(audio_source,stingPickSE,1f);
                break;
        }
    }

    public void TapSE()
    {
        PlaySound("Tap");
    }

    #endregion
}
