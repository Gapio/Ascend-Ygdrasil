using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletorTakeDamage : MonoBehaviour
{

    public Animator animator;

    public int currentHealth;
    [SerializeField] public int maxHealth;
    void Start()
    {
        currentHealth = maxHealth;
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
