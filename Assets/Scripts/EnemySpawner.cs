using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawn = 3f;
    [SerializeField] EnemyMovement enemyPrefab = default;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) //repeatedly spawns enemies forever
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }   
}
