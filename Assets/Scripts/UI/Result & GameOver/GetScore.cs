using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : PinoArBehaviour
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
            RegisterScore((int)m_score);
            managers.endGame = false;
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

    public void RegisterScore(int score)
    {
        PinoArBehaviour.RegisterScore(score);
    }
    #endregion
}
