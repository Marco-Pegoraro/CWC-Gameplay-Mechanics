using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject powerupPrefab;

    private float spawnRange = 9;

    private float enemyCount;

    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWaves(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            ++waveNumber;
            SpawnEnemyWaves(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPosition;
    }

    void SpawnEnemyWaves(int enemyQuantity)
    {
        for(int i = 0; i < enemyQuantity; ++i)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
