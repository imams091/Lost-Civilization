using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float maxHealth;
    public float maxhitpoint = 100;
    public GameObject effect;
    public GameObject bloodSplash;
    public HealthBarEnemy healthbar;
    
    // Use this for initialization
    void Start()
    {
        maxHealth = maxhitpoint;
        healthbar.SetHealth(maxHealth, maxhitpoint);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void TakeDamage(int damage)
    {
        
        maxHealth -= damage;
        healthbar.SetHealth(maxHealth, maxhitpoint);

        if (maxHealth <= 0)
        {
            // Instantiate(bloodSplash, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Wafat();

            KillCount.instance.EnemyKilled();
        }

    }

    void Wafat()
    {
        Destroy(gameObject);
    }

   

}
   

