using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScreen : MonoBehaviour
{
    [Tooltip("Variables")]
    public SelectManager manager;
    void Start()
    {
        manager = GetComponent<SelectManager>();
    }

    public void AcceptStage(int level)
    {
        level = manager.selectedStage;
        Debug.Log("Selected " + level);
        SceneManager.LoadScene(level);
    }
}
