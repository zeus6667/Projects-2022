using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
	//public GameObject FloatingTextPrefab;
	//public bool cantBeDestroyed = false;
	public float currentHealth , startingHealth = 50 ;
	//public GameObject  DeathEffect;
	//public GameObject DamageEffect;
	////public effectManager effectManager;
	//public int enemykillpoint=10;
	
	//public bool collided = false;
	public Inventory playerInventory;
	// Start is called before the first frame update
	void Start()
	{
		currentHealth = startingHealth;
		////effectManager = GameObject.Find("effectManager").GetComponent<effectManager>();
		//DamageEffect = effectManager.effect[0];
		//DeathEffect = effectManager.effect[1];
		//FloatingTextPrefab = effectManager.floatingTextPrefab;
	}

	// Update is called once per frame
	void Update()
	{
		if (currentHealth < 0)
		{
			currentHealth = 0;
		}
	}
	public void Takedamage(float Damage)
	{
		
		if (currentHealth > 0)
		{
			Debug.Log("damage");
			//Instantiate(DamageEffect, transform.position, Quaternion.identity);
			currentHealth -= Damage;
		}
		if (currentHealth == 0)
		{
			Debug.Log("enemydead");
			Destroy(this.gameObject);
			FindObjectOfType<AudioManager>().play("EnemyDeath");
		
			//Instantiate(DeathEffect, transform.position, Quaternion.identity);
			//if (FloatingTextPrefab)
			//{
			//	showFlotingText();
			//}

		}
	}
	//private void OnTriggerEnter2D(Collider2D collision)
	//{
		
	//	if (collision.CompareTag("Player") && !collided)
	//	{
	//		Destroy(this.gameObject);
	//		//FindObjectOfType<AudioManager>().play("enemydead");
	//		//Instantiate(DamageEffect, transform.position, Quaternion.identity); 
	//		//if (FloatingTextPrefab)
	//		//{
	//		//	showFlotingText();
	//		//}
	//		//playerInventory.enemykillscore += 10;
	//		//collided = true;
	//	}
	//	//if (collision.CompareTag("Player2") && !collided)
	//	//{
	//	//	Destroy(this.gameObject);
	//	//	FindObjectOfType<AudioManager>().play("enemydead");
	//	//	Instantiate(DamageEffect, transform.position, Quaternion.identity);
	//	//	if (FloatingTextPrefab)
	//	//	{
	//	//		showFlotingText();
	//	//	}
	//	//	playerInventory.enemykillscore += 10;
	//	//	collided = true;
	//	//}
	//	//if (collision.CompareTag("enemyon"))
	//	//{
	//	//	cantBeDestroyed = true;
	//	//}
		
	//	//if (cantBeDestroyed)
	//	//{
	//	//	return;
	//	//}
	////	if (collision.CompareTag("playerbullet"))
	////	{
	////		Takedamage(8);
	////		Instantiate(DamageEffect, transform.position, Quaternion.identity);
	////	}

	//}
	////public void showFlotingText()
	////{
	////	Debug.Log("floatingText");
	////	var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
	////	go.GetComponent<TextMesh>().text = enemykillpoint.ToString();
	////}
}
