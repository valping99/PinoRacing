using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandle : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeScreenShot.TakeScreenshot_Static(500, 500);
            Debug.Log("Save Screenshot.png");
        }
    }
}
