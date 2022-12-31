using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
	private float bgspeed = 0.5f;
	public Renderer backrenderer;
	private DistanceScore distance;
	public  int x = 0;
	public  int n = 500;
	 float increaseamount = 0.05f;
	int increase = 5;
	private CamFollow playermover;
	public destroy[] enemyDamage2player;
	public enemyhealth[] Enemyhealth;
	int increaseEnemyHealth = 5;
	float increasePlayerSpeed = 0.1f;
	float enemydamage = 3f;
	//public PlayerGun gun;
	//public PlayerGun gun1;
	private void Start()
	{
		playermover = FindObjectOfType<CamFollow>();
		//enemyhealth.startingHealth = 50;
		Enemyhealth = FindObjectsOfType<enemyhealth>();
		enemyDamage2player = FindObjectsOfType<destroy>();
	}
	// Update is called once per frame
	void Update()
	{
		
		backrenderer.material.mainTextureOffset += new Vector2(0, bgspeed * Time.deltaTime);
		
	}
	private void FixedUpdate()
	{
		if (distance != null)
		{
		   if (distance.Distance == x + n)
		   {
			    bgspeed += increaseamount;
				playermover.Camspeed += increasePlayerSpeed;
				foreach (var item in Enemyhealth)
				{
					item.startingHealth += increaseEnemyHealth;
				}
				foreach (var item in enemyDamage2player)
				{
					item.damagerate += enemydamage;
				}
				// enemyhealth.startingHealth += increase;
				//gun.shootDelaySeconds += increaseamount;
				//gun1.shootDelaySeconds += increaseamount;
				x += n;
		   }
		}

	}
}
