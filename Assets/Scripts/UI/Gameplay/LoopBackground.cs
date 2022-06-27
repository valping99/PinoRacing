using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour
{
    public GameObject[] RoadPieces;
    public float RoadLength = 30f; //length of roads
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
