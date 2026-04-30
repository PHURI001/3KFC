using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int enemiesSpawned = 0;
    private float nextSpawnTime = 0f;

    public bool IsComplete()
    {
        bool enemyAlive = FindFirstObjectByType<Enemy>();
        Debug.Log(enemyAlive);
        return enemiesSpawned >= currentWave?.enemyCount && !enemyAlive;
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        enemiesSpawned = 0;
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (currentWave == null) return;

        if (enemiesSpawned < currentWave.enemyCount && Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            enemiesSpawned++;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(
            currentWave.enemyPrefabs[enemyIndex],
            spawnPoints[spawnIndex].position,
            spawnPoints[spawnIndex].rotation
        );
    }
}