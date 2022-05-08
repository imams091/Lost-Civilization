using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
   

    bool jump;
   

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pauseMenuScreen.SetActive(false);
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
