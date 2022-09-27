using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KokeItem : MonoBehaviour
{
	public SphereCollider itemCo;
	public AudioSource audioSource;
	public AudioClip soundeat;
	public Material ItemMaterial;
	public Texture KokeOnItemTex;
	public Texture KokeOFFItemTex;
	public ParticleSystem nparticle;
	float a;

	private float eatspeed;
	private void Start()
	{
		ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 1.5f);
		ItemMaterial.SetTexture("_MainTex", KokeOnItemTex);
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
		if (other.name == "Snali")
		{
			a += 1;
			if (a == 1)
			{
				ItemMaterial.SetTexture("_MainTex", KokeOFFItemTex);    //テクスチャ切り替え
				ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 0.0f);
				audioSource.PlayOneShot(soundeat);
				nparticle.Stop();

				GameObject scoreTextGo = GameObject.Find("ScoreText");  //スコアのゲームオブジェクトを取得する
				scoreTextGo.SendMessage("OnScore", 1);
				itemCo.enabled = false;
			}
			else if (a > 1)
			{
				//itemCo.enabled = false;
			}
		}
	}
}