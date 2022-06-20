using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSticker : MonoBehaviour
{
    public GameObject stick;
    private CharacterCollider charColl;
    [SerializeField]
    private GameObject pinoModel;
    // Start is called before the first frame update
    void Start()
    {
        charColl = FindObjectOfType<CharacterCollider>();
        pinoModel = GameObject.FindGameObjectWithTag("RootObject");
    }

    // Update is called once per frame
    void Update()
    {
       //stick.transform.position = charColl.transform.position;
    }

}
