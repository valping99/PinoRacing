using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ShareConfig", menuName = "TwitterConfig/ShareConfig", order = 1)]
public class ShareConfig : ScriptableObject
{
    public ShareConfiguration shareConfiguration;

}

[System.Serializable]
public class ShareConfiguration
{

    [Header("Proxy Server ")]
    public string proxyURL;


    public string webURL;

    [Header("Quality")]
    public ImageQuality imageQuality;



    [Header("Share Message")]
    public string ShareMessage;

}

[System.Serializable]
public enum ImageQuality
{
    SD,
    HD,
    FullHD
}