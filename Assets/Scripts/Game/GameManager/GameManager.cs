/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Variables
    static public GameManager instance { get { return s_Instance; } }
    static protected GameManager s_Instance;

    public GameObject m_DisplayDistance;
    public int m_Distance;
    public bool m_IsRunning;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_IsRunning)
        {
            m_IsRunning = true;
            StartCoroutine(CountDistance());
        }
        //Debug.Log(m_Distance);
    }


    #endregion

    #region Class

    IEnumerator CountDistance()
    {
        m_Distance += 1;
        // m_DisplayDistance.GetComponent<TextMesh>().text = "" + m_Distance.ToString();
        yield return new WaitForSeconds(0.2f);
        m_IsRunning = true;
        StartCoroutine(CountDistance());

    }
    #endregion
}
