using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReferencesManager : MonoBehaviour
{
    #region Variables
    int currentTime;
    private UIManager managers;
    private string shareNameParameter = "Come and play with me!";
    private string shareDescriptionParam = "I'm finished this game with: ";
    private const string share_Address = "http://twitter.com/intent/tweet";
    private const string share_Language = "en";
    private const string UploadMediaURL = "https://upload.twitter.com/1.1/media/upload.json";
    private const string PostTweetURL = "https://api.twitter.com/1.1/statuses/update.json";
    private Texture2D texture;

    #endregion
    //private string path = Application.persistentDataPath + "/Resources/test.png";

    #region ShareToTwitter

    void Start()
    {
        managers = FindObjectOfType<UIManager>();
    }
    public void PressedShareButton()
    {
        //getImages();
        ////
        //var width = Screen.width;
        //var height = Screen.height;
        //var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        //tex.ReadPixels(new Rect(0, 0, width, height),0, 0);
        //tex.Apply();
        //byte[] screenshot = tex.EncodeToPNG();
        //var wwwForm = new WWWForm();
        //wwwForm.AddBinaryData("image", screenshot, "InteractiveConsole.png");
        //

        currentTime = (int)managers.currentTime;
        Application.OpenURL(share_Address + "?text=" + WWW.EscapeURL(shareNameParameter + "\n" +
            shareDescriptionParam + currentTime + " Seconds") );
    }

    public void getImages()
    {
        string folderpath = Application.streamingAssetsPath + @"/Resources/Screenshot";
        
        object[] images = Resources.LoadAll(folderpath);
        for(int i = 0; i < images.Length; i++)
        {
            texture = (images[i] as Texture2D);
            Debug.Log(texture);            
        }
        Debug.Log(folderpath);
    }
    #endregion
}
