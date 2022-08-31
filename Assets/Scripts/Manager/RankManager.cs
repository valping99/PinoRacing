using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : PinoArBehaviour
{
    #region Variables
    public List<GameObject> listRanking;

    public RectTransform rectTransform;

    public List<string> textRank;

    public Transform transformParent;

    private UIManager managers;

    public int[] setRankByTimed;

    public bool checkRank = true;

    private bool outRank;

    private int score;

    [SerializeField] private GameObject RankNumber;
    [SerializeField] private GameObject OutRankNumber;

    #endregion
    #region Unity Method
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
    }
    #endregion
    #region class

    public void check()
    {
        if (outRank)
        {
            RankNumber.gameObject.SetActive(false);
            OutRankNumber.gameObject.SetActive(true);
        }
        else
        {
            RankNumber.gameObject.SetActive(true);
            OutRankNumber.gameObject.SetActive(false);
        }
    }
    public void setRank()
    {
        int values = listRanking.Count - 1;
        int timer = (int)managers.currentTime;
        for (int i = 0; i < setRankByTimed.Length; i++)
        {
            if (i >= setRankByTimed.Length)
            {
                values = i - 1;
                return;
            }
            if (timer >= setRankByTimed[i] && timer < setRankByTimed[i - 1])
            {
                if (i >= 1)
                {

                    values = i - 1;
                }
                else
                {
                    values = 0;
                }
            }
        }
        // Debug.Log(values);
        
        //managers.messageText.text = textRank[values];
        Instantiate(listRanking[values], rectTransform.transform.position, Quaternion.identity, transformParent);
        checkRank = false;

        // Pino AR

        //RegisterRankingKey(textRank[values]);
        //RegisterScore(GetScore.m_score);
        score = (int)GetScore.m_score;
        GetHighscore(textRank[values]);
        RegisterRanking(textRank[values], score);
        Invoke("check", .1f);
    }


    //protected void RegisterRankingKey(string key)
    //{
    //    PinoArBehaviour.RegisterRankingKey(key);
    //}

    protected void RegisterRanking(string key, int score)
    {
        PinoArBehaviour.RegisterRankingKey(key);
        PinoArBehaviour.RegisterScore(score);
    }
    override protected void OnRegisteredRanking(int ranking, bool isHighScore)
    {
        base.OnRegisteredRanking(ranking, isHighScore);
        if (ranking < 10000)
        {
            outRank = false;
            managers.messageText.text = ranking.ToString();
            Debug.Log(ranking.ToString());
        }
        else
        {
            outRank = true;
        }
    }

    protected void GetHighscore(string key)
    {
        PinoArBehaviour.GetHighscore(key);
    }
    #endregion
}
