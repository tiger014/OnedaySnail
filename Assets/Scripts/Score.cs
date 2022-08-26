using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//UIをスクリプトから動かせるように追加する

public class Score : MonoBehaviour
{
    //スコアをメモする変数を宣言する
    public static int score = 0;

    public GameObject TimeText;
    public GameObject SnailShell;
    public Material Snail1_Material;
    public Texture Emission1;
    public Texture Emission2;
    public Texture Emission3;
    public Texture Emission4;
    public Texture Emission5;
    public Texture Emission6;

    public GameObject Koke0;
    public GameObject Koke1;
    public GameObject Koke2;
    public GameObject Koke3;
    public GameObject Koke4;
    public GameObject Koke5;

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
        Koke_TextureGeuge();

        if (TimeText.GetComponent<Timer>().TimeOver == true)
        {
            //Debug.Log("TimeOver");
            Result();
        }
    }
    void Koke_TextureGeuge()
    {
        switch (score)
        {
            case 1:
                Snail1_Material.SetTexture("_EmissionMap", Emission2);
                Koke0.SetActive(false);
                Koke1.SetActive(true);
                break;
            case 2:
                Snail1_Material.SetTexture("_EmissionMap", Emission3);
                Koke1.SetActive(false);
                Koke2.SetActive(true);
                break;
            case 3:
                Snail1_Material.SetTexture("_EmissionMap", Emission4);
                Koke2.SetActive(false);
                Koke3.SetActive(true);
                break;
            case 4:
                Snail1_Material.SetTexture("_EmissionMap", Emission5);
                Koke4.SetActive(true);
                break;
            case 5:
                Snail1_Material.SetTexture("_EmissionMap", Emission6);
                Koke5.SetActive(true);
                break;
            default:
                Snail1_Material.SetTexture("_EmissionMap", Emission1);
                Koke0.SetActive(true);
                break;
        }
    }
    void Result()
    {
        //エンディング
        if (score == 5) //トゥルー
        {
           // Debug.Log("トゥルー");

        }
        if ((score > 2) && (score < 5)) //ノルマ達成
        {
            //Debug.Log("ノルマ達成");

        }
        if (score < 3) //ノルマ以下
        {
            //Debug.Log("ノルマ以下");

        }
    }

}