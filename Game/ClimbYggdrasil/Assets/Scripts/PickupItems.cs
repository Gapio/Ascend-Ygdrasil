using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    [SerializeField] private int heal = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire Powerup"))
        {
            ShootFireball shootFb = GetComponent<ShootFireball>();
            shootFb.canFireball = true;
            shootFb.projTimer = 100;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Health Pack"))
        {
            PlayerHealth pHealth = GetComponent<PlayerHealth>();
            pHealth.playerHealth += heal;
            if (pHealth.playerHealth > 8)
            {
                pHealth.playerHealth = 8;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Dash Powerup"))
        {
            PlayerMovement pMove = GetComponent<PlayerMovement>();
            pMove.dashUnlocked = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Jump Powerup"))
        {
            PlayerMovement pMove = GetComponent<PlayerMovement>();
            pMove.djumpUnlocked = true;
            Destroy(collision.gameObject);
        }
    }
}
