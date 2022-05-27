using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacterSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterInputController charInput;
    public CharacterCollider charColl;

    void Start()
    {
        checkCharacterCollider();
        charInput = GetComponent<CharacterInputController>();
        charColl = FindObjectOfType<CharacterCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkCharacterCollider()
    {
        if (charInput.GetComponent<CharacterCollider>() == null)
        {

        }
    }
}
