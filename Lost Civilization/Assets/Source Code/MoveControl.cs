using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    //[SerializeField] Transform groundcheckCollider;
    public Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    const float groundCheckRadius = 0.2f;
    [SerializeField] bool isGrounded = true;

    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public int totalJumps;
    int availableJumps;
    bool multipleJump;
    bool coyoteJump;
    bool jump;
    [SerializeField] float jumpPower = 500;

    // Start is called before the first frame update
    void Awake()
    {
        availableJumps = totalJumps;
        rb = GetComponent<Rigidbody2D>();
        pauseMenuScreen.SetActive(false);
        animator = GetComponent<Animator>();
        //jumpForce = 500f;

    }

    void Update()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

   void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            if (!wasGrounded)
            {
                availableJumps = totalJumps;
                multipleJump = false;

                //AudioManager.instance.PlaySFX("landing");
            }

            //Check if any of the colliders is moving platform
            //Parent it to this transform
            foreach (var c in colliders)
            {
                if (c.tag == "MovingPlatform")
                    transform.parent = c.transform;
            }
        }
        else
        {
            //Un-parent the transform
            transform.parent = null;

            if (wasGrounded)
                StartCoroutine(CoyoteJumpDelay());
        }

        animator.SetBool("Jump", !isGrounded);
    }



    void FixedUpdate()
    {
       GroundCheck();
        //Jumping (jump);
    }

    public void Jumping()
    {
        if (isGrounded)
        {
            multipleJump = true;
            availableJumps--;

            rb.velocity = Vector2.up * jumpPower;
            animator.SetBool("Jump", true);
        }
        else
        {
            if (coyoteJump)
            {
                multipleJump = true;
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
            }

            if (multipleJump && availableJumps > 0)
            {
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
            }
        }
    }

    IEnumerator CoyoteJumpDelay()
    {
        coyoteJump = true;
        yield return new WaitForSeconds(0.2f);
        coyoteJump = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   
}
