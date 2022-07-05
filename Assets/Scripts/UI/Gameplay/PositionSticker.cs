using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSticker : MonoBehaviour
{
    #region Variables
    public GameObject stick;
    private Character charColl;
    [SerializeField]
    private GameObject pinoModel;
    #endregion
    #region Unity Method
    void Start()
    {
        charColl = FindObjectOfType<Character>();
        pinoModel = GameObject.FindGameObjectWithTag("RootObject");
    }

    // Update is called once per frame
    void Update()
    {
        //stick.transform.position = charColl.transform.position;
    }
    #endregion
}
