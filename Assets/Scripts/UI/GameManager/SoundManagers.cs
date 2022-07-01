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

    void Start()
    {
        tapSE = Resources.Load<AudioClip>("No1");
        countDownSE = Resources.Load<AudioClip>("No3");
        finishSE = Resources.Load<AudioClip>("No6");
        clearBGM = Resources.Load<AudioClip>("No8");
        itemIndication = Resources.Load<AudioClip>("No9");
        rankDisplay = Resources.Load<AudioClip>("No10");
    }
}
