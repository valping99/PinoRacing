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

        TapSE();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Tap":
                audio_source.clip = tapSE;
                audio_source.PlayOneShot(tapSE, 1f);
                break;

            case "TopScreen":
                audio_source.clip = topScreen;
                audio_source.loop = true;
                audio_source.PlayOneShot(topScreen, 0.6f);
                StartCoroutine(ReSound("TopScreen"));
                break;


            case "CountDown":
                audio_source.clip = countDownSE;
                audio_source.PlayOneShot(countDownSE, 1f);
                break;

            case "No4":
                audio_source.clip = itemSE;
                audio_source.PlayOneShot(itemSE, 1f);
                break;

            case "No5":
                audio_source.clip = damageSE;
                audio_source.PlayOneShot(damageSE, 1f);
                break;

            case "Finish":
                audio_source.clip = finishSE;
                audio_source.PlayOneShot(finishSE, 1f);
                break;

            case "BGM":
                audio_source.clip = gameBGM;
                audio_source.loop = true;
                audio_source.PlayOneShot(gameBGM, 0.6f);
                StartCoroutine(ReSound("BGM"));
                break;

            case "Clear":
                audio_source.clip = clearBGM;
                audio_source.loop = true;
                audio_source.PlayOneShot(clearBGM, 0.6f);
                StartCoroutine(ReSound("Clear"));
                break;

            case "Indication":
                audio_source.clip = itemIndication;
                audio_source.PlayOneShot(itemIndication, 1f);
                break;

            case "Rank":
                audio_source.clip = rankDisplay;
                audio_source.PlayOneShot(rankDisplay, 1f);
                break;

            case "No11":
                audio_source.clip = dashBoardSE;
                audio_source.PlayOneShot(dashBoardSE, 1f);
                break;

            case "Stop":
                audio_source.Stop();
                break;

            case "No12":
                audio_source.clip = stingPickSE;
                audio_source.PlayOneShot(stingPickSE, 1f);
                break;
        }
    }

    public void TapSE()
    {
        PlaySound("Tap");
    }

    IEnumerator ReSound(string sound)
    {
        yield return new WaitUntil(() => audio_source.isPlaying == false);
        PlaySound(sound);
    }
}
