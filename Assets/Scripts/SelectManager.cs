using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectManager : MonoBehaviour
{
    public GameObject scene_01;
    public GameObject scene_02;
    public GameObject scene_03;
    public GameObject scene_04;

    public GameObject selectStage_01;
    public GameObject selectStage_02;
    public GameObject selectStage_03;

    public int selectStage;

    public GameObject typeOfPino_01;
    public TextMeshProUGUI nameOfPino_01;
    public GameObject typeOfPino_02;
    public TextMeshProUGUI nameOfPino_02;
    public GameObject typeOfPino_03;
    public TextMeshProUGUI nameOfPino_03;

    public GameObject statusOfPino_01;
    public GameObject statusOfPino_02;
    public GameObject statusOfPino_03;


    public TextMeshProUGUI Text_TapToStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
