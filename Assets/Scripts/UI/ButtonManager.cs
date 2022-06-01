using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public CharacterInputController charInput;
    public CharacterCollider charColl;
    public UIManager managers;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClickResume()
    {
        managers.PauseGame();
        Debug.Log("PauseButton");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BoostSpeed()
    {
        if (managers.checkBoost)
        {
            //charInput.BoostSpeed();
        }
    }
}
