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

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            dirX = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetKeyDown(KeyCode.I))
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
        }
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
