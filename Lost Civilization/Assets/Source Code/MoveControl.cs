using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [SerializeField] Transform groundcheckCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpForce = 100;
    const float groundCheckRadius = 0.2f;
    [SerializeField]  bool isGrounded;

  
   

    bool jump;
   

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //jumpForce = 500f;
 
    }

    void Update()
    {
        
    }

   /* void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundcheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;
    }*/

    void FixedUpdate()
    {
       // GroundCheck();
        //Jumping (jump);
    }

    public void Jumping()
    {
        if (rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }


    }

    // Update is called once per frame


   
}
