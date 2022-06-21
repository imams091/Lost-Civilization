using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerashake : MonoBehaviour
{
    public GameObject ShakeFX;
    public float ShakeDur;

    private void Start()
    {
        ShakeFX.SetActive(false); 
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopAllCoroutines();
            StartCoroutine(Shake(ShakeDur));
        }
    }

    IEnumerator Shake(float t)
    {
        ShakeFX.SetActive(true);
        yield return new WaitForSeconds(t);
        ShakeFX.SetActive(false);
    }
}
