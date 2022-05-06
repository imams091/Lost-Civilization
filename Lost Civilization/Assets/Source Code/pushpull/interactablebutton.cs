using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class interactablebutton : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject box;
    void Start()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x);

        if (hit.collider)
        {
            box = hit.collider.gameObject;
            box.gameObject.GetComponent<Button>().interactable = true;
        }
    }

}
