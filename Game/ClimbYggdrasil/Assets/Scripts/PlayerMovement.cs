using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private float dirY = 0f;
    private float dirXstored = 1f;
    public bool canDoubleJump = false;
    public bool dashUnlocked = false;
    private bool canDash = false;
    public bool dashing = false;
    private float dashTime = 0f;
    private float timeSinceDash = 0f;

    [SerializeField]private float dashCooldown = 0.5f;
    [SerializeField] private float dashLength = 0.3f;
    [SerializeField] private float dashVelocity = 20f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private LayerMask jumpGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();    
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
        if (dirX != 0)
        {
            dirXstored = dirX;
        }
        if (dirXstored < 0)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.transform.localScale = Vector3.one;
        }
        if ((Input.GetKey(KeyCode.U) == false || !IsGrounded()) && !dashing)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.U) == true && !dashing)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            canDoubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            canDoubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.P) && canDash && dashUnlocked)
        {
            Dash();
        }
        if (dashing)
        { 
            dashTime += Time.deltaTime;
            PlayerHealth pHealth = GetComponent<PlayerHealth>();
            pHealth.canBeDamaged = false;
        }
        if (!canDash)
        {
            timeSinceDash += Time.deltaTime;
        }
        if (dashTime > dashLength)
        {
            rb.gravityScale = 5;
            dashing = false;
            PlayerHealth pHealth = GetComponent<PlayerHealth>();
            pHealth.canBeDamaged = true;
            rb.velocity = new Vector2(0, 0);
            dashTime = 0;
        }
        if (timeSinceDash > dashCooldown)
        {
            canDash = true;
        }
        if (!dashing && rb.velocity.y < -30)
        {
            rb.velocity = new Vector2(rb.velocity.x, -30);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            PlayerHealth pHealth = GetComponent<PlayerHealth>();
            pHealth.PlayerTakeDamage(1);
        }
    }
    private void Dash()
    {
        dashing = true;
        canDash = false;
        dashTime = 0;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(dirX * dashVelocity, dirY * dashVelocity);
        timeSinceDash = 0;
    }
    private bool IsGrounded()
        {
            return Physics2D.BoxCast(col.bounds.center, col.bounds.size - new Vector3(0.3f, 0, 0), 0f, Vector2.down, .1f, jumpGround);
        }
}
