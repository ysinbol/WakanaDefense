using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakanaCastle : MonoBehaviour
{
    // 体力
    [SerializeField]
    private int hp = 10;

    // 敵が通過した時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.tag == "Enemy")
        {
            hp -= 1;

            // HPが0以下になったらゲームオーバー
            if (hp <= 0)
            {
                GameManager.Instance.GoToGameOver();
            }
        }
    }
}