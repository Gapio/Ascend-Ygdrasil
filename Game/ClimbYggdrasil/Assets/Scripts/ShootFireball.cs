using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public GameObject projectile;
    public int damage;
    public float projSpeed;
    float dirX;
    float dirY;
    public float projTimer = 2f;
    [SerializeField] public float cooldown = 1f;

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            dirX = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetKeyDown(KeyCode.I) && projTimer > cooldown)
        {
            GameObject fball = Instantiate(projectile, transform.position, Quaternion.identity);
            if (!MovementLock())
            {
                fball.GetComponent<Rigidbody2D>().velocity = new Vector2(dirX * projSpeed, 0);
                fball.GetComponent<FireballBehavior>().damage = damage;
            }
            else
            {
                dirX = Input.GetAxisRaw("Horizontal");
                dirY = Input.GetAxisRaw("Vertical");
                fball.GetComponent<Rigidbody2D>().velocity = new Vector2(dirX * projSpeed, dirY * projSpeed);
                fball.GetComponent<FireballBehavior>().damage = damage;
            }
            projTimer = 0;
        }
        projTimer += Time.deltaTime;
    }
    public bool MovementLock()
    {
        if (Input.GetKey(KeyCode.U))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
