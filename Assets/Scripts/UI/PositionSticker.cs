using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSticker : MonoBehaviour
{
    public GameObject stick;
    private CharacterCollider charColl;
    // Start is called before the first frame update
    void Start()
    {
        charColl = FindObjectOfType<CharacterCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
