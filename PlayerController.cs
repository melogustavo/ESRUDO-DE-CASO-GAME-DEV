using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 7f;
    public float runMultiplier = 1.4f;
    public float jumpForce = 12f;
    public float coyoteTime = 0.1f;
    public float jumpBuffer = 0.1f;

    [Header("Climb")]
    public float climbSpeed = 5f;
    public LayerMask ladderLayer;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.15f;
    public LayerMask groundLayer;

    [Header("Refs")]
    public Animator animator;
    public SpriteRenderer sr;

    private Rigidbody2D rb;
    private float lastGroundedTime;
    private float lastJumpPressedTime;
    private bool isClimbing;

    void Awake(){ rb = GetComponent<Rigidbody2D>(); }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        bool running = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float speed = moveSpeed * (running ? runMultiplier : 1f);

        rb.velocity = new Vector2(h * speed, rb.velocity.y);
        if (h != 0) sr.flipX = h < 0;

        bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        if (grounded) lastGroundedTime = Time.time;

        if (Input.GetButtonDown("Jump")) lastJumpPressedTime = Time.time;

        if (Time.time - lastJumpPressedTime <= jumpBuffer && Time.time - lastGroundedTime <= coyoteTime)
        {
            Jump();
            lastJumpPressedTime = -999f;
        }

        float v = Input.GetAxisRaw("Vertical");
        bool onLadder = Physics2D.OverlapCircle(transform.position, 0.2f, ladderLayer);
        if (onLadder && Mathf.Abs(v) > 0f) { isClimbing = true; }
        if (!onLadder) { isClimbing = false; }
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, v * climbSpeed);
        }
        else
        {
            rb.gravityScale = 3f;
        }

        if (animator)
        {
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            animator.SetBool("IsGrounded", grounded);
            animator.SetBool("IsClimbing", isClimbing);
            animator.SetFloat("YVelocity", rb.velocity.y);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        AudioManager.I?.PlayJump();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Hazard") || col.collider.CompareTag("Enemy"))
        {
            GetComponent<PlayerHealth>()?.TakeDamage(1);
        }
    }
}
