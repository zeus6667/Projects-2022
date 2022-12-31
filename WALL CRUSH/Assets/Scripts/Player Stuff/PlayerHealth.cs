
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
	[HideInInspector]
	public int maxhealth = 100;

	public GameObject GameOverPanel;
	public int currentHealth;

	public bool isGameOver = false;
	
	public event Action<float> OnHealthPctChanged = delegate { };

	

	public void Start()
	{
		

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
		if (other.CompareTag("projectile"))
		{
			ModifyHealth(10);
			Destroy(other.gameObject);
			if (currentHealth <= 0) 
			{
				Invoke(nameof(DestroyPlayer), 0.5f);
				isGameOver = true;
			}
			
		}
		if (other.CompareTag("Heart") && currentHealth < maxhealth)
		{
			ModifyHealth(-10);
			Destroy(other.gameObject);
		}
	}
	
	private void DestroyPlayer()
	{
		if (isGameOver)
		{
			FindObjectOfType<AudioManager>().play("Theme2");
			GameOverPanel.SetActive(true);
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
			Destroy(gameObject);
		}
	}
}
