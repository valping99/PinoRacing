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
    public GameObject[] listObstacles;

    private const int positionOfStickCreamInTheSky = 1;
    int m_ItemPosition;
    int m_NextPosition;
    float m_RootPosition = 0;
    float m_SidePosition = 4.5f;

    float _PointX;
    float _PointY;
    float _PointZ;
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

        m_PositionSpawn = new List<float> { -m_SidePosition, m_RootPosition, m_SidePosition };
        StartCoroutine(SpawnObstacles());

    }

    void FixedUpdate()
    {
        m_ItemPosition = Random.Range(0, listObstacles.Length);
        m_NextPosition = Random.Range(0, m_PositionSpawn.Count);

        _PointX = m_Character.spawnerObject.transform.localPosition.x;
        _PointY = m_Character.spawnerObject.transform.localPosition.y;
        _PointZ = m_Character.spawnerObject.transform.localPosition.z + m_PositionSpawn[m_NextPosition];
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
            yield return new WaitForSeconds(1.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed >= 100)
        {
            yield return new WaitForSeconds(2.25f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed >= 50)
        {
            yield return new WaitForSeconds(2.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed >= 25)
        {
            yield return new WaitForSeconds(2.75f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed >= 10)
        {
            yield return new WaitForSeconds(2.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed > m_Character.m_BoostSpeed)
        {
            yield return new WaitForSeconds(1.5f);
        }
        else if (m_CharacterCollider.m_CurrentSpeed < 10)
        {
            yield return new WaitForSeconds(1.5f);
        }
        else
        {
            yield return new WaitForSeconds(2f);
        }


        if (m_ItemPosition == positionOfStickCreamInTheSky)
        {
            Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX, _PointY + 7f, _PointZ), Quaternion.identity);
        }
        else
        {
            Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX, _PointY + 0.5f, _PointZ), Quaternion.identity);
        }

        StartCoroutine(SpawnObstacles());
    }

    Vector3 SpawnObstaclesVec(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    #endregion
}
