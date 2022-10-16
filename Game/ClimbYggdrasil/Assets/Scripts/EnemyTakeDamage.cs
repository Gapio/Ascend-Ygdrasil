using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{

    public Animator animator;

    public int currentHealth;
    [SerializeField]public int maxHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //DeathCheck();
        if (currentHealth <= 0) 
        {
            animator.SetBool("isDead", true);
        }
        animator.SetTrigger("Hurt");
    }

    private void DeathCheck()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
            animator.SetTrigger("Hurt");
            Destroy(gameObject);
        }
    }


}
