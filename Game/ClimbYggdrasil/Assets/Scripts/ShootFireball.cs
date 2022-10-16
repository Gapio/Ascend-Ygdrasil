using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public Animator anim;
    public GameObject projectile;
    public int damage;
    public float projSpeed;
    float dirX;
    float dirY;
    float dirXstored;
    public float projTimer = 10f;
    [SerializeField] public float cooldown = 1f;
    public bool canFireball = false;

    void Update()
    {
        
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            dirX = Input.GetAxisRaw("Horizontal");
            dirXstored = dirX;
        }
        if (canFireball) { 
        if (Input.GetKeyDown(KeyCode.I) && projTimer > cooldown)
        {
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Fire_Ball);
            anim.SetTrigger("Fireball");
            GameObject fball = Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody2D rb = fball.GetComponent<Rigidbody2D>();
            if (!MovementLock())
            {
                rb.velocity = new Vector2(dirX * projSpeed, 0);
                if(dirX < 0)
                    {
                        rb.rotation = 180f;
                    }
                fball.GetComponent<FireballBehavior>().damage = damage;
            }
            else
            {
                dirX = Input.GetAxisRaw("Horizontal");
                dirY = Input.GetAxisRaw("Vertical");
                if (dirX == 0 && dirY == 0)
                    {
                        dirX = dirXstored;
                    }
                rb.velocity = new Vector2(dirX * projSpeed, dirY * projSpeed);

                //nightmare hours
                //typing this out hurt me physically and spiritually
                if (dirX < 0)
                    {
                        if (dirY < 0)
                        {
                            rb.rotation = 225f;
                        }
                        else if (dirY > 0)
                        {
                            rb.rotation = 135f;
                        }
                        else
                        {
                            rb.rotation = 180f;
                        }
                    }
                else if (dirX > 0)
                    {
                        if (dirY < 0)
                        {
                            rb.rotation = 315f;
                        }
                        else if (dirY > 0)
                        {
                            rb.rotation = 45f;
                        }
                    }
                    else
                    {
                        if (dirY < 0)
                        {
                            rb.rotation = 270f;
                        }
                        else
                        {
                            rb.rotation = 90f;
                        }

                    }

                fball.GetComponent<FireballBehavior>().damage = damage;
            }
            projTimer = 0;
        }
        projTimer += Time.deltaTime;
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
