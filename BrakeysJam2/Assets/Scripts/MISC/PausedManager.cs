using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PausedManager : MonoBehaviour
{

	public bool isPaused = false;
	public GameObject pausepanel;
	public GameObject infoCanvas;
	public GameObject GameOverPanel;
	public TextMeshProUGUI innmatestext;
	public PlayerHealth gameover;
	public PortalAnim count;
	public Inventory inventory;
	public PlayerHealth health;
	public bool isGameover;
	
	// Start is called before the first frame update
	void Start()
	{
		count = FindObjectOfType<PortalAnim>();
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1f;
		}
		inventory.innametsCount = 0;
	}

	// Update is called once per frame
	void Update()
	{
		innmatestext.text = inventory.innametsCount.ToString() +"/"+ count.levelOpenCount;
		if (Input.GetButtonDown("pause") && !health.isGameOver)
		{
			ChangePause();
		}
		isGameover = health.isGameOver;
		if (isGameover)
		{
			DestroyPlayer();
		}
	}
	public void ChangePause()
	{
		isPaused = !isPaused;
		if (isPaused)
		{
			Time.timeScale = 0f;
			pausepanel.SetActive(true);
			infoCanvas.SetActive(false);
			//player.enabled = false;
			//corcier.SetActive(false);
			//spawnner.SetActive(false);
			//healthBar.SetActive(false);

		}
		else
		{

			Time.timeScale = 1f;
			pausepanel.SetActive(false);
			infoCanvas.SetActive(true);
			//player.enabled = true;
			//corcier.SetActive(true);
			//spawnner.SetActive(true);
			//healthBar.SetActive(true);

		}
	}
		private void DestroyPlayer()
		{
			if (isGameover)
			{
				//health.coincount();
				GameOverPanel.SetActive(true);
				Time.timeScale = 0f;
				isGameover = false;
			}
		}
	public void Resume()
	{
	   ChangePause();
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		inventory.innametsCount = 0;
		
	}
	public void MainMenu(string sceneMane)
	{
		SceneManager.LoadScene("Start");
		inventory.innametsCount = 0;

	}


	}
