using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{
	private EnemyAi enemyHeath;
	private int maxhealth;
	public int currentHealth;
	private int amount;

	public event Action<float> OnHealthPctChanged = delegate { };
	
	private void Start()
	{
		enemyHeath = GetComponent<EnemyAi>();
		maxhealth = enemyHeath.health;	
		currentHealth = maxhealth;//enemyHeath.health;
		amount = enemyHeath.damage;
	}
	public void ModifyHealth()
	{
		currentHealth -= amount;
		float currentHealthPct = (float)currentHealth / (float)maxhealth;
		OnHealthPctChanged(currentHealthPct);
	}
	
}

	
