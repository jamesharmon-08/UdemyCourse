using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    public int currentHealth;
    private EnemyController theEC;

    public GameObject deathEffect;


    public GameObject healthToDrop, coinToDrop;
    public float healthDropChance, coinDropChance;

    // Start is called before the first frame update
    void Start()
    {
        theEC = GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        theEC.KnockBack(PlayerController.instance.transform.position);

        if(currentHealth <=0)
        {
            if (deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, transform.rotation);
                AudioManager.instance.PlaySFX(5);
                
            }
            Destroy(gameObject);
            if(Random.Range(0f, 100f) < healthDropChance && healthToDrop != null)
            {
                Instantiate(healthToDrop, transform.position, transform.rotation);
            }
            if(Random.Range(0f, 100f) < coinDropChance && coinToDrop != null)
            {
                Instantiate(coinToDrop, transform.position, transform.rotation);
            }            

        }
        AudioManager.instance.PlaySFX(8);
    }

}
