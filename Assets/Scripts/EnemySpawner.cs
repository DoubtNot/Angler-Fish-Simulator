using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform spawnPointParent;
    public int maxEnemies = 5;
    public int enemiesPerSpawn = 2;

    private List<Transform> spawnPoints = new List<Transform>();
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        foreach (Transform spawnPoint in spawnPointParent)
        {
            spawnPoints.Add(spawnPoint);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int remainingSpawnCount = maxEnemies - spawnedEnemies.Count;

            int enemiesToSpawn = Mathf.Min(enemiesPerSpawn, remainingSpawnCount);

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in spawnedEnemies)
            {
                Destroy(enemy);
            }
            spawnedEnemies.Clear();
        }
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Count == 0)
        {
            Debug.LogWarning("No spawn points available!");
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Count);
        Transform spawnPoint = spawnPoints[randomIndex];

        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        spawnedEnemies.Add(spawnedEnemy);
    }
}
