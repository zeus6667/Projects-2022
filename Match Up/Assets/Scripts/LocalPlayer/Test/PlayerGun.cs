using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
	public PlayerBullet Bullet;
	public PlayerBullet Bullet1;
	public float shootntervalSeconds = 0.5f;
	public float shootDelaySeconds = 0.2f;
	float shootTimer = 0;
	float delayTimer = 0;
	public bool autoshoot;

	private void Update()
	{

	}
	public void shoot()
	{
		if (delayTimer >= shootDelaySeconds)
		{
			if (shootTimer >= shootntervalSeconds)
			{
				GameObject go = Instantiate(Bullet.gameObject, transform.position, Quaternion.identity);
				shootTimer = 0;
			}
			else
			{
				shootTimer += Time.deltaTime;
			}
		}
		else
		{
			delayTimer += Time.deltaTime;
		}
		
	}
	public void shoot1()
	{
		if (delayTimer >= shootDelaySeconds)
		{
			if (shootTimer >= shootntervalSeconds)
			{
				GameObject go = Instantiate(Bullet1.gameObject, transform.position, Quaternion.identity);
				shootTimer = 0;
			}
			else
			{
				shootTimer += Time.deltaTime;
			}
		}
		else
		{
			delayTimer += Time.deltaTime;
		}

	}
}
