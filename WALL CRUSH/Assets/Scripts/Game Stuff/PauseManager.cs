using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
	public bool isPaused;
	public GameObject pausepanel;
	public string mainMenu;
	
	public LevelGoals levelgoal;
	public PlayerHealth gameover;

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("pause") && !levelgoal.isgoal &&!gameover.isGameOver )
		{
			ChangePause();
		}
	} 
	public void ChangePause()
	{
		isPaused  = !isPaused;
		if(isPaused)
		{
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
			pausepanel.SetActive(true);
		
		}
		else
		{
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1f;
			pausepanel.SetActive(false);
		   
		}
	}
   public  void QuitToMain()
	{
		SceneManager.LoadScene(mainMenu);
		Time.timeScale = 1f;
	}
	public void PlayGame()
	{
	    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
		 UIManager.instance.Kills = 0;
	     UIManager.instance.powers = 0;
		 UIManager.instance.mags = 0;
			
	}
	public void RESTART()
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		 UIManager.instance.Kills = 0;
		 UIManager.instance.powers = 0;
		 UIManager.instance.mags = 0;
	}
}
