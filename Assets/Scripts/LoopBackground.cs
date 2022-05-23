using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public Transform m_Player;
    public float m_limitedRange;
    private Vector3 m_startPos;
    public float m_repeatPositionZ;
    void Start()
    {
        m_startPos = transform.position;
        m_repeatPositionZ = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < m_startPos.z - m_limitedRange)
        {
            transform.position = m_startPos;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
    }
}
