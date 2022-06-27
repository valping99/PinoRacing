using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScreen : MonoBehaviour
{
    public SelectManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<SelectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AcceptStage(int level)
    {
        level = manager.selectedStage;
        Debug.Log("Selected " + level);
        SceneManager.LoadScene(level);
    }
}
