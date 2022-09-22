using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 本当は継承クラスをゲームごとに作って常駐させてほしかったけどそうなってなかったのでごまかすためのシングルトン
/// ごまかしなので、こんなやり方を「正しいやり方」とは認識しないように要注意
/// </summary>
public class PinoArBehaviourSingleton : PinoArBehaviour
{
    private static PinoArBehaviourSingleton _singleton = null;
    public delegate void OnRegisterdRankingCallback(int ranking, bool isHighScore);
    OnRegisterdRankingCallback _callback;

    private void Start()
    {
        if (null == _singleton)
        {
            DontDestroyOnLoad(this);
            _singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    #region //通信完了時の処理//

    override protected void OnRegisteredRanking(int ranking, bool isHighScore)
    {
        if (null != _callback)
        {
            _callback(ranking, isHighScore);
            _callback = null;
        }
    }

    #endregion //通信完了時の処理//

    #region //ごまかしのpublic//

    public static void RegisterRankingPublic(string key, int score, OnRegisterdRankingCallback callback)
    {
        _singleton.RegisterRanking(key, score);
        _singleton._callback = callback;
    }
    public static void ShareResultPublic(string text)
    {
        PinoArBehaviour.ShareResult(text);
    }
    #endregion
}
