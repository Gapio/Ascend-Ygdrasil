using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletorTakeDamage : MonoBehaviour
{

    public Animator animator;

    public int currentHealth;
    [SerializeField] public int maxHealth;
    private bool slowed = false;
    private float slowTimer = 0;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (slowed)
        {
            slowTimer += Time.deltaTime;
            if (slowTimer < 0.5)
            {
                slowed = false;
                rb.velocity = new Vector2(rb.velocity.x * 8, rb.velocity.y);

            }
        }
    }

    public void SkeleTakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
        }
        animator.SetTrigger("Hurt");
    }

    public void DamageSlow()
    {
        rb.velocity = new Vector2(rb.velocity.x / 8, rb.velocity.y);
        slowed = true;
        slowTimer = 0;
    }

    private void SkeleDeathCheck()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetTrigger("Hurt");
            Destroy(gameObject);
        }
    }
}