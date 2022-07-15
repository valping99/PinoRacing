using System.Runtime.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagers : MonoBehaviour
{
    #region Variables
    [Tooltip("Audio Source")]
    public AudioSource m_AudioSource;

    [Tooltip("BGM")]
    public AudioClip clearBGM, gameBGM, topScreenBGM, gameOverBGM;

    [Tooltip("Item Sound Effect")]
    public AudioClip milkSound, iceSound, dashBoardSound, stickSound;

    [Tooltip("UI Sound Effect")]
    public AudioClip tapSound, countDownSound, finishSound, itemIndication, rankDisplay, strokeSound, warningSound, laneMoveSound, engineSound;

    private Command hit, stop, loop;

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
        tapSound = Resources.Load<AudioClip>("Audio/No1");
        topScreenBGM = Resources.Load<AudioClip>("Audio/No2");
        countDownSound = Resources.Load<AudioClip>("Audio/No3");
        milkSound = Resources.Load<AudioClip>("Audio/No4");
        iceSound = Resources.Load<AudioClip>("Audio/No5");
        finishSound = Resources.Load<AudioClip>("Audio/No6");
        gameBGM = Resources.Load<AudioClip>("Audio/No7");
        clearBGM = Resources.Load<AudioClip>("Audio/No8");
        itemIndication = Resources.Load<AudioClip>("Audio/No9");
        rankDisplay = Resources.Load<AudioClip>("Audio/No10");
        dashBoardSound = Resources.Load<AudioClip>("Audio/No11");
        stickSound = Resources.Load<AudioClip>("Audio/No12");
        strokeSound = Resources.Load<AudioClip>("Audio/No13");
        warningSound = Resources.Load<AudioClip>("Audio/No14");
        laneMoveSound = Resources.Load<AudioClip>("Audio/No15");
        engineSound = Resources.Load<AudioClip>("Audio/No16");
        gameOverBGM = Resources.Load<AudioClip>("Audio/No17");

        hit = new PlaySound();
        stop = new StopSound();
        loop = new PlayLoopSound();
    }

    public void PlaySound(SoundType type)
    {
        switch (type)
        {
            case SoundType.Tap:
                hit.Execute(m_AudioSource, tapSound, 0.3f);
                break;
            case SoundType.TopScreen:
                loop.Execute(m_AudioSource, topScreenBGM, 0.2f);
                break;
            case SoundType.CountDown:
                hit.Execute(m_AudioSource, countDownSound, 0.5f);
                break;
            case SoundType.Milk:
                hit.Execute(m_AudioSource, milkSound, 0.1f);
                break;
            case SoundType.Ice:
                hit.Execute(m_AudioSource, iceSound, 0.4f);
                break;
            case SoundType.Finish:
                hit.Execute(m_AudioSource, finishSound, 0.5f);
                break;
            case SoundType.BGM:
                loop.Execute(m_AudioSource, gameBGM, 0.5f);
                break;
            case SoundType.Clear:
                loop.Execute(m_AudioSource, clearBGM, 0.2f);
                break;
            case SoundType.Indication:
                hit.Execute(m_AudioSource, itemIndication, 0.5f);
                break;
            case SoundType.Rank:
                hit.Execute(m_AudioSource, rankDisplay, 0.5f);
                break;
            case SoundType.DashBoost:
                hit.Execute(m_AudioSource, dashBoardSound, 0.3f);
                break;
            case SoundType.Stop:
                stop.Execute(m_AudioSource, null, 0);
                break;
            case SoundType.Stick:
                hit.Execute(m_AudioSource, stickSound, 1f);
                break;
            case SoundType.Stroke:
                hit.Execute(m_AudioSource, strokeSound, 0.5f);
                break;
            case SoundType.Warning:
                loop.Execute(m_AudioSource, warningSound, 0.5f);
                break;
            case SoundType.LaneMove:
                hit.Execute(m_AudioSource, laneMoveSound, 1f);
                break;
            case SoundType.Engine:
                loop.Execute(m_AudioSource, engineSound, 1f);
                break;
            case SoundType.GameOver:
                loop.Execute(m_AudioSource, gameOverBGM, 0.2f);
                break;
        }
    }

    public void TapSE()
    {
        PlaySound(SoundType.Tap);
    }
    #endregion
}
