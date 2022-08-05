using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	public bool getitem;
	bool on;
	bool Scene3;
	public float counttime = 0;
	public AudioSource audioSource;
	public AudioClip soundeat;
	public AudioClip soundgauge;

	public Material ItemMaterial;
	public Texture KokeOnItemTex;
	public Texture KokeOFFItemTex;

	public Image StoryImage;
	public GameObject DeleteButton;

	//public ParticleSystem Normalparticle;
	//public ParticleSystem Takeparticle;
	public float alpha;
	float fadeSpeed = 0.008f;
	public int a;	//切り替え番号

    private void Start()
    {
		getitem = false;
		Scene3 = false;
		DeleteButton.SetActive(false);
		a = 0;
		alpha = 0;
		ItemMaterial.SetTexture("_MainTex", KokeOnItemTex);
		ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 0.9f);

		//Normalparticle.Play();// パーティクルを再生する
	}
    //衝突時に実行されるメソッド
    void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
		if(other.name == "Snali")
        {
			getitem = true;
			a = 1;//1回目のフロー
			Item_flow();
		}
	}
	private void Update()
	{
		StoryImage.GetComponent<Image>().color = new Color(0.0f, 0.25f, 0.3f, alpha);  //Image取得
		if (getitem == true)
		{
			counttime += Time.deltaTime;
			if ((counttime >= 2.0f)&&(counttime < 4.0f))
			{
				a = 2;//2回目のフロー
				Item_flow();
			}
			if ((counttime >= 4.0f) && (counttime < 4.2f))
			{
				Scene3 = true;
			}
			if(counttime >= 4.2f)
            {
				counttime = 4.2f;
            }
		}
		if (Scene3 == true)
        {
			a = 3;//3回目のフロー
			Item_flow();
			Scene3 = false;
		}
		if (a == 4)
        {
			Item_flow();
		}
	}
	void Item_flow()
    {
		switch (a)
        {
			case 1:
				Debug.Log("シーン1");
				audioSource.PlayOneShot(soundeat);  //食べたときのSE
													//食べたときのアニメーション
				break;
			case 2:
				Debug.Log("シーン2");
				Panel_alpha();
				break;
			case 3:
				Debug.Log("シーン3");
				DeleteButton.SetActive(true);   //ボタンが出てくる
				on = true;
				break;
			case 4:
				Debug.Log("シーン4");
				DeleteButton.SetActive(false);   //ボタンが消える
				Panel_alpha();
				break;
		}
    }
	void Panel_alpha()
    {
		if(on == true)
        {
			if (alpha <= 0.0) //フェードアウト
			{
				alpha = 0.0f;
			}
			else
			{
				alpha -= fadeSpeed;
			}
		}
		else
        {
			if (alpha >= 0.8) //フェードイン
			{
				alpha = 0.8f;
			}
			else
			{
				alpha += fadeSpeed;
			}
		}
	}
	public void OnClick()
	{
		getitem = false;

		a = 4;//4回目のフロー
		ItemMaterial.SetTexture("_MainTex", KokeOFFItemTex);    //テクスチャ切り替え
		ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 0.0f);
		//ノーマルパーティクルが消える

		GameObject scoreTextGo = GameObject.Find("ScoreText");  //スコアのゲームオブジェクトを取得する
		scoreTextGo.SendMessage("OnScore", 1);
		audioSource.PlayOneShot(soundgauge);
	}
}