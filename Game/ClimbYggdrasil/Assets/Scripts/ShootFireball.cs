using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public GameObject projectile;
    public int damage;
    public float projSpeed;
    public float dir = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameObject spell = Instantiate(projectile, transform.position, Quaternion.identity);
            spell.GetComponent<Rigidbody2D>().velocity = new Vector2(dir * projSpeed, 0);
        }  
    }
}
