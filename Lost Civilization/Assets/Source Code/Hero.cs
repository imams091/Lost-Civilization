using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Transform groundcheckCollider;
    [SerializeField] LayerMask groundLayer;

    public int nyawa;
    public Joystick joystick;
    Vector2 play;
    public bool play_again;

    const float groundCheckRadius = 0.2f;
    [SerializeField] float speed = 1;
    
    float horizontoalValue;

    [SerializeField] bool isGrounded;
    bool facingRight;
   

    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        horizontoalValue = joystick.Horizontal;
        
        
       //animator.SetFloat("Blend_Jump", rb.velocity.y);

    }

 

    void FixedUpdate()
    {
        GroundCheck();
        Move(horizontoalValue);
    }

    //Groundcheck
    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundcheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;
    }

    //gerak kanan kiri 
    public void Move(float dir)
    {
     
        #region gerak kanan kiri
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        #endregion

        
        animator.SetFloat("Run", Mathf.Abs(rb.velocity.x));


    }
}
