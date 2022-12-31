
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	public MainMenu menu;
	public GameObject floatingTextPrefab;
	public int healthAmount ;
	public int maxHealth = 60;
	public int minHealth = 40;
	public int Damage;
	public int minDamage ;
	public int maxDamage ;
	public bool texthai = false;

	public LootTable coinloot;
	public Signal roomSignal;


	public GameObject deathEffect;
	public int deathEffectDelay = 1;
	public void Start()
	{
		menu = GameObject.Find("MainMenu").GetComponent<MainMenu>();
		minDamage = menu.maxBullet;
		maxDamage = menu.minBullet;
		Damage = Random.Range(minDamage,maxDamage);

		healthAmount = Random.Range(minHealth, maxHealth);
	}

	private void Update()
	{
		if (!texthai)
		{
			texthai = true;
			if (floatingTextPrefab)
			{
				ShowFlotingText();
			}
		}
	}

	public void TakeDamage()
	{
		healthAmount -= Damage;
		Debug.Log("Damaged");
		if (healthAmount <= 0 )
		{
			MakeLoot();
			FindObjectOfType<AudioManager>().play("RockExplode");
			DeathEffect();
			Destroy(this.gameObject);
			if (roomSignal != null)
			{
				roomSignal.Raise();
			}
		}
		
	}
	private void MakeLoot()
	{
		if (coinloot != null)
		{
			PowerUp current = coinloot.LootPowerUp();
			if (current != null)
			{
				Instantiate(current.gameObject, transform.position, Quaternion.identity);
			}
		}
	}
	private void DeathEffect()
	{
		if (deathEffect != null)
		{
			GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(effect, deathEffectDelay);
		}
	}

	public void ShowFlotingText()
	{
		var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
		go.GetComponent<TextMesh>().text = healthAmount.ToString();
		//floatingTextPrefab.GetComponent<TextMesh>().text = healthAmount.ToString();
	}
	public void Healing(int healPoints)
	{
		healthAmount += healPoints;
		healthAmount = Mathf.Clamp(healthAmount, 0, 100);
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("bullet"))
		{
			Debug.Log("uyw");
			TakeDamage();
		}
	}
}