using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{


    public int currentHealth;
    [SerializeField]public int maxHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        DeathCheck();

    }

    private void DeathCheck()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
