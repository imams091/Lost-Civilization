using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FSM_enemy : MonoBehaviour
{
   
   
    public float speed;
    public float lineOfSite;
    private Transform player;
    private Vector2 currentpos;
   
  //  Hero hr;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentpos = GetComponent<Transform>().position;
       // hr = GameObject.Find("MainChar").GetComponent<Hero>();
    }
    // Update is called once per frame
    void Update()
    {
        float jarakdariplayer = Vector2.Distance(player.position,
       transform.position);
        if (jarakdariplayer < lineOfSite)
        {
            transform.position =
           Vector2.MoveTowards(this.transform.position, player.position, speed *
           Time.deltaTime);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,
           currentpos, speed * Time.deltaTime);
        }

            }

  

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
