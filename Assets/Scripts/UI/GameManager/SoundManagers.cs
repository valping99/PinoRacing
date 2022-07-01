using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagers : MonoBehaviour
{
    public AudioSource audio_source;

    public AudioClip tapSE;
    public AudioClip countDownSE;
    public AudioClip finishSE;
    public AudioClip clearBGM;
    public AudioClip itemIndication;
    public AudioClip rankDisplay;


    public AudioClip topScreen;
    public AudioClip itemSE;
    public AudioClip damageSE;
    public AudioClip gameBGM;
    public AudioClip dashBoardSE;
    public AudioClip stingPickSE;


    void Start()
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
    }
}
