using UnityEngine;
using System.Collections;

public class EnemySpawner1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float spawnRangeX = 8f;
    public float spawnY = 5f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float randX = Random.Range(-spawnRangeX, spawnRangeX);
            Vector2 spawnPos = new Vector2(randX, spawnY);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
