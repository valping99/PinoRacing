/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{

    #region Variables

    public float m_DistanceZSpawn = 40;
    public GameObject[] listObstacles;


    int m_ItemPosition;
    int m_NextPosition;
    float m_RootPosition = 0;
    float m_SidePositionX = 4.5f;
    List<float> m_XPosition;
    float m_ZPosition;

    public CharacterInputController m_Character;
    public CharacterCollider m_CharacterCollider;
    #endregion

    #region Unity Methods

    //     void Awake()
    //     {
    // #if UNITY_EDITOR || UNITY_STANDALONE

    // #else
    //     StartCoroutine(SpawnObstacles());
    // #endif
    //     }

    // Start is called before the first frame update
    void Start()
    {
        m_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();
        m_CharacterCollider = m_Character.gameObject.GetComponentInChildren<CharacterCollider>();

        m_XPosition = new List<float> { -m_SidePositionX, m_RootPosition, m_SidePositionX };
        //StartCoroutine(SpawnObstacles());

    }

    public void StartSpawnObjects()
    {
        StartCoroutine(SpawnObstacles());
    }

    #endregion

    #region Class
    IEnumerator SpawnObstacles()
    {
        // Debug.Log("Range: " + (listObstacles.Length - 1));

       
        /// Đạt ///
        if (m_Character.m_IsBoosting)
        {
            yield return new WaitForSeconds(0.5f);
        }
        ////
        else if (m_CharacterCollider.m_CurrentSpeed > 100)
        {
            yield return new WaitForSeconds(1.25f);
            // Debug.Log("Spawn 0.3s");
        }
        ////
        else if (m_CharacterCollider.m_CurrentSpeed >= 50)
        {
            yield return new WaitForSeconds(1.5f);
        }
        else if(m_CharacterCollider.m_CurrentSpeed >= 25)
        {
            yield return new WaitForSeconds(1.75f);
        }
        else if(m_CharacterCollider.m_CurrentSpeed >= 10)
        {
            yield return new WaitForSeconds(1.5f);
        }
        /// Đạt ///
        else if (m_CharacterCollider.m_CurrentSpeed > m_Character.m_BoostSpeed)
        {
            yield return new WaitForSeconds(0.5f);
            // Debug.Log("Spawn 0.5s");
        }
        else if (m_CharacterCollider.m_CurrentSpeed < 10)
        {
            yield return new WaitForSeconds(0.5f);
            //Debug.Log("Spawn 2.5s");
        }
        else
        {
            yield return new WaitForSeconds(1f);
            //Debug.Log("Spawn 1s");
        }

        m_ItemPosition = Random.Range(0, listObstacles.Length);
        m_NextPosition = Random.Range(0, m_XPosition.Count);

        // Debug.Log("X Position: " + m_XPosition[m_NextPosition]);
        // Debug.Log("Z Position: " + m_ZPosition);

        // if X = 0 -> is root position
        // if X = 4.5|-4.5 -> is side position
        //m_XPosition = m_CharacterCollider.transform.position.x == m_RootPosition ? m_RootPosition : m_CharacterCollider.transform.position.x == -m_SidePositionX ? -m_SidePositionX : m_SidePositionX;

        m_ZPosition = m_CharacterCollider.transform.position.z + m_DistanceZSpawn;

        if (m_ItemPosition == 1)
        {
            Instantiate(listObstacles[m_ItemPosition], new Vector3(m_XPosition[m_NextPosition], 7f, m_ZPosition), Quaternion.identity);
        }
        else
        {
            Instantiate(listObstacles[m_ItemPosition], new Vector3(m_XPosition[m_NextPosition], 0.5f, m_ZPosition), Quaternion.identity);
        }


        StartCoroutine(SpawnObstacles());
    }
    #endregion
}
