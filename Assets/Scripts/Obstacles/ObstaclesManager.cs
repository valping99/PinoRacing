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

    public float m_DistanceSpawn = 10;
    public GameObject[] listObstacles;

    private const int positionOfStickCreamInTheSky = 1;
    int m_ItemPosition;
    int m_NextPosition;
    float m_RootPosition = 0;
    float m_SidePositionX = 4.5f;
    List<float> m_PositionSpawn;

    public CharacterInputController m_Character;
    public CharacterCollider m_CharacterCollider;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        m_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();
        m_CharacterCollider = m_Character.gameObject.GetComponentInChildren<CharacterCollider>();

        m_PositionSpawn = new List<float> { -m_SidePositionX, m_RootPosition, m_SidePositionX };
        StartCoroutine(SpawnObstacles());

    }

    public void StartSpawnObjects()
    {
        StartCoroutine(SpawnObstacles());
    }

    #endregion

    #region Class
    IEnumerator SpawnObstacles()
    {
        if (m_Character.m_IsBoosting)
        {
            yield return new WaitForSeconds(0.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed > 100)
        {
            yield return new WaitForSeconds(1.25f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed >= 50)
        {
            yield return new WaitForSeconds(1.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed >= 25)
        {
            yield return new WaitForSeconds(1.75f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed >= 10)
        {
            yield return new WaitForSeconds(1.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed > m_Character.m_BoostSpeed)
        {
            yield return new WaitForSeconds(0.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed < 10)
        {
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }

        m_ItemPosition = Random.Range(0, listObstacles.Length);
        m_NextPosition = Random.Range(0, m_PositionSpawn.Count);

        // m_PositionSpawn = m_Character.obstaclePosition.x + m_DistanceSpawn;

        if (m_ItemPosition == positionOfStickCreamInTheSky)
        {
            // Instantiate(listObstacles[m_ItemPosition], new Vector3(m_XPosition[m_NextPosition], 7f, m_ZPosition), Quaternion.identity);
            Instantiate(listObstacles[m_ItemPosition], SpawnObstacles(m_Character.spawnerObject.transform.position.x,
            m_Character.spawnerObject.transform.position.y + 7f,
            m_Character.spawnerObject.transform.localPosition.z + m_PositionSpawn[m_NextPosition]), Quaternion.identity);
        }
        else
        {
            // Instantiate(listObstacles[m_ItemPosition], new Vector3(m_XPosition[m_NextPosition], 0.5f, m_ZPosition), Quaternion.identity);
            Instantiate(listObstacles[m_ItemPosition], SpawnObstacles(m_Character.spawnerObject.transform.position.x,
            m_Character.spawnerObject.transform.position.y + .5f,
            m_Character.spawnerObject.transform.localPosition.z + m_PositionSpawn[m_NextPosition]), Quaternion.identity);
        }


        StartCoroutine(SpawnObstacles());
    }

    Vector3 SpawnObstacles(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    #endregion
}
