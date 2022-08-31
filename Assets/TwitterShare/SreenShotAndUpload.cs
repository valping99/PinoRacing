
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

#if !UNITY_EDITOR && UNITY_WEBGL
using System.Runtime.InteropServices;
#endif

public class SreenShotAndUpload : MonoBehaviour
{
    public ShareConfig config;
    int screenshotSize;
    string proxyURL;
    string webURL;
    UnityWebRequest request;


#if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
     private static extern string SaveScreenCapture(string media_base64) ;

      [DllImport("__Internal")]
    private static extern void SaveMediaBase64(string mediaBase64);

    [DllImport("__Internal")]
    private static extern void  Redirect(string url);

    [DllImport("__Internal")]
    private static extern string GetURLCallBack();

#endif

    // Start is called before the first frame update
    void Start()
    {
        Config();
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void saveMedia(string i_img64)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        SaveScreenCapture(i_img64);
#endif
    }


    public void TweetWithScreenshot()
    {
        StartCoroutine(UploadPicture());
    }
  

    IEnumerator UploadPicture()
    {
        
        yield return new WaitForEndOfFrame();
        Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();
        float ratio = (float)tex.width / (float)tex.height;
        TextureScale.Scale(tex,(int)(screenshotSize ), (int)(screenshotSize /ratio));
        var img64 = Convert.ToBase64String(tex.EncodeToJPG());
        byte[] png = tex.EncodeToPNG();

#if !UNITY_EDITOR && UNITY_WEBGL
        SaveMediaBase64(img64);
#endif
        StartCoroutine(TwitterRequestToken());
    }
   

    IEnumerator TwitterRequestToken()
    {
        string REQUEST_URL = "";
        REQUEST_URL = proxyURL + "/oauth/request_token";
        WWWForm form = new WWWForm();
        form.AddField("callbackURL", webURL);

        request = UnityWebRequest.Post(REQUEST_URL, form);
        request.SetRequestHeader("Cookie", "lang=en");

        yield return request.SendWebRequest();
        switch (request.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError(request.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError(request.error);
                break;
            case UnityWebRequest.Result.Success:
                {
                    RequestToken rq = RequestToken.CreateFromJSON(request.downloadHandler.text);

                #if !UNITY_EDITOR && UNITY_WEBGL
                    Redirect("https://api.twitter.com/oauth/authenticate?oauth_token=" + rq.oauth_token);
                #endif
                   
                }
                
                break;
        }


    }

    void Config()
    {
        proxyURL = config.shareConfiguration.proxyURL;
        webURL = config.shareConfiguration.webURL;


        if (config.shareConfiguration.imageQuality == ImageQuality.SD)
        {
            screenshotSize = 480;
        } else if (config.shareConfiguration.imageQuality == ImageQuality.HD)
        {
            screenshotSize = 720;
        } else
        {
            screenshotSize = 1080;
        }
    }
    





    [Serializable]
    public class RequestToken
    {
        public string oauth_token;
        public string oauth_token_secret;
        public string oauth_callback;
        public static RequestToken CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<RequestToken>(jsonString);
        }
        
    }
}


