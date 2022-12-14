using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Player")
        {
            if(collision.GetComponent<EnemyTakeDamage>() != null)
            {
                collision.GetComponent<EnemyTakeDamage>().TakeDamage(damage);
            }
            else if (collision.GetComponent<SkeletorTakeDamage>() != null)
            {
                collision.GetComponent<SkeletorTakeDamage>().SkeleTakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
