using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
	public GameObject FloatingTextPrefab;
	public bool cantBeDestroyed = true;
	public float currentHealth , startingHealth = 50 ;
	public ParticleSystem  DeathEffect;
	public ParticleSystem DamageEffect;
	public effectManager effectManager;
	private int enemykillpoint ;
	private int enemyCollidepoints;
	public int damage = 8 ;
	public bool collided = false;
	public Inventory playerInventory;
	public Health health;
	public Health1 health1;
	// Start is called before the first frame update
	private void Awake()
	{
		damage = PlayerPrefs.GetInt("GunDamage");
	}
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
		if (cantBeDestroyed == true)
		{
			//Debug.Log("hua");
			currentHealth = startingHealth;
		}
		enemykillpoint = Random.Range(1,10);
		enemyCollidepoints = Random.Range(0, 3);
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
	 
		if (collision.CompareTag("Player1") && !collided && health.isInvisible == false)
		{
			Destroy(this.gameObject);
			//collision.GetComponent<Health>().Damage(playerDamage);
			FindObjectOfType<AudioManager>().play("enemydead");
			Instantiate(DamageEffect, transform.position, Quaternion.identity); 
			if (FloatingTextPrefab)
			{
				showFlotingText();
			}
			playerInventory.enemykillscore += enemyCollidepoints;
			collided = true;
		}
		if (collision.CompareTag("Player2") && !collided && health.isInvisible == false)
		{
			Destroy(this.gameObject);
			//collision.GetComponent<Health>().Damage(playerDamage);
			FindObjectOfType<AudioManager>().play("enemydead");
			Instantiate(DamageEffect, transform.position, Quaternion.identity);
			if (FloatingTextPrefab)
			{
				showFlotingText();
			}
			playerInventory.enemykillscore += enemyCollidepoints;
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
			//playerInventory.enemykillscore += enemykillpoint;
		}

	}
	public void showFlotingText()
	{
		//Debug.Log("floatingText");
		var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
		go.GetComponent<TextMesh>().text = enemykillpoint.ToString();
	}
}
