using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    #region GetScripts
    public CharacterController charInput;
    public Character charColl;
    public UIManager managers;
    #endregion
    public void ClickResume()
    {
        managers.PauseGame();
        Debug.Log("PauseButton");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
