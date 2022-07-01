using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
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
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
    }

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
    }
    #endregion
}
