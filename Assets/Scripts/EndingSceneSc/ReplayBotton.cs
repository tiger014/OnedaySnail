using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//�V�[���J�ڂɎg�p����N���X�̖��O���

public class ReplayBotton : MonoBehaviour
{
	public void OnGameReplay()
	{
		SceneManager.LoadScene("StartScene");
	}
}