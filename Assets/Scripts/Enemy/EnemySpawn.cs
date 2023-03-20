using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemyInterval = 3.5f;

    public bool enemiesCanSpawn = true;

    public float firstPosX;
    public float secondPosX;
    public float firstPosY;
    public float secondPosY;

    void Start()
    {   
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Enters Trigger");
            enemiesCanSpawn = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Exits Trigger");
            enemiesCanSpawn = true;
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if (enemiesCanSpawn == true)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(firstPosX, secondPosX), Random.Range(firstPosY, secondPosY), 0), Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
