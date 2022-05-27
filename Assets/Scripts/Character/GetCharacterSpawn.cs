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
        charInput = FindObjectOfType<CharacterInputController>();
        charColl = FindObjectOfType<CharacterCollider>();
        checkCharacterCollider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkCharacterCollider()
    {
        /**
        if (charInput.m_Character == null)
        {
            if(charInput.gameObject.activeSelf == false)
            {
                charInput.gameObject.SetActive(true);
                charInput.m_Character = charColl;
                Debug.Log("Add controller");
            }
        }
        else
        {
            Debug.Log("Dont add");
        }
        **/
    }
}
