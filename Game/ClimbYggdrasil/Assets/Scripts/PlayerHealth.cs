using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 8;
    public bool canBeDamaged = true;
    [SerializeField] private float iFrames = 1f;
    private float iTimer = 0f;
    private bool iState = false;
    public GameObject ui;
    void Update()
    {
        if (iState)
        {
            iTimer += Time.deltaTime;
            if(iTimer < 0.333 || iTimer > 0.666){
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            if (iTimer > iFrames)
            {
                canBeDamaged = true;
                iState = false;
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void PlayerTakeDamage(int dmg)
    {
        if (canBeDamaged)
        {
            playerHealth -= dmg;
            if (!PlayerCheckDeath())
        {
            iState = true;
            canBeDamaged = false;
            iTimer = 0f;
            ui.GetComponent<HealthBar>().HealthBarUpdate(playerHealth);
        }
        }

    }



    bool PlayerCheckDeath()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(3);
            return true;
            //add a scene switch here that takes you to the game over screen
        }
        else
        {
            return false;
        }
    }
}
