using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void StartGame()
    {
        SceneManager.LoadScene("Area 1");
        Time.timeScale = 1;
    }
    
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Exit");
    }
}
