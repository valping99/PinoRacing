using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCourse : MonoBehaviour
{
    #region Variables
    public CharacterCollider m_charCollider;
    //public GameObject playerPino;
    public int lapCourse;
    private UIManager uiManagers;
    #endregion
    // Start is called before the first frame update
    #region UnityMethod
    void Start()
    {
        m_charCollider = FindObjectOfType<CharacterCollider>();
        //playerPino = GameObject.FindGameObjectWithTag("RootObject");
        uiManagers = FindObjectOfType<UIManager>();
        lapCourse = 1;
        uiManagers.finishLap.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        uiManagers.lapsToGameOver = lapCourse;
        if(lapCourse == 3)
        {
            Invoke("ShowFinishLap", 2);
        }
    }

    private void ShowFinishLap()
    {
        uiManagers.finishLap.gameObject.SetActive(true);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RootObject"))
        {
            if(lapCourse >= 3)
            {
                uiManagers.checkGameOver = true;
            }
            else
            {
                Debug.Log("True");
                lapCourse += 1;
            }
        }
    }
    #endregion
}
