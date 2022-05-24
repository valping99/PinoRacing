using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public GameObject Player;
    public float m_LPositionZ;
    private Vector3 m_limitedRange;
    private Vector3 m_startPos;
    private Vector3 PlayerPos;
    void Start()
    {
        PlayerPos = Player.transform.position;
        m_startPos = this.transform.position;
        m_limitedRange = new Vector3(0, 0, m_LPositionZ);
        //m_repeatPositionZ = GetComponent<BoxCollider>().size.z / 2;

    }

    // Update is called once per frame
    void Update()
    {
        /**
        if (m_startPos.z < PlayerPos.z + m_LPositionZ)
        {
            m_startPos = PlayerPos;
        }
        **/
        while(m_startPos.z < PlayerPos.z)
        {
            m_startPos = PlayerPos;
        }
    }
}
