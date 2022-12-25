using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform player;

    void Update()
    {
        // プレイヤーの方向を取得する
        Vector3 direction = player.position - transform.position;

        // プレイヤーの方向に沿って進む
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}