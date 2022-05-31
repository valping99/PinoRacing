using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MainRoad;
    public List<GameObject> roads;
    public CharacterCollider charColl;

    private Vector3 charPosition;
    private Vector3 charRotaion;
    public float offset = 10;

    public bool onGround;
    void Start()
    {
        charColl = FindObjectOfType<CharacterCollider>();
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }

    }

    // Update is called once per frame
    void Update()
    {
        charPosition = new Vector3(charColl.transform.position.x, charColl.transform.position.y+1, charColl.transform.position.z + 3);
        CheckOnGround();
        //charPosition = charColl.transform.position;
        MainRoad.transform.position = charPosition;
    }
    public void MoveRoad()
    {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad);
        float newPosZ = roads[roads.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(0, 0, newPosZ);
        roads.Add(moveRoad);
    }
    /**
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrigger"))
        {
            MoveRoad();
        }
    }
    **/

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CheckGround"))
        {
            MoveRoad();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CheckGround"))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    public void CheckOnGround()
    {
        if (!onGround)
        {
            MainRoad.transform.position = charPosition;
            //MoveRoad();
        }
    }

}
