using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class Score : MonoBehaviour
{
    //スコアをメモする変数を宣言する
    public int score = 0;
    public GameObject TimeText;

    //メッセージを受け取る
    void OnScore(int num)
    {
        //scoreに受け取った値を追加する
        score += num;

        //Textコンポーネントを取得する
        Text scoreText = gameObject.GetComponent<Text>();

        //scoreをテキストとして表示する
        scoreText.text = score.ToString("00");
    }
    void Update()
    {
        if (TimeText.GetComponent<Timer>().TimeOver == true)
        {
            //Debug.Log("taimuo-ba-");

            //エンディング
            if (score == 5) //トゥルー
            {
                Debug.Log("トゥルー");

            }
            if ((score > 2) && (score < 5)) //ノルマ達成
            {
                Debug.Log("ノルマ達成");

            }
            if (score < 3) //ノルマ以下
            {
                Debug.Log("ノルマ以下");

            }
        }
    }
}