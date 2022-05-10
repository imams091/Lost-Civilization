using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Playerpush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    public bool button_drag;
    public bool button_interact;
    
    GameObject boxx;
    private bool holdbutton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag("buttondrag").GetComponent<Button>().interactable = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
       

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(KeyCode.E) || (button_drag == true))
        {
            boxx = hit.collider.gameObject;
            boxx.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            
            boxx.GetComponent<FixedJoint2D>().enabled = true;
            boxx.GetComponent<boxpull>().beingPushed = true;

        }
        else if (Input.GetKeyUp(KeyCode.E) || (button_drag == false))
        {
            
            GameObject.FindGameObjectWithTag("Pushable").GetComponent<FixedJoint2D>().enabled = false;
            GameObject.FindGameObjectWithTag("Pushable").GetComponent<boxpull>().beingPushed = false;

        }

      
    }

    public void Tekan()
    {
        button_drag = true;
        
    }
    public void Lepas()
    {
        button_drag = false;

    }

    public void enablebut()
    {
        GameObject.FindGameObjectWithTag("buttondrag").GetComponent<Button>().interactable = true;
    }

    public void disablebut()
    {
        GameObject.FindGameObjectWithTag("buttondrag").GetComponent<Button>().interactable = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
