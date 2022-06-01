using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    private UIManager managers;
    private string shareNameParameter = "Come and play with me!";
    private string shareDescriptionParam = "My scores is: ";
    private const string share_Address = "http://twitter.com/intent/tweet";
    private const string share_Language = "en";

    //private string path = Application.persistentDataPath + "/Resources/test.png";

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
        string folderpath = Application.streamingAssetsPath + @"/Resources";
        Object[] images = Resources.LoadAll(folderpath);
        for(int i = 0; i < images.Length; i++)
        {
            Texture2D texture = (images[i] as Texture2D);
            Debug.Log(texture);
            
        }
    }
}
