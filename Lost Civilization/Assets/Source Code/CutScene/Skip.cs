using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public void SkipToArea1()
    {
        SceneManager.LoadScene("Area 1");
        //Time.timeScale = 1;
    }

   
}
