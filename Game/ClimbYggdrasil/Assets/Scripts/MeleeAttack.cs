using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 31;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {

            if (Input.GetKeyDown(KeyCode.O))
            {
                Attack();
                SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Melee);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        //Play animation
        animator.SetTrigger("Attack");

        //Detect enemy in range 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            string FirstLetter = enemy.name;
            if (FirstLetter[0] == 'S')
            {
            enemy.GetComponent<SkeletorTakeDamage>().SkeleTakeDamage(attackDamage);
            }
            else
            {
            enemy.GetComponent<EnemyTakeDamage>().TakeDamage(attackDamage);
            }
        }
        animator.SetTrigger("Idle");
    }

    void OnDrawGizmoSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
