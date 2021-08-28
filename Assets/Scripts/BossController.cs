using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public int bossHitPoints;
    public int phase1HP, phase2HP, phase3HP;
    public string[] phase1Text;
    public string[] phase2Text;
    public string[] phase3Text;

    public Sprite Skeleton;
    public GameObject[] Rats;
    public int currentBossHP;

    public AudioSource levelBGM, bossBGM;

    public int stage2Thres, stage3Thres;
    public string bossName, finalName;

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
    private int currentphase = 0;
    private bool startphase, deadRats, phase1Complete, phase2Complete, phase3Complete;
    private Transform playerSpot, bossSpot;
    
    

    public GameObject SwordUpgrade;



    // Start is called before the first frame update
    void Start()
    {
       currentBossHP = bossHitPoints; 
       door.SetActive(true); 
       playerSpot = PlayerController.instance.transform;
       bossSpot = theBoss.transform;

      // theBoss.GetComponent<SpriteRenderer>().sprite = Skeleton;

       spawnCounter = firstSpawnDelay;
       UIManager.instance.ActivateBoss(bossName);
       levelBGM.Stop();
       bossBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //starts
        if(currentphase == 0)
        {
            activatephase1();
        }
        if(startphase)
        {
            if(currentphase == 1)
            {
                DialogManager.instance.ShowDialog(phase1Text, false);

                startphase = false;
            }
            if(currentphase == 2)
            {
                DialogManager.instance.ShowDialog(phase2Text, true);

                startphase = false;
            }
            if(currentphase == 3)
            {
                DialogManager.instance.ShowDialog(phase3Text, true);

                startphase = false; 
            }
        }
        if(currentphase == 1 && !phase1Complete)
        {
            deadRats = true;
            foreach(GameObject rat in Rats)
            {
                if(rat!=null)
                {
                    deadRats = false;
                }
            }
            if (deadRats)
            {
                activatePhase2();
                phase1Complete = true;
            }
        }
        if(currentphase == 2 && !phase2Complete)
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
                            for(int i=0;i < 4;i++)
                            {
                                Instantiate(theShot,shotPoints[i].position,shotPoints[i].rotation).SetDirection(shotCenter.position);
                            }
                            
        //                 if(currentBossHP>stage2Thres)
        //                 {
        //                     for(int i=0;i < 4;i++)
        //                     {
        //                         Instantiate(theShot,shotPoints[i].position,shotPoints[i].rotation).SetDirection(shotCenter.position);
        //                     }
        //                 } else
        //                 {
        //                     for(int i=0;i < shotPoints.Length;i++)
        //                     {
        //                         Instantiate(theShot,shotPoints[i].position,shotPoints[i].rotation).SetDirection(shotCenter.position);
        //                     }
                    
        //                 }
        //                 if(currentBossHP<=stage3Thres)
        //                 {
        //                     shotCenter.transform.rotation = Quaternion.Euler(
        //                         shotCenter.transform.rotation.eulerAngles.x,
        //                         shotCenter.transform.rotation.eulerAngles.y,
        //                         shotCenter.transform.rotation.eulerAngles.z + (shotRotateSpeed*Time.deltaTime));
                        }
                    }
                }
            } else
            {
                phase2Complete = true;
                activatePhase3();
            }
        }
        if(currentphase == 3 && !phase3Complete)
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
                            for(int i=0;i < shotPoints.Length;i++)
                            {
                                Instantiate(theShot,shotPoints[i].position,shotPoints[i].rotation).SetDirection(shotCenter.position);
                            }
                            shotCenter.transform.rotation = Quaternion.Euler(
                            shotCenter.transform.rotation.eulerAngles.x,
                            shotCenter.transform.rotation.eulerAngles.y,
                            shotCenter.transform.rotation.eulerAngles.z + (shotRotateSpeed*Time.deltaTime));
                        }
                    }
                }
            } else
            {
                phase3Complete = true;
 
            }
        }
    }
    public void TakeDamage(int damageToTake)
    {
        currentBossHP -= damageToTake;
        UIManager.instance.UpdateBossHealth(currentBossHP, bossHitPoints);
        if(currentBossHP <= 0 && phase3Complete)
        {
            currentBossHP = 0;
            theBoss.SetActive(false);
            door.SetActive(false);
            Instantiate(deathEffect,theBoss.transform.position,transform.rotation);
            UIManager.instance.bossInfo.SetActive(false);
            bossBGM.Stop();
            AudioManager.instance.PlayComplete();
            SwordUpgrade.SetActive(true);


        }
    }

    private void activatephase1()
    {
        // Send rats to the spawn points and have Lorili scream HELP ME!!!
    
        foreach(GameObject Rat in Rats)
        {
            Rat.SetActive(true);
        }
        startphase = true;
        currentphase = 1;

    }

    private void activatePhase2()
    {
        // Have Lorili start attacking while she wanders from spawn point to spawn point.
        startphase = true;
        currentphase = 2;
        bossHitPoints = phase2HP;
        currentBossHP = bossHitPoints; 
    }

    private void activatePhase3()
    {
        startphase = true;
        currentphase = 3;
        bossHitPoints = phase3HP;
        currentBossHP = bossHitPoints; 
        bossName = finalName;
        theBoss.GetComponent<SpriteRenderer>().sprite = Skeleton;
        PlayerController.instance.transform.position = playerSpot.position;
        theBoss.transform.position = bossSpot.position;
        UIManager.instance.ActivateBoss(bossName);
        // Have Lorili change into a skeleton and warp from point to point with the eight shots
        
    }
}
