using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public string shareNameParameter = "My Highest scored!";
    public string shareDescriptionParam = "";
    private const string share_Address = "http://twitter.com/intent/tweet";
    private const string share_Language = "en";

    public void PressedShareButton()
    {
        var tex = Resources.LoadAll("screen_1920x1080_0.png");
        Debug.Log(tex);
        Application.OpenURL(share_Address + "?text=" + WWW.EscapeURL(shareNameParameter +
            shareDescriptionParam ));
    }
}
