using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetScore : MonoBehaviour
{
    #region Variables
    [Tooltip("Get Component")]
    [SerializeField]
    private UIManager managers;

    [Header("Timer & Score")]
    public static float m_score;
    public float m_timeRemaining;
    public float m_currentTimer;
    public float m_maxTimer;
    public float m_tempScore;

    //public TextMeshProUGUI _Text;
    #endregion
    #region Unity Method
    void Start()
    {
        managers = FindObjectOfType<UIManager>();
        m_maxTimer = managers.maxTimeValue;
    }

    void Update()
    {
        GetValue();
        SetScore();
        if(managers.endGame){
            //RegisterScore((int)m_score);
            managers.endGame = false;
            //_Text.text = m_score.ToString().Replace(".",",");
        }
    }
    #endregion
    #region Class
    void GetValue()
    {
        m_currentTimer = managers.currentTime;
    }

    void SetScore()
    {
        m_timeRemaining = m_maxTimer - m_currentTimer;
        m_score = m_tempScore * m_timeRemaining;
    }

    #endregion
}
