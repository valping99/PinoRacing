/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSelfDestruct : MonoBehaviour
{

    #region Variables
    public float LifeTime = 1f;

    float m_SpawnTime;
    #endregion

    #region Unity Methods


    void Awake()
    {
        m_SpawnTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > m_SpawnTime + LifeTime)
        {
            Destroy(gameObject);
        }
    }


    #endregion

    #region Class

    #endregion
}
