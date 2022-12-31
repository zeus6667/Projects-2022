using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HostageHealth : MonoBehaviour
{
	private HostageEnemy enemyHeath;
	private int maxhealth = 100;
	public int currentHealth;
	private int amount;

	public event Action<float> OnHealthPctChanged = delegate { };

	private void OnEnable()
	{
		enemyHeath = GetComponent<HostageEnemy>();
		maxhealth = enemyHeath.health;
		currentHealth = maxhealth;//enemyHeath.health;
		amount = enemyHeath.damage;
	}
	public void ModifyHealth()
	{
		Debug.Log("ha hua hai ye bhi");
		currentHealth -= amount;
		float currentHealthPct = (float)currentHealth / (float)maxhealth;
		OnHealthPctChanged(currentHealthPct);
	}

}
