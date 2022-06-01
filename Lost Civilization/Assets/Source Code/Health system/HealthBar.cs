using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;

    Vector2 play;
    public bool play_again;
    //100 health => 1 fill amount
    //45 health => 0.45 fill amount

    private void Awake()
    {
        play = transform.position;
    }

    public void LoseHealth(int value)
    {
        //Do nothing if you are out of health
        if (health <= 0)
            return;
        //Reduce the health 
        health -= value;
        //Refresh the UI fillBar
        fillBar.fillAmount = health / 100;
        //Check if your health is zero or less => Dead
        if (health <= 0)
        {
            //FindObjectOfType<Fox>().Die();
            Debug.Log("kamu mati");
        }
    }
    private void Update()
    {
       
    }

}