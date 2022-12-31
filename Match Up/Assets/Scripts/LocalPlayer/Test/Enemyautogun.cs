using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyautogun : MonoBehaviour
{
	public EnemyBullet Bullet;
	public Vector2 direction;

	public bool autoshoot;
	public float shootntervalSeconds = 0.5f;
	public float shootDelaySeconds = 2f;
	float shootTimer = 0;
	float delayTimer = 0;	

	private void Update()
	{
		direction = (transform.localRotation * Vector2.down).normalized;
		if (autoshoot)
		{
			if (delayTimer >= shootDelaySeconds)
			{
				if (shootTimer >= shootntervalSeconds)
				{
					shoot();
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
	public void shoot()
	{
		GameObject go = Instantiate(Bullet.gameObject, transform.position, Quaternion.identity);
		EnemyBullet gobullet = go.GetComponent<EnemyBullet>();
		gobullet.direction = direction;
	}
}

