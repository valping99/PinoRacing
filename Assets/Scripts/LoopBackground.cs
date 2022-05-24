using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public Transform Player;
    public float m_LPositionZ;
    private Vector3 m_limitedRange;
    private Vector3 m_startPos;
    private Vector3 PlayerPos; 
    public GameObject[] RoadPieces = new GameObject[2];
    const float RoadLength = 50f; //length of roads

    const float RoadSpeed = 5f; //speed to scroll roads at
    void Update()
    {
        foreach (GameObject road in RoadPieces)
        {
            Vector3 newRoadPos = road.transform.position;
            newRoadPos.z -= RoadSpeed * Time.deltaTime;
            if (newRoadPos.z < -RoadLength / 2)
            {
                newRoadPos.z += RoadLength;
            }
            road.transform.position = newRoadPos;
        }
    }
}
