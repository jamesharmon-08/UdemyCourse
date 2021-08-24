using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGift : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "BirthdayBoy")
        {
            GameManager.instance.currentCoins += 200;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
