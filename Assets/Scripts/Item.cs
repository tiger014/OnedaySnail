using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ParticleSystem particle;
	public GameObject Snail;

	//衝突時に実行されるメソッド
	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.name);

		if(other.name == "Snali")
        {
			// パーティクルを再生する
			particle.Play();

			// 衝突したら自身を削除する
			Destroy(gameObject);

			//スコアのゲームオブジェクトを取得する
			GameObject scoreTextGo = GameObject.Find("ScoreText");
			scoreTextGo.SendMessage("OnScore", 1);
		}
	}
}