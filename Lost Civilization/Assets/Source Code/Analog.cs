using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Analog : MonoBehaviour
{
    
    Rigidbody2D rb;
    Animator animator;
    IEnumerator dashCoroutine;
    bool button_dash;
    bool isDashing;
    bool canDash = true;
    float direction = 1;
    float movX;
    [SerializeField] float speed = 1;
    
    public Joystick joystick;
       
    //float horizontoalValue; 
    bool facingRight;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
        
        
    }

    void Update()
    {
        if(movX != 0)
        {
            direction = movX;
        }

        movX = joystick.Horizontal * speed;
        if( joystick.Horizontal >= .2f)
        {
            movX = speed;
        }
        else if(joystick.Horizontal <= -.2f)
        {
            movX = -speed;
        }
        else
        {
            movX = 0f;
        }

        
    }


    void FixedUpdate()
    {
        
        Move(movX);
        if (isDashing)
        {
            rb.AddForce(new Vector2(direction * 10, 0), ForceMode2D.Impulse);
        }
    }

    public void Dash()
    {
        if (canDash == true)
        {
            if (dashCoroutine != null)
            {
                StopCoroutine(dashCoroutine);
            }
            dashCoroutine = Dash(.1f, 1);
            StartCoroutine(dashCoroutine);
        }

    }

  

    public void Move(float dir) //gerak kanan kiri 
    {     
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
                
        animator.SetFloat("Run", Mathf.Abs(rb.velocity.x));
        
    }

    IEnumerator Dash(float dashDuration, float dashCooldown)
    {
        Vector2 originalVelocity = rb.velocity;
        //Debug.Log(Time.time);
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(dashDuration);
        //Debug.Log(Time.time);
        isDashing = false;
        rb.velocity = originalVelocity;
        yield return new WaitForSeconds(dashCooldown);
        //Debug.Log(Time.time);
        canDash = true;
    }
}
