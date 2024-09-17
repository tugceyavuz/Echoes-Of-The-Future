using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player
    private Rigidbody2D rb; // Reference to the Rigidbody2D component
    private Vector2 moveInput; // Store the player's movement input
    private Animator animator; // Reference to the Animator component
    private bool isFacingRight = true; // To check which direction the player is facing

    private GameObject canvas;
    private bool isTalked;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        // Get input from the player
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Store the input in a Vector2
        moveInput = new Vector2(moveX, moveY).normalized;

        // Check if the player is moving and update the animator
        if (moveInput != Vector2.zero)
        {
            if (!isTalked)
            {
                if (!FindObjectOfType<AudioManager>().IsPlaying("walk"))
                    FindObjectOfType<AudioManager>().Play("walk");
                
                animator.SetBool("isMoving", true);

                // Reset all directional animation bools first
                animator.SetBool("isWalkingUp", false);
                animator.SetBool("isWalkingDown", false);
                animator.SetBool("isWalkingRight", false);

                // Set animations for direction
                if (moveY > 0)
                {
                    animator.SetBool("isWalkingUp", true);
                }
                else if (moveY < 0)
                {
                    animator.SetBool("isWalkingDown", true);
                }
                else if (moveX > 0)
                {
                    animator.SetBool("isWalkingRight", true);
                }
                else if (moveX < 0)
                {
                    animator.SetBool("isWalkingRight", true); // Trigger right animation but flip
                }
            }
            else canvas.SetActive(false);
        }
        else
        {
            if (isTalked) canvas.SetActive(false);
            // Stop all movement animations when player stops moving
            animator.SetBool("isMoving", false);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingRight", false);

            isTalked = GameObject.Find("NPCMarcus").GetComponent<DialogTrigger>().isFirstInteraction;
            if (FindObjectOfType<AudioManager>().IsPlaying("walk"))
                FindObjectOfType<AudioManager>().Stop("walk");
        }

        // Flip the player sprite based on horizontal movement
        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        // Move the player based on input by setting the velocity
        if (!isTalked)
            rb.velocity = moveInput * moveSpeed;
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1 to flip the sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
