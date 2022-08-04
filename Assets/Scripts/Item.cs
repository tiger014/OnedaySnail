using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip soundeat;
	public AudioClip soundgauge;

	public Material ItemMaterial;
	public Texture KokeOnItemTex;
	public Texture KokeOFFItemTex;
	public ParticleSystem particle;
	public Image TextPanel;

	int a = 0;	//切り替え番号

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
		ItemMaterial.SetTexture("_MainTex", KokeOnItemTex);
		TextPanel.GetComponent<Image>().color = new Color(0, 0, 0, 0);  //Image取得
	}
    //衝突時に実行されるメソッド
    void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);

		if(other.name == "Snali")
        {
			Item_flow();

			particle.Play();// パーティクルを再生する

			// 衝突したら自身を削除する
			Destroy(gameObject);

			//スコアのゲームオブジェクトを取得する
			GameObject scoreTextGo = GameObject.Find("ScoreText");
			scoreTextGo.SendMessage("OnScore", 1);
		}
	}
	void Item_flow()
    {
		switch(a)
        {
			case 1:
				audioSource.PlayOneShot(soundeat);  //食べたときのSE
													//食べたときのアニメーション
				break;
			case 2:
				ItemMaterial.SetTexture("_MainTex", KokeOFFItemTex);	//テクスチャ切り替え

				break;
			case 3:

				break;
			case 4:

				break;
		}


    }
}