
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float checkRadius = 0.2f;

    private bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Read left and right keyboard input
        float move = Input.GetAxisRaw("Horizontal");

        // Move the player horizontally
        rb.linearVelocity = new Vector2(
            move * speed,
            rb.linearVelocity.y
        );

        // Face the direction of movement
        if (move > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Jump only when the player is on the ground
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                jumpForce
            );
        }
    }

    void FixedUpdate()
    {
        // Check whether the player's feet touch the ground
        grounded = Physics2D.OverlapCircle(
            groundCheck.position,
            checkRadius,
            whatIsGround
        );
    }
}