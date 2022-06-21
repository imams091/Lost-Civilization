using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class toMainMenu : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Area 1", LoadSceneMode.Single);
    }
}
