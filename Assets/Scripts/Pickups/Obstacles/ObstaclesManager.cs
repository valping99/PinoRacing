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
    List<float> m_PositionSpawn;
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

        m_PositionSpawn = new List<float> { m_Character.slideLength, -m_Character.slideLength, 0 };

        // StartCoroutine(SpawnObstacles());

    }

    public void CallSpawnObstacles()
    {
        StartCoroutine(SpawnObstacles());
    }

    void FixedUpdate()
    {
        m_ItemPosition = Random.Range(0, listObstacles.Length);
        m_NextPosition = Random.Range(0, m_PositionSpawn.Count);

        _PointX = m_Character.spawnerObject.transform.localPosition.x;
        _PointY = m_Character.spawnerObject.transform.localPosition.y;
        _PointZ = m_Character.spawnerObject.transform.localPosition.z + m_PositionSpawn[m_NextPosition];

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
        if (!m_Character.m_Stuns)
        {
            yield return new WaitForSeconds(1f);

            try
            {

                if (m_ItemPosition == positionOfStickCreamInTheSky)
                {
                    Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX, _PointY + 7f, _PointZ), _Rotation);
                }
                else
                {
                    Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX, _PointY + 0.5f, _PointZ), _Rotation);
                }

                StartCoroutine(SpawnObstacles());
            }
            catch (System.Exception ex)
            {
                Debug.Log(ex.Message);
            }
        }
        // if (m_Character.m_IsBoosting)
        // {
        //     yield return new WaitForSeconds(1.5f);
        // }
        // else if (m_CharacterCollider.m_CurrentSpeed >= 100)
        // {
        //     yield return new WaitForSeconds(2.25f);
        // }
        // else if (m_CharacterCollider.m_CurrentSpeed >= 50)
        // {
        //     yield return new WaitForSeconds(2.5f);
        // }
        // else if (m_CharacterCollider.m_CurrentSpeed >= 25)
        // {
        //     yield return new WaitForSeconds(2.75f);
        // }
        // else if (m_CharacterCollider.m_CurrentSpeed >= 10)
        // {
        //     yield return new WaitForSeconds(2.5f);
        // }
        // else if (m_CharacterCollider.m_CurrentSpeed > m_Character.m_BoostSpeed)
        // {
        //     yield return new WaitForSeconds(1.5f);
        // }
        // else if (m_CharacterCollider.m_CurrentSpeed < 10)
        // {
        //     yield return new WaitForSeconds(1.5f);
        // }
        // else
        // {
        //     yield return new WaitForSeconds(2f);
        // }

    }

    Vector3 SpawnObstaclesVec(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    #endregion
}
