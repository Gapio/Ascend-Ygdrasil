using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private float dirX = 0f;
    private float dirY = 0f;
    private bool canDoubleJump = false;
    private bool canDash = true;
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
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal");
        dirY = Input.GetAxisRaw("Vertical");
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
        if (Input.GetKeyDown(KeyCode.P) && canDash)
        {
            Dash();
        }
        if (dashing)
        { 
            dashTime += Time.deltaTime;
        }
        if (!canDash)
        {
            timeSinceDash += Time.deltaTime;
        }
        if (dashTime > dashLength)
        {
            rb.gravityScale = 4;
            dashing = false;
            rb.velocity = new Vector2(0, 0);
            dashTime = 0;
        }
        if (timeSinceDash > dashCooldown)
        {
            canDash = true;
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
            return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpGround);
        }
}
