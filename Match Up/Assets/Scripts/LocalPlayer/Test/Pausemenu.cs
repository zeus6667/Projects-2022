using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
	public bool isPaused = false;
	public GameObject pausepanel;
	public Inventory playerinventory;
	public Timer timer;
	public SingleplayerTimer timer1;
	// Start is called before the first frame update
	void Start()
	{
	
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("pause") /*&& !health.isGameOver*/ )
		{
			ChangePause();
		}
		
		timer =GameObject.Find("GameManager").GetComponent<Timer>();
	    timer1 = GameObject.Find("GameManager").GetComponent<SingleplayerTimer>();
		
	}
	public void ChangePause()
	{
		isPaused = !isPaused;
		if (isPaused)
		{
			Time.timeScale = 0f;
			pausepanel.SetActive(true);
		}
		else
		{
			Time.timeScale = 1f;
			pausepanel.SetActive(false);
		}
	}
	public void menu(string scene)
	{
		if (timer != null)
		{
			timer.highscore = 0;
		}
		if (timer1 != null)
		{
			timer1.highscore = 0;
		}
		SceneManager.LoadScene(scene);
		playerinventory.coins3 = 0;
		playerinventory.enemykillscore = 0;
		playerinventory.coins1 = 0;
		playerinventory.coins2 = 0;
		playerinventory.matchedcoins = 0;
		
		
	}
}

//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using StarterAssets;

//public class Pausemenu : MonoBehaviour
//{
//	public bool isPaused = false;
//	public GameObject pausepanel;
//	public string mainMenu;
//	public GameObject GameOverPanel;
//	public GameObject spawnner;
//	public GameObject corcier;
//	public PlayerHealth gameover;
//	public FirstPersonController player;
//	public GameObject healthBar;
//	public GameObject settingpannel;
//	public bool settingon = false;
//	public Inventory inventory;
//	public PlayerHealth health;
//	public bool isGameover;
//	public Timer time;
//	// Start is called before the first frame update
//	void Start()
//	{
//		player = GameObject.Find("Player").GetComponent<FirstPersonController>();

//		time = GameObject.Find("GameOver").GetComponent<Timer>();
//	}

//	// Update is called once per frame
//	void Update()
//	{
//		if (settingon)
//		{
//			settingpannel.SetActive(true);
//		}
//		else
//		{
//			settingpannel.SetActive(false);
//		}
//		if (Input.GetButtonDown("pause") && !health.isGameOver && !settingon)
//		{
//			ChangePause();
//		}
//		isGameover = health.isGameOver;
//		if (isGameover)
//		{
//			DestroyPlayer();
//		}

//	}
//	public void ChangePause()
//	{
//		isPaused = !isPaused;
//		if (isPaused)
//		{
//			Cursor.lockState = CursorLockMode.None;
//			Time.timeScale = 0f;
//			pausepanel.SetActive(true);
//			player.enabled = false;
//			corcier.SetActive(false);
//			spawnner.SetActive(false);
//			healthBar.SetActive(false);

//		}
//		else
//		{
//			Cursor.lockState = CursorLockMode.Locked;
//			Time.timeScale = 1f;
//			pausepanel.SetActive(false);
//			player.enabled = true;
//			corcier.SetActive(true);
//			spawnner.SetActive(true);
//			healthBar.SetActive(true);

//		}
//	}
//	public void settingonhai()
//	{
//		settingon = true;
//	}
//	public void settingoffhai()
//	{
//		settingon = false;
//	}

//	private void DestroyPlayer()
//	{
//		if (isGameover)
//		{
//			player.GetComponent<Collider>().enabled = false;
//			health.coincount();
//			GameOverPanel.SetActive(true);
//			Cursor.lockState = CursorLockMode.None;
//			Time.timeScale = 0f;
//			time.timerStop();
//			isGameover = false;
//		}
//	}

//}

