using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] public int bulletDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies") == false)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.GetComponent<PlayerHealth>().PlayerTakeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}
