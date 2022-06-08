using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReferencesManager : MonoBehaviour
{
    #region Variables
    private UIManager managers;
    private string shareNameParameter = "Come and play with me!";
    private string shareDescriptionParam = "My scores: ";
    private const string share_Address = "http://twitter.com/intent/tweet";
    private const string share_Language = "en";

    #endregion
    //private string path = Application.persistentDataPath + "/Resources/test.png";

    #region ShareToTwitter
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
    }
    public void PressedShareButton()
    {
        Application.OpenURL(share_Address + "?text=" + WWW.EscapeURL(shareNameParameter + "\n" +
            shareDescriptionParam + managers.currentScore));
    }

    public void getImages()
    {
        //string folderpath = Application.streamingAssetsPath + @"/Resources";
        /**
        object[] images = resources.loadall(folderpath);
        for(int i = 0; i < images.length; i++)
        {
            texture2d texture = (images[i] as texture2d);
            debug.log(texture);            
        }
        **/
    }
    #endregion
}
