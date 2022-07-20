using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public Image fillBar;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("MainChar") && HealthBar.health < 100)
            StartCoroutine("Heal");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("MainChar"))
            StopCoroutine("Heal");
    }

    IEnumerator Heal()
    {
        for (float currentHealth = HealthBar.health; currentHealth <= 100; currentHealth += 0.3f)
        {
            HealthBar.health = currentHealth;
            fillBar.fillAmount = currentHealth /100;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        HealthBar.health = 100f;
    }
}
