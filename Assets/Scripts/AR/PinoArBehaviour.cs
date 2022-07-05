using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PinoArBehaviour : MonoBehaviour
{
    #region //ARカメラ同期関連//

    //================
    //　概要
    //----------------
    //　　ARの座標系におけるカメラと箱の位置関係を再現してくれます。
    //----------------
    //　AR用カメラの設定
    //----------------
    //　　AR連動するオブジェクトを映すカメラを設定してください。
    //　　ゲーム本体の描画カメラとは別にカメラを用意する想定です。
    //----------------
    //　AR仮想箱の設定
    //----------------
    //　　ARの仮想箱及び箱に連動して表示するものを配置したオブジェクトツリーのルートを設定してください。
    //　　（箱自体をゲーム側で描画しないのであればアテで置いて表示消すなどしてください）
    //　　箱の配置は
    //　　　Position(0,0,0)
    //　　　Rotation(0,0,0)
    //　　　Scale(1.585366,0.3048781,1)
    //　　です。（これを前提に計算しています）
    //================

    [Header("AR仮想箱")]
    [SerializeField]
    private GameObject box;

    [Header("AR用のカメラ")]
    [SerializeField]
    private Camera arCamera;

    #region //演算//

    private float cameraQuaternionX = 0;
    private float cameraQuaternionY = 0;
    private float cameraQuaternionZ = 0;
    private float cameraQuaternionW = 0;

    private float boxQuaternionX = 0;
    private float boxQuaternionY = 0;
    private float boxQuaternionZ = 0;
    private float boxQuaternionW = 0;


    // ==================================================
    // Web→Unityのインタフェースサンプル
    // ==================================================

    public void SetCameraX(float x)
    {
        arCamera.transform.position = new Vector3(x, arCamera.transform.position.y, arCamera.transform.position.z);
        Debug.Log("SetCameraX:" + x + " / " + arCamera.transform.position);
    }
    public void SetCameraY(float y)
    {
        arCamera.transform.position = new Vector3(arCamera.transform.position.x, y, arCamera.transform.position.z);
        Debug.Log("SetCameraY:" + y + " / " + arCamera.transform.position);
    }
    public void SetCameraZ(float z)
    {
        arCamera.transform.position = new Vector3(arCamera.transform.position.x, arCamera.transform.position.y, z);
        Debug.Log("SetCameraZ:" + z + " / " + arCamera.transform.position);
    }
    public void SetCameraQuaternionX(float x)
    {
        cameraQuaternionX = x;
        Debug.Log("SetCameraQuaternionX:" + x);
    }
    public void SetCameraQuaternionY(float y)
    {
        cameraQuaternionY = y;
        Debug.Log("SetCameraQuaternionY:" + y);
    }
    public void SetCameraQuaternionZ(float z)
    {
        cameraQuaternionZ = z;
        Debug.Log("SetCameraQuaternionZ:" + z);
    }
    public void SetCameraQuaternionW(float w)
    {
        cameraQuaternionW = w;
        Debug.Log("SetCameraQuaternionW:" + w);
    }

    public void ApplyCameraQuaternion()
    {
        Quaternion q = new Quaternion(
            cameraQuaternionX,
            cameraQuaternionY,
            cameraQuaternionZ,
            cameraQuaternionW
        );
        arCamera.transform.rotation = q;
        Debug.Log("ApplyCameraQuaternion:" + arCamera.transform.rotation.eulerAngles);
    }

    public void SetFOV(float fov)
    {
        arCamera.fieldOfView = fov;
        Debug.Log("SetFOV:" + fov);
    }

    public void SetBoxX(float x)
    {
        box.transform.position = new Vector3(x, box.transform.position.y, box.transform.position.z);
        Debug.Log("SetBoxX:" + x + " / " + box.transform.position);
    }
    public void SetBoxY(float y)
    {
        box.transform.position = new Vector3(box.transform.position.x, y, box.transform.position.z);
        Debug.Log("SetBoxY:" + y + " / " + box.transform.position);
    }
    public void SetBoxZ(float z)
    {
        box.transform.position = new Vector3(box.transform.position.x, box.transform.position.y, z);
        Debug.Log("SetBoxZ:" + z + " / " + box.transform.position);
    }
    public void SetBoxQuaternionX(float x)
    {
        boxQuaternionX = x;
        Debug.Log("SetBoxQuaternionX:" + x);
    }
    public void SetBoxQuaternionY(float y)
    {
        boxQuaternionY = y;
        Debug.Log("SetBoxQuaternionY:" + y);
    }
    public void SetBoxQuaternionZ(float z)
    {
        boxQuaternionZ = z;
        Debug.Log("SetBoxQuaternionZ:" + z);
    }
    public void SetBoxQuaternionW(float w)
    {
        boxQuaternionW = w;
        Debug.Log("SetBoxQuaternionW:" + w);
    }

    public void ApplyBoxQuaternion()
    {
        Quaternion q = new Quaternion(
            boxQuaternionX,
            boxQuaternionY,
            boxQuaternionZ,
            boxQuaternionW
        );
        box.transform.rotation = q;
        Debug.Log("ApplyBoxQuaternion:" + box.transform.rotation.eulerAngles);
    }

    public void SetBoxScale(float s)
    {
        box.transform.localScale = new Vector3(s, s, s);
    }

    #endregion //演算//

    #endregion //ARカメラ同期関連//

    #region //ランキング通信関連関連//

    /// <summary>
    /// ランキング送信時に呼び出してください
    /// </summary>
    /// <param name="key">ランキングのキー。かぶらないように　ゲームの識別子＋ゲーム内の分別　で。</param>
    /// <param name="score">スコア</param>
    protected void RegisterRanking(string key, int score)
    {
        _RegisterRanking(key, score);
    }

    /// <summary>
    /// 通信終了時の関数
    /// 使用する場合オーバーライドしてください
    /// </summary>
    /// <param name="ranking">ランキング順位</param>
    /// <param name="isHighScore">ハイスコアの場合true</param>
    virtual protected void OnRegisteredRanking(int ranking, bool isHighScore)
    {
    }

    #region //内部処理//

    private int ranking = 0;
    private bool highscoreFlag = false;
    private const int STEPS = 2;    //通信終了時に呼ばれるSendMessageの数//
    private int step = 0;   //SendMessage進捗管理//

    private bool _RegisterRanking(string key, int score)
    {
        //連投防止実装するならここ//
        if (false)
        {
            return false;
        }
        step = 0;
        RegisterScore(score);
        RegisterRankingKey(key);

        // STUB 実際はWeb側からSendMessage経由で、該当の関数が呼び出される
#if UNITY_EDITOR
        StubRankingResponse(score);
#endif
        return true;
    }
#if UNITY_EDITOR
    static private int stubRankingHighScore = 0;
    private void StubRankingResponse(int score)
    {
        int rank = (1000 - score) / 10;
        if (rank <= 0)
        {
            rank = 1;
        }
        SetRanking(rank);
        if (stubRankingHighScore < score)
        {
            SetHighscoreFlag(1);
            stubRankingHighScore = score;
        }
        else
        {
            SetHighscoreFlag(0);
        }
    }
#endif

    // ==================================================
    // Unity→Webのインタフェース定義 (pino-interface.jslibと対応)
    // ==================================================

    // 以下、editorから動かす際のスタブメソッド
#if UNITY_EDITOR
    protected static void ShareResult(string text)
    {
        Debug.Log("stub: ShareResult\n" + text);
    }
    protected static void RegisterRankingKey(string rankingKey)
    {
        Debug.Log("stub: RegisterRankingKey\n" + rankingKey);
    }
    protected static void RegisterScore(int score)
    {
        Debug.Log("stub: RegisterScore\n" + score);
    }
    protected static int GetHighscore(string rankingKey)
    {
        Debug.Log("stub: GetHighscore\n" + rankingKey);
        return stubRankingHighScore;
    }
    protected static void QuitGame()
    {
        Debug.Log("stub: QuitGame");
    }

    // 以下、実際に使うjs実装への参照
#else
    [DllImport("__Internal")]
    protected static extern void ShareResult(string text);
    [DllImport("__Internal")]
    protected static extern void RegisterRankingKey(string rankingKey);
    [DllImport("__Internal")]
    protected static extern void RegisterScore(int score);
    [DllImport("__Internal")]
    protected static extern int GetHighscore(string rankingKey);
    [DllImport("__Internal")]
    protected static extern void QuitGame();
#endif

    #region //SendMessage//
    public void SetRanking(int r)
    {
        ranking = r;
        UpdateStep();
    }

    public void SetHighscoreFlag(int f)
    {
        highscoreFlag = f > 0;
        UpdateStep();
    }

    private void UpdateStep()
    {
        step++;
        if (STEPS == step)
        {
            OnRegisteredRanking(ranking, highscoreFlag);
        }
    }
    #endregion //SendMessage//

    #endregion //内部処理//

    #endregion //ランキング通信関連関連//
}
