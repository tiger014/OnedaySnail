using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class Score : MonoBehaviour
{
    //スコアをメモする変数を宣言する
    public int score = 0;
    public GameObject TimeText;
    public GameObject SnailShell;
    public Material Snail1_Material;
    public Texture Emission1;
    public Texture Emission2;
    public Texture Emission3;
    public Texture Emission4;
    public Texture Emission5;
    public Texture Emission6;

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

    void Start()
    {
        //テクスチャを１にセットする
        Snail1_Material.SetTexture("_EmissionMap", Emission1);
    }
    void Update()
    {
        Koke_texture();

        if (TimeText.GetComponent<Timer>().TimeOver == true)
        {
            //Debug.Log("TimeOver");

            Result();
        }

    }

    void Koke_texture()
    {
        if ((score ==1) && (score == 2))
        {
            //Debug.Log("kawaruze");
            Snail1_Material.SetTexture("_EmissionMap", Emission2);
        }

        if (score == 3)
        {
            Snail1_Material.SetTexture("_EmissionMap", Emission3);
        }
        if (score == 4)
        {
            Snail1_Material.SetTexture("_EmissionMap", Emission4);
        }
        if (score == 5)
        {
            Snail1_Material.SetTexture("_EmissionMap", Emission5);
        }
        if (score == 6)
        {
            Snail1_Material.SetTexture("_EmissionMap", Emission6);
        }

    }

    void Result()
    {
        //エンディング
        if (score == 6) //トゥルー
        {
            Debug.Log("トゥルー");

        }
        if ((score > 3) && (score < 6)) //ノルマ達成
        {
            Debug.Log("ノルマ達成");

        }
        if (score < 4) //ノルマ以下
        {
            Debug.Log("ノルマ以下");

        }
    }

}