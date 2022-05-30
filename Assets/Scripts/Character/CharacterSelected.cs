using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    //SelectManager selectManager;
    //public GameObject nameGameObject;
    public Transform transformParent;
    public CharacterCollider nameCollider;
    public CharacterCollider nameGameObject;
    public CharacterInputController charInput;
    public List<GameObject> playerList;
    public UIManager uiManagers;
    //public List<GameObject> roadToSpawn;
    public int isSelected;
    //public float positionZToRespawn = 0;
    //public float roadLength = 50;
    //public Vector3 playerPosition;
    //private Vector3 newRoad = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {

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
                Debug.Log("Instantiate");
                Instantiate(playerList[i - 1], new Vector3(0, 0, 0), Quaternion.identity, transformParent);


                //Get new Variables of the pino
                nameGameObject = FindObjectOfType<CharacterCollider>();
                GameObject PinoGameObject = nameGameObject.gameObject;
                nameCollider = FindObjectOfType<CharacterCollider>();
                charInput = (CharacterInputController)FindObjectOfType(typeof(CharacterInputController));

                //Get Variables to UIManager
                uiManagers.m_Player = PinoGameObject;
                uiManagers.charColl = nameCollider;
                uiManagers.charInput = charInput;


            }
        }
    }


}
