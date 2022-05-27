using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacterSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterCollider charColl;
    public CharacterInputController charInput;

    void Start()
    {
        charColl = FindObjectOfType<CharacterCollider>();
        charInput = FindObjectOfType<CharacterInputController>();
        checkCharacterCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void checkCharacterCollider()
    {
        if (charInput.m_Character == null)
        {
            charInput.m_Character = charColl;
            
        }
    }
}
