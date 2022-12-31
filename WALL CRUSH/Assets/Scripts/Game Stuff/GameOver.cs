using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public bool isGameOver;
	public GameObject GameOverPanel;
	public string mainMenu;

	public void Update()
	{
		ChangePause();
	}
	public void ChangePause()
	{
		//isGameOver = !isGameOver;
		if (isGameOver)
		{
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
			GameOverPanel.SetActive(true);
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1f;
			GameOverPanel.SetActive(false);
		}
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void QuitToMain()
	{
		SceneManager.LoadScene(mainMenu);
		Time.timeScale = 1f;
	}
}
