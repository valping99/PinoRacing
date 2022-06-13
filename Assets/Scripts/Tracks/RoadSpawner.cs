using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    #region Variables
    // Start is called before the first frame update
    public GameObject MainRoad;
    public List<GameObject> roads;
    public CharacterCollider charColl;
    public GameObject playerMinimap;

    private Vector3 charPosition;
    private Vector3 charRotaion;
    public float offset = 10;

    public bool onGround;
    #endregion
    #region Unity Method
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
        Vector3 playerPosition = charColl.transform.position;
        //CheckOnGround();
        //charPosition = charColl.transform.position;
        MainRoad.transform.position = charPosition;
        playerMinimap.transform.position = playerPosition;
        playerMinimap.transform.eulerAngles = new Vector3(90, charColl.transform.eulerAngles.y, charColl.transform.eulerAngles.z);
        transform.eulerAngles = charColl.transform.eulerAngles;
    }
    #endregion
    #region Function
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
    #endregion
}
