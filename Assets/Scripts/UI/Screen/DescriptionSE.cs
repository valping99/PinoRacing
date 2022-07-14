using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionSE : MonoBehaviour
{
    private SoundManagers audio_source;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = FindObjectOfType<SoundManagers>();
    }

    public void TapSE()
    {
        audio_source.TapSE();
    }
}
