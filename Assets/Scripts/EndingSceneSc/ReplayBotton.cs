using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン遷移に使用するクラスの名前空間

public class ReplayBotton : MonoBehaviour
{
	public void OnGameReplay()
	{
		SceneManager.LoadScene("StartScene");
	}
}