using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)]
    [SerializeField] float secondsBetweenSpawn = 3f;
    [SerializeField] EnemyMovement enemyPrefab = default;
    [SerializeField] Transform enemyParent = default;
    [SerializeField] Text enemyText = default;
    [SerializeField] AudioClip spawnedEnemySFX = default;

    int num_enemies = 0;

    void Start()
    {
        enemyText.text = num_enemies.ToString();
        enemyText.color = Color.red;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true) //repeatedly spawns enemies forever
        {
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParent;
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            AddScore();
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }

    private void AddScore()
    {
        num_enemies += 1;
        enemyText.text = num_enemies.ToString();
    }
}
