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
            enemiesCanSpawn = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemiesCanSpawn = true;
        }
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
            if (enemiesCanSpawn)
            {
                GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(transform.position.x - firstPosX, transform.position.x + secondPosX), Random.Range(transform.position.x - firstPosY, transform.position.y + secondPosY), 0), Quaternion.identity);
                StartCoroutine(spawnEnemy(interval, enemy));
            }
    }
}
