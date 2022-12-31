
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
	[HideInInspector]
	public int maxhealth = 100;
	public GameObject GameOverPanel;
	public int currentHealth;

	public bool isGameOver = false;
	
	public event Action<float> OnHealthPctChanged = delegate { };

	public Timer time;

	public string CannonSelect;

	public TextMeshProUGUI coinDisplay;
	public Inventory playerInventory;
	
	public void Start()
	{
		
		time =GameObject.Find("GameOver").GetComponent<Timer>();
	}
	

	private void OnEnable()
	{
		currentHealth = maxhealth;
	}
	
	public void ModifyHealth(int amount)
	{
		currentHealth -= amount;
		float currentHealthPct = (float)currentHealth / (float)maxhealth;
		OnHealthPctChanged(currentHealthPct);
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Rock") && currentHealth > 0)
		{
			ModifyHealth(10);
			if (currentHealth <= 0)
			{
				Debug.Log("added");
				isGameOver = true;
			
			}
		}
		
		if (other.CompareTag("Heart") && currentHealth < maxhealth)
		{
			ModifyHealth(-10);
			Destroy(other.gameObject);
		}
	}

	//private void DestroyPlayer()
	//{
	//	if (isGameOver )
	//	{
	//		isGameOver = false;
	//		Debug.Log("ADDAHAU");
	//		Destroy(gameObject);
	//		coincount();
	//		playerInventory.TotalCoins += playerInventory.coins;
	//		FindObjectOfType<AudioManager>().play("PlayerDeath");
	//		GameOverPanel.SetActive(true);
	//		Cursor.lockState = CursorLockMode.None;
	//		Time.timeScale = 0f;
	//		//Destroy(gameObject);
	//		time.timerStop();
			
	//	}
	//}
	
	public void coincount()
	{
		coinDisplay.text = "" + playerInventory.coins;
		
	}
}
