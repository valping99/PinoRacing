
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{

    #region Variables
    public GameObject[] listObstacles;

    private const int positionOfStickCreamInTheSky = 1;
    int m_ItemPosition;
    int m_NextSpawner;
    int m_NextSpawner_1;
    Quaternion _Rotation;
    CharacterController m_Character;
    Character m_CharacterCollider;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        m_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        m_CharacterCollider = m_Character.gameObject.GetComponentInChildren<Character>();
    }

    public void CallSpawnObstacles()
    {
        StartCoroutine(SpawnObstacles());
    }

    void FixedUpdate()
    {
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
        // -2 CD spawn 
        if (m_Character.m_Stuns)
        {
            yield return new WaitForSeconds(1.25f);
        }
        else if (m_Character.m_CurrentSpeed < 20f)
        {
            yield return new WaitForSeconds(1f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(SpawnObstacles());

        m_ItemPosition = Random.Range(0, listObstacles.Length);
        m_NextSpawner = Random.Range(0, m_Character.listSpawner.Length);
        m_NextSpawner_1 = Random.Range(0, m_Character.listSpawner.Length);

        //if (!m_Character.m_Stuns)
        //{
        if (m_ItemPosition == positionOfStickCreamInTheSky || m_ItemPosition == positionOfStickCreamInTheSky + 6)
        {
            Instantiate(listObstacles[m_ItemPosition],
            SpawnObstaclesInSky(m_Character.listSpawner[m_NextSpawner]), _Rotation);
            if (m_Character.listSpawner[m_NextSpawner] == m_Character.listSpawner[m_NextSpawner_1])
            {
                Debug.Log("Same Location");
            }
            else
            {
                m_ItemPosition = Random.Range(0, listObstacles.Length);
                if(m_ItemPosition == positionOfStickCreamInTheSky || m_ItemPosition == positionOfStickCreamInTheSky + 6)
                {
                    Instantiate(listObstacles[m_ItemPosition],
                    SpawnObstaclesInSky(m_Character.listSpawner[m_NextSpawner_1]), _Rotation);
                }
            }
        }
        else
        {
            Instantiate(listObstacles[m_ItemPosition],
            SpawnObstaclesNormal(m_Character.listSpawner[m_NextSpawner]), _Rotation);
            if (m_Character.listSpawner[m_NextSpawner] == m_Character.listSpawner[m_NextSpawner_1])
            {
                Debug.Log("Same Location");
            }
            else
            {
                m_ItemPosition = Random.Range(0, listObstacles.Length);
                if(m_ItemPosition == positionOfStickCreamInTheSky || m_ItemPosition == positionOfStickCreamInTheSky + 6)
                {
                    Debug.Log("Spawn Stick");
                }
                else
                {
                    Instantiate(listObstacles[m_ItemPosition],
                    SpawnObstaclesNormal(m_Character.listSpawner[m_NextSpawner_1]), _Rotation);
                }
            }
        }
        //}
    }

    Vector3 SpawnObstaclesNormal(GameObject spawner)
    {
        return new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);
    }
    Vector3 SpawnObstaclesInSky(GameObject spawner)
    {
        return new Vector3(spawner.transform.position.x, spawner.transform.position.y + 7f, spawner.transform.position.z);
    }
    #endregion
}
