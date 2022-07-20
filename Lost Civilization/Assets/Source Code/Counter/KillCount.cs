using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public static KillCount instance;

    [SerializeField]
    private Text enemyKillCountTxt;

    private int enemyKillCount;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        enemyKillCountTxt.text = ": " + enemyKillCount;
    }

    public void RestartGame()
    {
        Invoke("Restart", 3f);
    }

    void Restrat()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Area 1");
    }

}
