using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Enemy Spawn")]
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 enemySpawnPoints;
    [SerializeField] float enemySpawnRate;
    [SerializeField] float enemySpawnDelay;
    [Header("Antidote Spawn")]
    [SerializeField] GameObject antidote;
    [SerializeField] Vector2 antidoteSpawnPoints;
    [SerializeField] float antidoteSpawnRate;
    [SerializeField] float antidoteSpawnDelay;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", enemySpawnDelay, enemySpawnRate);
        InvokeRepeating("SpawnAntidote", antidoteSpawnDelay, antidoteSpawnRate);
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, enemySpawnPoints, Quaternion.identity);
        Debug.Log("Spawned Enemy");
    }

    void SpawnAntidote()
    {
        Instantiate(antidote, antidoteSpawnPoints, Quaternion.identity);
        Debug.Log("Spawned Antidote");
    }
}
