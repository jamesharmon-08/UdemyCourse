using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public GameObject leftSideOpen, rightSideOpen;
    public GameObject treasure;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            leftSideOpen.SetActive(true);
            rightSideOpen.SetActive(true);
            treasure.SetActive(true);
            AudioManager.instance.PlayComplete();

        }
    }
}
