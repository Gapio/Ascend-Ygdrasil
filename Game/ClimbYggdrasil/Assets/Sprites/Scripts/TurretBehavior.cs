using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public GameObject tProjectile;
    public GameObject player;
    [SerializeField] private float tCooldownMin = 1;
    [SerializeField] private float tCooldownMax = 6;
    private float tCooldown;
    [SerializeField] private float tProjSpeed;
    private float tTimer;
    private Vector2 aimDirection;

    private void Start()
    {
        tCooldown = Random.Range(tCooldownMin, tCooldownMax);
    }
    void Update()
    {
        if (tTimer > tCooldown)
        {
            Shoot();
        }
        else
        {
            tTimer += Time.deltaTime;
        }
    }

    void Shoot()
    {
        aimDirection = player.transform.position - transform.position; 
        tTimer = 0;
        tCooldown = Random.Range(tCooldownMin, tCooldownMax);
        GameObject bullet = Instantiate(tProjectile, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(aimDirection.x * tProjSpeed, aimDirection.y * tProjSpeed);
        if(rb.velocity.x > 30)
        {
            rb.velocity = new Vector2 (30, rb.velocity.y);
        }
        else if(rb.velocity.x < -30)
        {
            rb.velocity = new Vector2(-30, rb.velocity.y);
        }
        if (rb.velocity.y > 30)
        {
            rb.velocity = new Vector2(rb.velocity.x, 30);
        }
        else if (rb.velocity.y < -30)
        {
            rb.velocity = new Vector2(rb.velocity.x, -30);
        }

    }
}
