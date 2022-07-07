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
    #endregion
    #region Unity Method
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
    }
    #endregion
    #region class
    public void setRank()
    {
        int values = listRanking.Count - 1;
        int timer = (int)managers.currentTime;
        for (int i = 0; i < setRankByTimed.Length; i++)
        {
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
        
        managers.messageText.text = textRank[values];
        Instantiate(listRanking[values], rectTransform.transform.position, Quaternion.identity, transformParent);
        checkRank = false;

        // Pino AR
        RegisterRankingKey(textRank[values]);
        GetHighscore(textRank[values]);
    }

    public void RegisterRankingKey(string key)
    {
        PinoArBehaviour.RegisterRankingKey(key);
    }
    
    public void GetHighscore(string key)
    {
        PinoArBehaviour.GetHighscore(key);
    }
    #endregion
}
