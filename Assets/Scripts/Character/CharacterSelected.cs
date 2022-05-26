using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    //SelectManager selectManager;
    public GameObject nameGameObject;
    public CharacterCollider nameCollider;
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
        //transform.position = playerPosition;

    }

    /**

    public void RoadFollowPlayer()
    {
        for(int i = 0;i < roadToSpawn.Count; i++)
        {
            Debug.Log("SpawnRoad" + positionZToRespawn);
            Debug.Log(i);
            Instantiate(playerList[i], new Vector3(0, 0, 0), Quaternion.identity);
            positionZToRespawn += roadLength;
            newRoad = new Vector3(0, 0, positionZToRespawn);
            Debug.Log("SpawnRoad" + positionZToRespawn);
        }
    }
    **/

    public void GameStart()
    {
        isSelected = UIManager.pinoSelected;
        for (int i = 0; i <= isSelected; i++)
        {
            if (i == isSelected)
            {
                Debug.Log("Instantiate");
                Instantiate(playerList[i - 1], new Vector3(0, 0, 0), Quaternion.identity);
                
                //playerPosition = playerList[i - 1].transform.position;
                GameObject pino = playerList[i - 1];
                nameGameObject = GameObject.Find("Pino");
                nameCollider = FindObjectOfType<CharacterCollider>();
                charInput = (CharacterInputController) FindObjectOfType(typeof(CharacterInputController));
                //nameCharacterCollider = CharacterCollider.FindObjectOfType()
                Debug.Log(pino);
                uiManagers.m_Player = nameGameObject;
                uiManagers.charColl = nameCollider;
                uiManagers.charInput = charInput;
                Debug.Log("Instantiate");

                //RoadFollowPlayer();

            }
        }
    }


}
