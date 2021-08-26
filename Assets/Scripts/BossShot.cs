using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float moveSpeed, rotSpeed;
    public int damageToPlayer;

    private Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    public void SetDirection(Vector3 spawnerPosition)
    {
        moveDir = transform.position - spawnerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation =Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+(rotSpeed*Time.deltaTime));
        transform.position += moveDir*moveSpeed*Time.deltaTime;    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer(damageToPlayer);
        }
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);    
    }
}