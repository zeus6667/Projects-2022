using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour,IDataPersistence
{
	public Inventory playerInventory;
	public TextMeshProUGUI totalScore;
	public TextMeshProUGUI highScore;

	// Start is called before the first frame update
	void Start()
	{
		//playerInventory.saveplayer();
		if (PlayerPrefs.HasKey("TotalCoins"))
		{
			playerInventory.TotalCoins = PlayerPrefs.GetInt("TotalCoins");
		}
		if (PlayerPrefs.HasKey("highScore"))
		{
			playerInventory.highScore = PlayerPrefs.GetInt("highScore", 0);
		}
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		//playerInventory.loadplayer();
	}

	// Update is called once per frame
	void Update()
	{
		if (totalScore != null)
		{
			totalScore.text = playerInventory.TotalCoins.ToString();
		}
		if (highScore != null)
		{
			highScore.text = "HighScore"+" "+ playerInventory.highScore.ToString();
		}

	}
	public void StartGame(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	public void quitGame()
	{
		Application.Quit();
		//playerInventory.saveplayer();
	}
	public void LoadData(GameData data)
	{
		this.playerInventory.TotalCoins = data.coinCount;
	}
	public void SaveData(GameData data)
	{
		data.coinCount = this.playerInventory.TotalCoins;
	}

	public void resethighscore()
	{
		PlayerPrefs.DeleteKey("highScore");
		playerInventory.highScore = 0;
		
	}
		
}
