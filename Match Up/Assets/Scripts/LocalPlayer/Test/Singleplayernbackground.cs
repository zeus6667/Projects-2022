using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleplayernbackground : MonoBehaviour
{
	private float bgspeed = 0.5f;
	public Renderer backrenderer;
	private SinglePlayerDistance distance;
	public int x = 0;
	public int n = 500;
	private float increaseamount = 0.05f;
	public enemyhealth[] Enemyhealth;
	private float enemyhealth1;
	int increaseEnemyHealth = 5;
	float increasePlayerSpeed = 0.1f;
	private CamFollow playermover;
	public SingleplayerDestroy[] enemyDamage2player;
	float enemydamage = 3f; 
	//public PlayerGun gun;
	//public PlayerGun gun1;
	private void Start()
	{
		
		//Enemyhealth.startingHealth = 50;
		playermover = FindObjectOfType<CamFollow>();
		
		//enemyhealth= FindObjectOfType<enemyhealth>();
		//if (gun != null)
		//{
		//	gun = GameObject.Find("Player1").GetComponentInChildren<PlayerGun>();
		//}

		//if (gun1 != null)
		//{
		//	gun1 = GameObject.Find("Player2").GetComponentInChildren<PlayerGun>();
		//}

		distance = GameObject.Find("PlayerManager").GetComponent<SinglePlayerDistance>();
		

	}
	// Update is called once per frame
	void Update()
	{
		Enemyhealth = FindObjectsOfType<enemyhealth>();
		enemyDamage2player = FindObjectsOfType<SingleplayerDestroy>();
		backrenderer.material.mainTextureOffset += new Vector2(0, bgspeed * Time.deltaTime);
		//enemyhealth1 = enemyhealth.startingHealth;
	}
	private void FixedUpdate()
	{
		if (distance != null)
		{
			if (distance.Distance == x + n)
			{
				
				bgspeed += increaseamount;
				//enemyhealth.startingHealth += increaseEnemyHealth;
				playermover.Camspeed += increasePlayerSpeed;
				foreach (var item in Enemyhealth)
				{
					item.startingHealth += increaseEnemyHealth;
				}
				foreach (var item in enemyDamage2player)
				{
					item.damagerate += enemydamage;
				}




			//	enemyDamage2player.damagerate += enemydamage;
				//gun.shootDelaySeconds += increaseamount;
				//gun1.shootDelaySeconds += increaseamount;
				x += n;
			}
		}

	}
}
