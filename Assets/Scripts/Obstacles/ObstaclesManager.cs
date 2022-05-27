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
    public Transform[] listObstacles;


    int m_ItemPosition;
    int m_NextPosition;
    float m_RootPosition = 0;
    float m_SidePositionX = 4.5f;
    List<float> m_XPosition;
    float m_ZPosition;

    CharacterInputController m_Character;
    CharacterCollider m_CharacterCollider;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        m_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();
        m_CharacterCollider = m_Character.GetComponentInChildren<CharacterCollider>();

        m_XPosition = new List<float>() { -m_SidePositionX, m_RootPosition, m_SidePositionX };

        StartCoroutine(SpawnObstacles());
    }

    // Update is called once per frame
    void Update()
    {

    }


    #endregion

    #region Class
    IEnumerator SpawnObstacles()
    {
        if (m_CharacterCollider.m_CurrentSpeed > 100)
        {
            yield return new WaitForSeconds(0.3f);
            // Debug.Log("Spawn 0.3s");
        }
        else if (m_CharacterCollider.m_CurrentSpeed > m_Character.m_BoostSpeed)
        {
            yield return new WaitForSeconds(0.5f);
            // Debug.Log("Spawn 0.5s");
        }
        else if (m_CharacterCollider.m_CurrentSpeed < 10)
        {
            yield return new WaitForSeconds(2.5f);
            // Debug.Log("Spawn 2.5s");
        }
        else
        {
            yield return new WaitForSeconds(1f);
            // Debug.Log("Spawn 1s");
        }
        m_ItemPosition = Random.Range(0, listObstacles.Length);
        m_NextPosition = Random.Range(0, m_XPosition.Count);


        // if X = 0 -> is root position
        // if X = 4.5|-4.5 -> is side position
        //m_XPosition = m_CharacterCollider.transform.position.x == m_RootPosition ? m_RootPosition : m_CharacterCollider.transform.position.x == -m_SidePositionX ? -m_SidePositionX : m_SidePositionX;

        m_ZPosition = m_CharacterCollider.transform.position.z + m_DistanceZSpawn;

        Instantiate(listObstacles[m_ItemPosition], new Vector3(m_XPosition[m_NextPosition], 0.5f, m_ZPosition), Quaternion.identity);
        StartCoroutine(SpawnObstacles());
    }
    #endregion
}
