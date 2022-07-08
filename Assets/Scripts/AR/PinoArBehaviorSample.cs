using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinoArBehaviorSample : PinoArBehaviour
{
    #region  //UIの参照//

    [Header("ここからSample")]
    [Space(20)]
    [SerializeField]
    private Text scoreLabel;
    [SerializeField]
    private Text rankingLabel;
    [SerializeField]
    private Text highscoreLabel;
    [SerializeField]
    private Text nicknameLabel;
    [SerializeField]
    private Button shareButton;
    [SerializeField]
    private Button registerButton;
    [SerializeField]
    private Button plusButton;
    [SerializeField]
    private Button minusButton;
    [SerializeField]
    private Button highscoreButton;
    [SerializeField]
    private Button quitButton;

    #endregion //UIの参照//

    #region //情報キープ用変数//
    private int score = 0;
    #endregion //情報キープ用変数//

    private void Start()
    {
        shareButton.onClick.AddListener(OnClickShare);
        registerButton.onClick.AddListener(OnClickRegister);
        plusButton.onClick.AddListener(OnClickPointUp);
        minusButton.onClick.AddListener(OnClickPointDown);
        quitButton.onClick.AddListener(OnClickQuit);

        highscoreButton.onClick.AddListener(ReloadHighscore);
        ReloadHighscore();
    }

    #region //ボタンイベント//

    public void SetNickname(string s)
    {
        nicknameLabel.text = "nickname:" + s;
        Debug.Log("SetNickname:" + s);
    }

    public void OnClickRegister()
    {
        RegisterRanking("sample", score);
    }

    public void OnClickShare()
    {
        ShareResult("share sample game. score: " + score);
    }

    private void UpdatePoint(int s)
    {
        score = s;
        scoreLabel.text = score.ToString();
    }

    public void OnClickPointUp()
    {
        UpdatePoint(score + 10);
    }

    public void OnClickPointDown()
    {
        UpdatePoint(score - 10);
    }

    public void OnClickQuit()
    {
        QuitGame();
    }

    private void ReloadHighscore() {
        int h = GetHighscore("sample");
        highscoreLabel.text = "highscore: " + h.ToString();
    }

    #endregion //ボタンイベント//

    #region //通信完了時の処理//

    override protected void OnRegisteredRanking(int ranking, bool isHighScore)
    {
        rankingLabel.text = ranking + "st / " + isHighScore.ToString();
        ReloadHighscore();
    }

    #endregion //通信完了時の処理//
}
