/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUtility : MonoBehaviour
{

    #region Variables
    static AudioManager s_AudioManager;

    public enum AudioGroups
    {
        DamageTick,
        Impact,
        Pickup,
        HUDVictory,
        HUDObjective
    }

    #endregion

    #region Class

    public static void CreateSFX(AudioClip clip, Vector3 position, AudioGroups audioGroup, float spatialBlend,
                float rolloffDistanceMin = 1f)
    {
        GameObject impactSfxInstance = new GameObject();
        impactSfxInstance.transform.position = position;
        AudioSource source = impactSfxInstance.AddComponent<AudioSource>();
        source.clip = clip;
        source.spatialBlend = spatialBlend;
        source.minDistance = rolloffDistanceMin;
        source.Play();

        // source.outputAudioMixerGroup = GetAudioGroup(audioGroup);

    }

    public static AudioMixerGroup GetAudioGroup(AudioGroups group)
    {
        // if (s_AudioManager == null)
        //     s_AudioManager = GameObject.FindObjectOfType<AudioManager>();

        // var groups = s_AudioManager.FindMatchingGroups(group.ToString());

        // if (groups.Length > 0)
        //     return groups[0];

        // Debug.LogWarning("Didn't find audio group for " + group.ToString());
        return null;
    }

    public static void SetMasterVolume(float value)
    {
        // if (s_AudioManager == null)
        //     s_AudioManager = GameObject.FindObjectOfType<AudioManager>();

        // if (value <= 0)
        //     value = 0.001f;
        // float valueInDb = Mathf.Log10(value) * 20;

        // s_AudioManager.SetFloat("MasterVolume", valueInDb);
    }

    public static float GetMasterVolume()
    {
        // if (s_AudioManager == null)
        //     s_AudioManager = GameObject.FindObjectOfType<AudioManager>();

        // s_AudioManager.GetFloat("MasterVolume", out var valueInDb);
        return Mathf.Pow(10f, /*valueInDb*/ 0 / 20.0f);
    }
    #endregion
}
