using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public GameObject[] RoadPieces;
    const float RoadLength = 50f; //length of roads
    const float RoadSpeed = 5f; //speed to scroll roads at
    void Update()
    {
        foreach (GameObject road in RoadPieces)
        {
            Vector3 newRoadPos = road.transform.position;
            if (newRoadPos.z < transform.position.z)
            {
                newRoadPos.z += RoadLength;
            }
            road.transform.position = newRoadPos;
        }
    }
}
