
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
    [SerializeField]
    private Transform transform_parent;

    float _PointX;
    float _PointXChild;
    float _PointY;
    float _PointZ;
    float[] m_PositionSpawn;
    Quaternion _Rotation;

    public CharacterController m_Character;
    public Character m_CharacterCollider;

    GameObject m_RootItem;
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        m_Character = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        m_CharacterCollider = m_Character.gameObject.GetComponentInChildren<Character>();

        m_PositionSpawn = new float[] { m_Character.slideLength + 2, 0, -m_Character.slideLength - 2 };
        m_RootItem = GameObject.FindGameObjectWithTag("SpawnChild");

        transform_parent = GameObject.FindGameObjectWithTag("SpawnChild").transform;
        // StartCoroutine(SpawnObstacles());

    }

    public void CallSpawnObstacles()
    {
        StartCoroutine(SpawnObstacles());
    }

    void FixedUpdate()
    {
        _PointX = m_RootItem.transform.position.x;
        _PointY = m_RootItem.transform.position.y;
        _PointZ = m_RootItem.transform.position.z;

        _Rotation = m_Character.spawnerObject.transform.rotation;

        // Debug.Log(" _RotationY: " + _Rotation.y + " _RotationW: " + _Rotation.w);
    }

    public void StartSpawnObjects()
    {
        StartCoroutine(SpawnObstacles());
    }

    #endregion

    #region Class
    IEnumerator SpawnObstacles()
    {
        if (m_Character.m_Stuns)
        {
            yield return new WaitForSeconds(4f);
        }
        else if (m_Character.m_CurrentSpeed < 20f)
        {
            yield return new WaitForSeconds(2f);
        }
        else
        {
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(SpawnObstacles());

        m_ItemPosition = Random.Range(0, listObstacles.Length);
        m_NextPosition = Random.Range(0, m_PositionSpawn.Length);

        if (!m_Character.m_Stuns)
        {
            if (m_ItemPosition == positionOfStickCreamInTheSky)
            {
                GameObject cloneObstacles = Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX + m_PositionSpawn[m_NextPosition], _PointY + 7f, _PointZ), _Rotation, transform_parent);
                cloneObstacles.transform.SetParent(null);
            }
            else
            {
                GameObject cloneObstacles = Instantiate(listObstacles[m_ItemPosition], SpawnObstaclesVec(_PointX + m_PositionSpawn[m_NextPosition], _PointY, _PointZ), _Rotation, transform_parent);
                cloneObstacles.transform.SetParent(null);

            }

        }
    }

    Vector3 SpawnObstaclesVec(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }
    #endregion
}
