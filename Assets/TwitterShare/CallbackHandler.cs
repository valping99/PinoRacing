using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CallbackHandler : MonoBehaviour

{
    public ShareConfig config;
    string Message;
    string proxyURL;



#if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern string CallbackHandlerControl(string str1, string str2);

    [DllImport("__Internal")]
    private static extern string GetURL();
#endif

    // Start is called before the first frame update
    void Start()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
       CallbackHandlerControl(config.shareConfiguration.ShareMessage, config.shareConfiguration.proxyURL);
#endif

    }

    // Update is called once per frame
    void Update()
    {

    }
 
}
