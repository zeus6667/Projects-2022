using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public Inventory inventory;
	public GameObject GameOverPanel;
	public string mainMenu;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public void QuitToMain()
	{
		if (inventory.coins != 0)
		{
			inventory.TotalCoins += inventory.coins;
		}
		inventory.coins = 0;
		//Time.timeScale = 1f;
		timescale();
		SceneManager.LoadScene(mainMenu);

	}
	public void restart()
	{
		if (inventory.coins != 0)
		{
			inventory.TotalCoins += inventory.coins;
		}
		inventory.coins = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		timescale();
		//Time.timeScale = 1f;
		Cursor.lockState = CursorLockMode.Locked;
		GameOverPanel.SetActive(false);
	}
	public void timescale()
	{
		if (Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
		} else 
		{
			Time.timeScale = 1f;
		}
	}
}
