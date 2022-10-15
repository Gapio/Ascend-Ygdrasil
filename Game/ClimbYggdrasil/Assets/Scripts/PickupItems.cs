using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire Powerup"))
        {
            ShootFireball shootFb = GetComponent<ShootFireball>();
            shootFb.canFireball = true;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Health Pack"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Dash Powerup"))
        {
            PlayerMovement pMove = GetComponent<PlayerMovement>();
            pMove.dashUnlocked = true;
            Destroy(collision.gameObject);
        }
    }
}
