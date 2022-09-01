using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KokeItem : MonoBehaviour
{
    public bool getitem;
    public bool oneshot;
    private float eatspeed;

    public AudioSource audioSource;
    public AudioClip soundeat;
    public AudioClip soundgauge;
    public Material ItemMaterial;
    public Texture KokeOnItemTex;
    public Texture KokeOFFItemTex;

    void Start()
    {
        ItemMaterial.SetTexture("_MainTex", KokeOnItemTex);
        ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 1.5f);
    }
    void Update()
    {
        if (getitem == true)
        {
            eatspeed += Time.deltaTime;
            if(eatspeed >= 1.5f) //食べ終わったら
            {
                ItemMaterial.SetTexture("_MainTex", KokeOFFItemTex);    //テクスチャ切り替え
                ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 0.0f);
                oneshot = true;
            }
            if(oneshot)
            {
                audioSource.PlayOneShot(soundgauge);
                GameObject scoreTextGo = GameObject.Find("ScoreText");  //スコアのゲームオブジェクトを取得する
                scoreTextGo.SendMessage("OnScore", 1);
                oneshot = false;
            }
        }






    }
    void OnTriggerEnter(Collider other) //衝突時に実行されるメソッド
    {
        if (other.name == "Snali")
        {
            if(getitem == false)
            {
                audioSource.PlayOneShot(soundeat);
                getitem = true;
            }
        }
    }
}
