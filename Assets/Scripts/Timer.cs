using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] float gameTime = 20.0f;        // ゲーム制限時間 [s]
    Text uiText;                                    // UIText コンポーネント
    float currentTime;                              // 残り時間タイマー

    void Start()
    {
        // Textコンポーネント取得
        uiText = GetComponent<Text>();
        // 残り時間を設定
        currentTime = gameTime;
    }

    void Update()
    {
        // 残り時間を計算する
        currentTime -= Time.deltaTime;

        // ゼロになったら
        if (currentTime <= 0.0f)
        {
            // ゼロ秒以下にならないようにする
            currentTime = 0.0f;

        }
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        int mseconds = Mathf.FloorToInt((currentTime - minutes * 60 - seconds) * 1000);
        uiText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}