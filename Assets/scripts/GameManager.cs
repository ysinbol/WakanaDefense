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

    // シーン遷移時のフェードカラー、フェードスピードのプロパティ
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private float fadeSpeedMultiplier = 1.0f;

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
        Initiate.Fade(SceneType.GamePlay.ToString(), fadeColor, fadeSpeedMultiplier);
    }

    public void GoToGameOver()
    {
        Initiate.Fade(SceneType.GameOver.ToString(), fadeColor, fadeSpeedMultiplier);
    }

    public void GoToGameClear()
    {
        Initiate.Fade(SceneType.GameClear.ToString(), fadeColor, fadeSpeedMultiplier);
    }

}
