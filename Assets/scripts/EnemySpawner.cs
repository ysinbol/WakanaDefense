using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1.0f;
    public Transform[] spawnPoints;

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            // スポーンポイントからランダムに1つを選択する
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            // スポーンポイントから敵を生成する
            Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);

            timeSinceLastSpawn = 0.0f;
        }
    }
}
