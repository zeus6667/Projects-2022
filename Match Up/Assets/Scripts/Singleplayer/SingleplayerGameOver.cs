
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SingleplayerGameOver : MonoBehaviour
{
	public GameObject GameOverPanel;
	public GameObject infopanel;
	public Health player1health;
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
	}

	// Update is called once per frame
	void Update()
	{
		if (player1health.isdead == true)
		{
			player1health.isdead = false;
			//Debug.Log("isdeadtruehua");
			isGameOver = true;
			GameOverhua();
		}

	}

	public void GameOverhua()
	{
		if (isGameOver == true)
		{
			//Debug.Log("singlegameOverhua");
			//		player.GetComponent<Collider>().enabled = false;
			//		health.coincount();
			infopanel.SetActive(false);
			GameOverPanel.SetActive(true);
			maincam.GetComponent<SinglePlayerMover>().enabled = false;
			//		Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
			//		time.timerStop();
			isGameOver = false;
		}
	}

	public void restart()
	{
		SceneManager.LoadScene(restartString);
		playerinventory.TotalCoins += (playerinventory.coins3 + playerinventory.enemykillscore);
		PlayerPrefs.SetInt("TotalCoins", playerinventory.TotalCoins);
		playerinventory.coins3 = 0;
		playerinventory.enemykillscore = 0;
		//StartCoroutine("Restart");
	}
	public void mainMunu()
	{
		SceneManager.LoadScene(mainMenuString); ;
		
		
		//StartCoroutine(LOADING());
		playerinventory.TotalCoins += (playerinventory.coins3 + playerinventory.enemykillscore);
		PlayerPrefs.SetInt("TotalCoins", playerinventory.TotalCoins);
		playerinventory.coins3 = 0;
		playerinventory.enemykillscore = 0;
		//StartCoroutine("mainMewnu");

	}
	IEnumerator LOADING()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("Levelselect");
	}
	//public IEnumerable mainMewnu()
	//{
	//	yield return new WaitForSeconds(5);
	//	SceneManager.LoadScene(mainMenuString);

	//	playerinventory.TotalCoins += (playerinventory.coins3 + playerinventory.enemykillscore);
	//	PlayerPrefs.SetInt("TotalCoins", playerinventory.TotalCoins);
	//	playerinventory.coins3 = 0;
	//	playerinventory.enemykillscore = 0;
	//}
	//public IEnumerable Restart()
	//{
	//	yield return new WaitForSeconds(5);
	//	SceneManager.LoadScene(restartString);
	//	playerinventory.TotalCoins += (playerinventory.coins3 + playerinventory.enemykillscore);
	//	PlayerPrefs.SetInt("TotalCoins", playerinventory.TotalCoins);
	//	playerinventory.coins3 = 0;
	//	playerinventory.enemykillscore = 0;
	//}

}
