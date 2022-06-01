using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    HealthBar hb;

    public int damage = 10;

    private void Start()
    {
        hb = GameObject.Find("MainChar").GetComponent<HealthBar>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
           
            hb.LoseHealth(damage);

        }

    }
}
