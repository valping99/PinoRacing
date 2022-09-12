using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CharacterSelected : MonoBehaviour
{
    public UIManager uiManagers;
    public Transform transformParent;
    public Character nameCollider;
    public Character nameGameObject;
    public CharacterController charInput;
    public List<GameObject> playerList;
    public int isSelected;
    void Start()
    {
        GameStart();
    }


    //Select Pino & add to UIManager
    public void GameStart()
    {
        //Get Variables in UIManager
        isSelected = UIManager.pinoSelected;

        //If List Pino > 0,check & get Pino by variables in StartScene
        for (int i = 0; i <= isSelected; i++)
        {
            if (i == isSelected)
            {
                //Get Pino to stage
                Instantiate(playerList[i - 1], new Vector3(0, 0, 0), Quaternion.identity, transformParent);


                //Get new Variables of the pino
                nameGameObject = FindObjectOfType<Character>();
                GameObject PinoGameObject = nameGameObject.gameObject;
                nameCollider = FindObjectOfType<Character>();
                charInput = (CharacterController)FindObjectOfType(typeof(CharacterController));

                //Get Variables to UIManager
                uiManagers.m_Player = PinoGameObject;
                uiManagers.charColl = nameCollider;
                uiManagers.charInput = charInput;


            }
        }
        Debug.Log(SelectManager.levelMode);
    }


}
