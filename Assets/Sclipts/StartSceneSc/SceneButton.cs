﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーン遷移に使用するクラスの名前空間

public class SceneButton : MonoBehaviour
{
	public void OnGameStart()
	{
		SceneManager.LoadScene("SampleScene");
	}
}