using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemkari : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip soundgauge;
	public Material ItemMaterial;
	public Texture KokeOnItemTex;
	public Texture KokeOFFItemTex;
	public ParticleSystem particle;
	private void Start()
    {
		ItemMaterial.SetTexture("_MainTex", KokeOnItemTex);
		ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 0.9f);
	}
    void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);
		if (other.name == "Snali")
		{
			ItemMaterial.SetTexture("_MainTex", KokeOFFItemTex);    //テクスチャ切り替え
			ItemMaterial.SetVector("_EmissionColor", new Vector4(0.2f, 0.5f, 0.1f) * 0.0f);
			audioSource.PlayOneShot(soundgauge);
			particle.Play();

			GameObject scoreTextGo = GameObject.Find("ScoreText");  //スコアのゲームオブジェクトを取得する
			scoreTextGo.SendMessage("OnScore", 1);
		}
	}
}
