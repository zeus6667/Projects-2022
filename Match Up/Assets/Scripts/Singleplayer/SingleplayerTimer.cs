
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SingleplayerTimer : MonoBehaviour
{
	public float timeStart;
	public TextMeshProUGUI textBox;
	public TextMeshProUGUI scoretext;
	public int highscore;
	public Inventory playerinvetory;
	bool timerActive = false;
	
	// Use this for initialization
	void Start()
	{
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		//FindObjectOfType<AudioManager>().play ("gamemusic");
		//textBox.text = timeStart.ToString("F2");
		timerActive = true;
		//if (PlayerPrefs.HasKey("highScore"))
		//{
		//	playerinvetory.highScore = PlayerPrefs.GetInt("highScore", 0);
		//}
	}

	// Update is called once per frame
	void Update()
	{
		if (timerActive)
		{
			timeStart += Time.deltaTime;
			//textBox.text = timeStart.ToString("F2");
			DisplayTime();
		}
		DisplayScore();
	}
	public void timerStop()
	{
		timerActive = !timerActive;
	}
	public void DisplayTime()
	{
		int minutes = Mathf.FloorToInt(timeStart / 60);
		int seconds = Mathf.FloorToInt(timeStart - minutes * 60);
		textBox.text = "Time :" + string.Format("{0:00}:{1:00}", minutes, seconds);
	}
	public void DisplayScore()
	{
		highscore = (playerinvetory.coins3 + playerinvetory.enemykillscore);
		scoretext.text = "Score: " + highscore;
		playerinvetory.highScore = highscore;
		if(playerinvetory.highScore > PlayerPrefs.GetInt("highScore", 0))
		{
			PlayerPrefs.SetInt("highScore", playerinvetory.highScore);
		}
		
	}
	public void Reset()
	{
		timeStart = 0.0f;
	}
	

}