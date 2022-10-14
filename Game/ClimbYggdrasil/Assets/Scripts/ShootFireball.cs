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

        if (Input.GetKeyDown(KeyCode.P))
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            GameObject fball = Instantiate(projectile, transform.position, Quaternion.identity);
            fball.GetComponent<Rigidbody2D>().velocity = new Vector2(dirX * projSpeed, dirY * projSpeed);
            fball.GetComponent<FireballBehavior>().damage = damage;
        }  
    }

}
