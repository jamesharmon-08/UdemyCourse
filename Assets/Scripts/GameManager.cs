using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
    // Start is called before the first frame update

    public int currentCoins;

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCoins(int coinToAdd)
    {
        currentCoins += coinToAdd;
        UIManager.instance.UpdateCoins();
    }
}
