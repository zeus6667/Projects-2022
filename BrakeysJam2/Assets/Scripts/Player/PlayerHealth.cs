
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
	[HideInInspector]
	public int maxhealth = 100;

	public GameObject GameOverPanel;
	public int currentHealth;

	public bool isGameOver = false;
	
	public event Action<float> OnHealthPctChanged = delegate { };

	public TextMeshProUGUI heartCount;

	public void Start()
	{
		

	}
	private void Update()
	{
		if (currentHealth < 0)
		{
			currentHealth = 0;
		}
		heartCount.text = currentHealth.ToString();
		if (currentHealth <= 0)
		{
			Invoke(nameof(DestroyPlayer), 0.5f);
			isGameOver = true;
		}
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
			FindObjectOfType<AudioManager>().play("PlayerDeath");
			GameOverPanel.SetActive(true);
			//Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
			Destroy(gameObject);
		}
	}

	public void Heal(int healingPoints)
	{
		if (currentHealth < maxhealth)
		{
			Debug.Log("healed");
			currentHealth += healingPoints;
		}
		else
		{
			Debug.Log("healthfull");
		}


	}
}
