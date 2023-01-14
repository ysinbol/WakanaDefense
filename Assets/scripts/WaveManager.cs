using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    // Wave情報を保持するWaveData構造体
    [System.Serializable]
    public struct WaveData
    {
        public List<GameObject> enemyType;
        public int enemyCount;
    }

    // Waveのデータを保持するWaveDataの配列
    public WaveData[] waves;

    // Waveの間隔（秒）
    public float waveInterval = 180f;

    // 現在のWaveの番号
    private int currentWave = 0;

    [SerializeField]
    private int maxWave = 10;

    // 現在のWaveの終了フラグ
    private bool isWaveFinished = false;

    // Wave間のインターバルをカウントするタイマー
    private float waveTimer = 0f;

    // 現在のWaveに生成されている敵の数
    private int currentEnemyCount = 0;

    // 敵を生成する間隔（秒）
    public float enemySpawnInterval = 1f;

    // 敵を生成するタイマー
    private float enemySpawnTimer = 0f;

    // 敵を生成する位置
    public Transform enemySpawnPoint;

    // 敵のプレハブ
    public GameObject enemyPrefab;

    void Start()
    {
        // 最初のWaveを開始する
        StartWave();
    }

    void Update()
    {
        // 現在のWaveが終了していない場合
        if (!isWaveFinished)
        {
            // 敵の生成タイマーを更新する
            enemySpawnTimer += Time.deltaTime;
            // 敵の生成タイマーが敵を生成する間隔を超えた場合
            if (enemySpawnTimer >= enemySpawnInterval)
            {
                // 敵を生成する
                SpawnEnemy();

                // 敵の生成タイマーをリセットする
                enemySpawnTimer = 0;
                // 敵の生成間隔をランダム化
                enemySpawnInterval = Random.Range(1.5f,6f);
;
            }
        }
        else
        {
            // Wave間のインターバルをカウントするタイマーを更新する
            waveTimer += Time.deltaTime;


            // Wave間のインターバルをカウントするタイマーがWave間のインターバルを超えた場合
            if (waveTimer >= waveInterval)
            {
                waveInterval = Random.Range(180,300);
                // 次のWaveを開始する
                StartWave();
            }
        }
    }

    // 次のWaveを開始する
    void StartWave()
    {
        // 現在のWaveの番号をインクリメントする
        currentWave++;

        // 現在のWaveが最終Waveを超えた場合はゲームをクリアする
        if (currentWave > waves.Length)
        {
            // GameManager.Instance.Clear();
            return;
        }

        // Wave間のインターバルをカウントするタイマーをリセットする
        waveTimer = 0f;

        // 現在のWaveの終了フラグをリセットする
        isWaveFinished = false;

        // 現在のWaveに生成されている敵の数をリセットする
        currentEnemyCount = 0;

        // 現在のWaveに必要な敵を生成する
        for (int i = 0; i < waves[currentWave - 1].enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    // 敵を生成する
    // 敵を生成する
    void SpawnEnemy()
    {
        // 敵を生成する
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);

        // 生成した敵を保持するリストに追加する
        // EnemyManager.instance.enemies.Add(enemy);

        // 現在のWaveに生成されている敵の数をインクリメントする
        currentEnemyCount++;
    }

    // 敵が倒された時に呼び出される
    public void OnEnemyKilled()
    {
        // 現在のWaveに生成されている敵の数をデクリメントする
        currentEnemyCount--;

        // 現在のWaveに生成されている敵がすべて倒された場合
        if (currentEnemyCount <= 0) isWaveFinished = true;
    }
}