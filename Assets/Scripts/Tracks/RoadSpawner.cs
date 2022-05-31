using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> roads;
    public float offset = 10;
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MoveRoad()
    {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad);
        float newPosZ = roads[roads.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(0, 0, newPosZ);
        roads.Add(moveRoad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            MoveRoad();
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        if (roads == null)
            return;

        Color c = Gizmos.color;
        Gizmos.color = Color.yellow;
        for (int i = 1; i < roads.Count; ++i)
        {
            Transform orig = roads.ElementAt(i - 1).transform;
            Transform end = roads.ElementAt(i).transform;

            Gizmos.DrawLine(new Vector3(orig.position.x, 2f, orig.position.z), new Vector3(end.position.x, 2f, end.position.z));
            Gizmos.DrawLine(new Vector3(orig.position.x - 5f, 2f, orig.position.z), new Vector3(end.position.x - 5f, 2f, end.position.z));
            Gizmos.DrawLine(new Vector3(orig.position.x + 5f, 2f, orig.position.z), new Vector3(end.position.x + 5f, 2f, end.position.z));
        }

        // Gizmos.color = Color.blue;
        // for (int i = 0; i < roads.Count; ++i)
        // {
        //     Vector3 pos;
        //     Quaternion rot;
        //     GetPointAt(oPositions[i], out pos, out rot);
        //     Gizmos.DrawSphere(pos, 0.5f);
        // }

        Gizmos.color = c;
    }
#endif
}
