using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 敵のエネミーを保持する配列
    public List<GameObject> enemies;

    private static EnemyManager instance;
    public static EnemyManager Instance { get { return instance; } }
    private void Awake() {
        instance = this;    
    }

    // 敵を取得する
    public GameObject GetEnemy(int enemyType)
    {
        // 指定されたエネミーの種類を返す
        return enemies[enemyType];
    }

    // 敵を生成する
    public void SpawnEnemy(GameObject enemyPrefab, Transform enemySpawnPoint)
    {
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
        enemies.Add(enemy);
    }
}