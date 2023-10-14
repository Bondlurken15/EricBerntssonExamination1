using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Enemy Spawn")]
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2[] enemySpawnPoints;
    [SerializeField] float enemySpawnDelay;
    [SerializeField] float enemySpawnRate;
    [SerializeField] float enemySpawnRateIncrease = 0.2f;
    [Header("Antidote Spawn")]
    [SerializeField] GameObject antidote;
    [SerializeField] Vector2[] antidoteSpawnPoints;
    [SerializeField] float antidoteSpawnDelay;
    [SerializeField] float antidoteSpawnRate;
    [SerializeField] float antidoteSpawnRateIncrease = 0.2f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", enemySpawnDelay, enemySpawnRate);
        InvokeRepeating("SpawnAntidote", antidoteSpawnDelay, antidoteSpawnRate);
    }

    void SpawnEnemy()
    {
        int spawnPos = Random.Range(0, enemySpawnPoints.Length);
        Instantiate(enemy, enemySpawnPoints[spawnPos], Quaternion.identity);

        enemySpawnRate -= enemySpawnRateIncrease;
    }

    void SpawnAntidote()
    {
        int spawnPos = Random.Range(0, antidoteSpawnPoints.Length);
        Instantiate(antidote, antidoteSpawnPoints[spawnPos], Quaternion.identity);

        antidoteSpawnRate -= antidoteSpawnRateIncrease;
    }
}
