using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    #region Variables
    // Start is called before the first frame update
    public GameObject MainRoad;
    public Character charColl;
    public GameObject playerMinimap;

    private Vector3 charPosition;
    private Vector3 charRotaion;
    public float offset = 10;

    public bool onGround;
    #endregion
    #region Unity Method
    void Start()
    {
        charColl = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        charPosition = new Vector3(charColl.transform.position.x, charColl.transform.position.y + 1, charColl.transform.position.z);
        Vector3 playerPosition = charColl.transform.position;
        MainRoad.transform.position = charPosition;
        playerMinimap.transform.position = playerPosition;
        //playerMinimap.transform.eulerAngles = new Vector3(90, charColl.transform.eulerAngles.y, charColl.transform.eulerAngles.z);
        transform.eulerAngles = charColl.transform.eulerAngles;
    }
    #endregion
}
