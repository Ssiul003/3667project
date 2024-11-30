using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    private const int SPEED = 15;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 5.0f; // Adjusted jump force
    [SerializeField] bool isGrounded = true;
    public Animator animator;
    private Camera mainCamera;

    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();

        // Reference the main camera
        mainCamera = Camera.main;
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(movement));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpPressed = true;
            animator.SetBool("IsJumping", true);
        }
    }

    private void FixedUpdate()
    {
        // Horizontal movement
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);

        // Flip the character based on movement direction
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();

        // Handle jumping
        if (jumpPressed && isGrounded)
        {
            Jump();
        }

        // Lock the position within the screen
        LockPositionWithinScreen();
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, jumpForce); // Set Y velocity directly
        jumpPressed = false;
        isGrounded = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            OnLanding(); // Call OnLanding when grounded
        }
    }

    private void LockPositionWithinScreen()
    {
        // Get the screen bounds
        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Clamp the character's position within 0 and 1 for X-axis
        screenPosition.x = Mathf.Clamp(screenPosition.x, 0.05f, 0.95f);

        // Convert back to world position
        Vector3 clampedPosition = mainCamera.ViewportToWorldPoint(screenPosition);
        transform.position = new Vector3(clampedPosition.x, transform.position.y, transform.position.z);
    }
}
