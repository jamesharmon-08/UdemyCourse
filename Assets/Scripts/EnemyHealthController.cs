using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{

    public int currentHealth;
    private EnemyController theEC;

    public GameObject deathEffect;
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
                
            }
            Destroy(gameObject);

        }
    }

}