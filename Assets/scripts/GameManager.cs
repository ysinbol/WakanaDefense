using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // GameManagerのインスタンス
    private static GameManager instance;

    // GameManagerのインスタンスを取得するためのプロパティ
    public static GameManager Instance { get { return instance; } }

        private enum SceneType
    {
        GameTitle,
        GamePlay,
        GameOver,
        GameClear
    }

    private void Awake()
    {
        // GameManagerが既に存在している場合は、このGameManagerを破棄する
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // GameManagerをインスタンスとして保持する
        instance = this;

        // GameManagerをシーン遷移で破棄しないようにする
        DontDestroyOnLoad(gameObject);
    }

     public void GoToGamePlay()
    {
        SceneManager.LoadScene(SceneType.GamePlay.ToString());
    }

    public void GoToGameOver()
    {
        SceneManager.LoadScene(SceneType.GameOver.ToString());
    }

}
