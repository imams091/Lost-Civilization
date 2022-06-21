using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("Area 1");
        //Time.timeScale = 1;
    }

    public void BtMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Time.timeScale = 1;
    }

}
