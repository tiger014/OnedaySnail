using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour
{
    [SerializeField] float gameTime = 20.0f;        // ゲーム制限時間 [s]
    Text uiText;                                    // UIText コンポーネント
    float currentTime;                              // 残り時間タイマー
    public bool TimeOver;
    public Image FadeoutImage;                      //クリア後のフェードアウト
    float alpha = 0f;
    float fadeSpeed = 0.008f;

    public GameObject Count5;
    public GameObject Count4;
    public GameObject Count3;
    public GameObject Count2;
    public GameObject Count1;

    void Start()
    {
        // Textコンポーネント取得
        uiText = GetComponent<Text>();
        // 残り時間を設定
        currentTime = gameTime; 
    }

    void Update()
    {
        FadeoutImage.GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);  //Image取得

        // 残り時間を計算するS
        currentTime -= Time.deltaTime;

        CountDown();


        // ゼロになったら
        if (currentTime <= 0.0f)
        {
            // ゼロ秒以下にならないようにする
            currentTime = 0.0f;

            TimeOver = true;

            //SceneManager.LoadScene("EndingScene");

            Ending();
        }

        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        int mseconds = Mathf.FloorToInt((currentTime - minutes * 60 - seconds) * 1000);
        uiText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CountDown()
    {
        if (currentTime <= 15.9f)
        {
            Count5.SetActive(true);
        }
        if (currentTime <= 12.9f)
        {
            Count4.SetActive(true);
        }
        if (currentTime <= 9.9f)
        {
            Count3.SetActive(true);
        }
        if (currentTime <= 6.9f)
        {
            Count2.SetActive(true);
        }
        if (currentTime <= 3.9f)
        {
            Count1.SetActive(true);
        }
    }

    void Ending()
    {
        alpha += fadeSpeed;

        if (alpha >= 1.3f) //フェードアウトと切り替わりまでの時間
        {
            SceneManager.LoadScene("EndingScene");
        }
    }


}