using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public int bossHitPoints;
    public int currentBossHP;

    public int stage2Thres, stage3Thres;
    public string bossName;

    public GameObject theBoss, door;

    public Transform[] spawnPoints;
    private Vector3 moveTowards;
    public float moveSpeed;
    public float timeActive, timeBetweenSpawns, firstSpawnDelay;

    public GameObject deathEffect;

    private float activeCounter, spawnCounter;

    public BossShot theShot;
    public Transform[] shotPoints;
    public Transform shotCenter;
    public float delayShots, shotRotateSpeed, shootTime;
    private float shootingCounter;
    private float shotCounter;



    // Start is called before the first frame update
    void Start()
    {
       currentBossHP = bossHitPoints; 
       door.SetActive(true); 

       spawnCounter = firstSpawnDelay;
       UIManager.instance.ActivateBoss(bossName);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBossHP>0)
        {
            if(spawnCounter > 0)
            {
                spawnCounter -= Time.deltaTime;
                if(spawnCounter <=0)
                {
                    activeCounter = timeActive;
                    shootingCounter = shootTime;

                    theBoss.transform.position = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
                    moveTowards = spawnPoints[Random.Range(0,spawnPoints.Length)].position;

                    while(moveTowards == theBoss.transform.position)
                    {
                        moveTowards = spawnPoints[Random.Range(0,spawnPoints.Length)].position;                   
                    }
                    theBoss.SetActive(true);

                }
            } else
            {
                activeCounter -= Time.deltaTime;

                if(activeCounter <= 0)
                {
                    spawnCounter = timeBetweenSpawns;
                    theBoss.SetActive(false);
                }

                theBoss.transform.position = Vector3.MoveTowards(theBoss.transform.position,moveTowards,moveSpeed*Time.deltaTime);
                if(shootingCounter > 0)
                {
                    shootingCounter -= Time.deltaTime;
                    shotCounter -= Time.deltaTime;
                    if(shotCounter<=0)
                    {

                        shotCounter = delayShots;
                        if(currentBossHP>stage2Thres)
                        {
                            for(int i=0;i < 4;i++)
                            {
                                Instantiate(theShot,shotPoints[i].position,shotPoints[i].rotation).SetDirection(shotCenter.position);
                            }
                        } else
                        {
                            for(int i=0;i < shotPoints.Length;i++)
                            {
                                Instantiate(theShot,shotPoints[i].position,shotPoints[i].rotation).SetDirection(shotCenter.position);
                            }
                    
                        }
                        if(currentBossHP<=stage3Thres)
                        {
                            shotCenter.transform.rotation = Quaternion.Euler(
                                shotCenter.transform.rotation.eulerAngles.x,
                                shotCenter.transform.rotation.eulerAngles.y,
                                shotCenter.transform.rotation.eulerAngles.z + (shotRotateSpeed*Time.deltaTime));
                        }
                    }
                }
            }
        }
    }
    public void TakeDamage(int damageToTake)
    {
        currentBossHP -= damageToTake;
        UIManager.instance.UpdateBossHealth(currentBossHP, bossHitPoints);
        if(currentBossHP <= 0)
        {
            currentBossHP = 0;
            theBoss.SetActive(false);
            door.SetActive(false);
            Instantiate(deathEffect,theBoss.transform.position,transform.rotation);
            UIManager.instance.bossInfo.SetActive(false);

        }
    }
}
