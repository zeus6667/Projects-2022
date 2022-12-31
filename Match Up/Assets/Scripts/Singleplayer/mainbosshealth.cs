using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainbosshealth : MonoBehaviour
{
	public GameObject FloatingTextPrefab;
	public bool cantBeDestroyed = true;
	public float currentHealth, startingHealth = 50;
	public ParticleSystem DeathEffect;
	public ParticleSystem DamageEffect;
	public effectManager effectManager;
	private int enemykillpoint;
	private int enemycollidepoint;
	public bool collided = false;
	public Inventory playerInventory;
	private int damage = 8;
	private Health health;
	private Health1 health1;
	// Start is called before the first frame update
	void Start()
	{
		cantBeDestroyed = true;
		currentHealth = startingHealth;
		effectManager = GameObject.Find("effectManager").GetComponent<effectManager>();
		DamageEffect = effectManager.effects[0];
		DeathEffect = effectManager.effects[1];
		FloatingTextPrefab = effectManager.floatingTextPrefab;
		health = GameObject.Find("Player1").GetComponent<Health>();
		if (health1 != null)
		{
			health1 = GameObject.Find("Player2").GetComponent<Health1>();
		}
		
	}

	// Update is called once per frame
	void Update()
	{
		enemykillpoint = Random.Range(2, 10);
		enemycollidepoint = Random.Range(0, 3);
	}
	public void Takedamage(float Damage)
	{
		if (currentHealth < 0)
		{
			currentHealth = 0;
		}
		if (currentHealth > 0)
		{
			Debug.Log("damage");
			Instantiate(DamageEffect, transform.position, Quaternion.identity);
			currentHealth -= Damage;
		}
		if (currentHealth == 0)
		{
			Debug.Log("enemydead");
			Destroy(this.gameObject);
			FindObjectOfType<AudioManager>().play("enemydead");
			Instantiate(DeathEffect, transform.position, Quaternion.identity);
			if (FloatingTextPrefab)
			{
				showFlotingText();
			}
			playerInventory.enemykillscore += enemykillpoint;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.CompareTag("Player1") && !collided && health.isInvisible == false )
		{
			//collision.GetComponent<Health>().Damage(playerDamage);
			//Destroy(this.gameObject);
			//FindObjectOfType<AudioManager>().play("enemydead");
			Instantiate(DamageEffect, transform.position, Quaternion.identity);
			if (FloatingTextPrefab)
			{
				showFlotingText();
			}
			playerInventory.enemykillscore += enemycollidepoint;
			collided = true;
		}
		if (collision.CompareTag("Player2") && !collided && health1.isInvisible == false) 
		{
			//collision.GetComponent<Health1>().Damage(playerDamage);
			//Destroy(this.gameObject);
			//FindObjectOfType<AudioManager>().play("enemydead");
			Instantiate(DamageEffect, transform.position, Quaternion.identity);
			if (FloatingTextPrefab)
			{
				showFlotingText();
			}
			playerInventory.enemykillscore += enemycollidepoint;
			collided = true;
		}
		if (collision.CompareTag("enemyon"))
		{
			cantBeDestroyed = false;
		}

		if (cantBeDestroyed)
		{
			return;
		}
		if (collision.CompareTag("playerbullet") && !cantBeDestroyed)
		{
			Takedamage(damage);
			Instantiate(DamageEffect, transform.position, Quaternion.identity);
		}

	}
	public void showFlotingText()
	{
		//Debug.Log("floatingText");
		var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
		go.GetComponent<TextMesh>().text = enemykillpoint.ToString();
	}
}
