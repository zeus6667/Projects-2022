using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
	public GameObject GameOverPanel;
	public GameObject infopanel;
	public Health player1health;
	public Health1 player2health;
	public bool isGameOver;
	public Camera maincam;
	public Inventory playerinventory;
	public string restartString;
	public string mainMenuString;
	// Start is called before the first frame update
	void Start()
	{
		isGameOver = false;
		player1health = GameObject.Find("Player1").GetComponent<Health>();
		player2health = GameObject.Find("Player2").GetComponent<Health1>();
		 
	}

	// Update is called once per frame
	void Update()
	{
		if (player1health.isdead == true && player2health.isdead1== true)
		{
			//Debug.Log("isdeadtruehua");
			isGameOver = true;
			GameOverhua();
		}
	   
	}

	public void GameOverhua()
	{
		if (isGameOver == true)
		{
			//Debug.Log("gameOverhua");
	//		player.GetComponent<Collider>().enabled = false;
	//		health.coincount();
			infopanel.SetActive(false);
			GameOverPanel.SetActive(true);
			maincam.GetComponent<Move1moreplayer>().enabled = false;
			//		Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
	//		time.timerStop();
			isGameOver = false;
		}
	}
	public void restart()
	{
		SceneManager.LoadScene(restartString);
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		if (playerinventory.matchedcoins == 0)
		{
			playerinventory.TotalCoins += (playerinventory.coins1 + playerinventory.coins2 + playerinventory.enemykillscore);
		}
		else
		{
			playerinventory.TotalCoins += (playerinventory.matchedcoins + playerinventory.enemykillscore);
		}
		PlayerPrefs.SetInt("TotalCoins", playerinventory.TotalCoins);
		playerinventory.coins1 = 0;
		playerinventory.coins2 = 0;
		playerinventory.enemykillscore = 0;
		playerinventory.matchedcoins = 0;
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
	}
	public void mainMunu()
	{
		SceneManager.LoadScene(mainMenuString);
		if (playerinventory.matchedcoins == 0)
		{
			playerinventory.TotalCoins += (playerinventory.coins1 + playerinventory.coins2 + playerinventory.enemykillscore);
		}
		else
		{
			playerinventory.TotalCoins +=( playerinventory.matchedcoins + playerinventory.enemykillscore);
		}
		PlayerPrefs.SetInt("TotalCoins", playerinventory.TotalCoins);
		playerinventory.coins1 = 0;
		playerinventory.coins2 = 0;
		playerinventory.enemykillscore = 0;
		playerinventory.matchedcoins = 0;
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
	}

}
