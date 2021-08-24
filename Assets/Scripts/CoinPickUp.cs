using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int coinValue;
    public float waitToPickup = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitToPickup>0)
        {
            waitToPickup -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && waitToPickup <= 0)
        {
            GameManager.instance.GetCoins(coinValue);
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(4);
        }
    }
}
