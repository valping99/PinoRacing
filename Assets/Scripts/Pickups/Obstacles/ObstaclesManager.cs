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

    float _PointX;
    float _PointY;
    float _PointZ;
    float[] m_PositionSpawn;
    Quaternion _Rotation;

    public CharacterInputController m_Character;
    public CharacterCollider m_CharacterCollider;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        m_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();
        m_CharacterCollider = m_Character.gameObject.GetComponentInChildren<CharacterCollider>();

        m_PositionSpawn = new float[] { m_Character.slideLength, 0, -m_Character.slideLength };

        // StartCoroutine(SpawnObstacles());

    }

    public void CallSpawnObstacles()
    {
        StartCoroutine(SpawnObstacles());
    }

    void FixedUpdate()
    {
        _PointX = m_Character.spawnerObject.transform.position.x;
        _PointY = m_Character.spawnerObject.transform.localPosition.y;
        _PointZ = m_Character.spawnerObject.transform.localPosition.z;

        _Rotation = m_Character.spawnerObject.transform.rotation;
    }

    public void StartSpawnObjects()
    {
        StartCoroutine(SpawnObstacles());
    }

    #endregion

    #region Class
    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnObstacles());

        if (!m_Character.m_Stuns)
        {
            m_ItemPosition = Random.Range(0, listObstacles.Length);
            m_NextPosition = Random.Range(0, m_PositionSpawn.Length);

            if (m_ItemPosition == positionOfStickCreamInTheSky)
            {
                Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX, _PointY + 7f, _PointZ + m_PositionSpawn[m_NextPosition]), _Rotation);
            }
            else
            {
                Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX, _PointY + 0.5f, _PointZ + m_PositionSpawn[m_NextPosition]), _Rotation);
            }
        }
    }

    Vector3 SpawnObstaclesVec(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    #endregion
}
