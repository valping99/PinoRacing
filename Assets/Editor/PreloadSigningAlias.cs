using UnityEngine;
using UnityEditor;
using System.IO;
 
[InitializeOnLoad]
public class PreloadSigningAlias
{ 
    static PreloadSigningAlias ()
    {
        PlayerSettings.Android.keystorePass = System.Environment.GetEnvironmentVariable("ANDROID_KEYSTORE_PASSWORD");
        PlayerSettings.Android.keyaliasName = System.Environment.GetEnvironmentVariable("ANDROID_KEYSTORE_ALIAS");
        PlayerSettings.Android.keyaliasPass = System.Environment.GetEnvironmentVariable("ANDROID_KEYSTORE_ALIAS_PASSWORD");
    }
}