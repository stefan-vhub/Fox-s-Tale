using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth, currentHealth;
    public float invicibleLength;
    private float invicibleCounter;
    private SpriteRenderer theRB;
    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theRB = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invicibleCounter > 0)
        {
            invicibleCounter -= Time.deltaTime; 

            if(invicibleCounter <= 0)
            {
                theRB.color = new Color(theRB.color.r, theRB.color.g, theRB.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if(invicibleCounter <= 0)
        {
            currentHealth --;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Instantiate(deathEffect, transform.position, transform.rotation);
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invicibleCounter = invicibleLength;
                theRB.color = new Color(theRB.color.r, theRB.color.g, theRB.color.b, .5f);
                PlayerController.instance.KnockBack();
                AudioManager.instance.PlaySFX(9);
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
