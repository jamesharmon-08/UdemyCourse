using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    // Start is called before the first frame update

    public int currentHealth, maxHealth;

    public float invincibilityLength = 1f;

    private float invCount;
    public GameObject deathEffect;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       currentHealth = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if(invCount > 0)
        {
            invCount -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if (invCount <= 0)
        {
            currentHealth -= damageAmount;

            invCount = invincibilityLength;
        }
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
}
