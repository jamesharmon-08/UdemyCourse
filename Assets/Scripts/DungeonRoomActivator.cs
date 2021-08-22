using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonRoomActivator : MonoBehaviour
{

     public GameObject[] allEnemies;

    private List<GameObject> clonedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
              foreach(GameObject enemy in allEnemies)
        {
            enemy.SetActive(false);
        } 
    }

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            DungeonCameraController.instance.targetPoint = new Vector3(transform.position.x, transform.position.y, DungeonCameraController.instance.targetPoint.z);
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        foreach(GameObject enemy in allEnemies)
        {
            GameObject newEnemy = Instantiate(enemy, enemy.transform.position, enemy.transform.rotation);
            newEnemy.SetActive(true);
            clonedEnemies.Add(newEnemy);
        }
    }
    private void DespawnEnemies()
    {
        foreach(GameObject enemy in clonedEnemies)
        {
            Destroy(enemy);
        }
        clonedEnemies.Clear();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(PlayerHealthController.instance.currentHealth>0)
            {
                DespawnEnemies();
            }
        }
    }
}
