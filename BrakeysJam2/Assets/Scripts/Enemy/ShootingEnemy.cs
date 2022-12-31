using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
	public float speed, minDistance,timeBetweenShots,nextShotTime;
	public Transform Target;
	public GameObject projectile;
	public ParticleSystem damage;
	private void Start()
	{
		Target = GameObject.Find("Player").transform;
	}
	// Update is called once per frame
	void Update()
	{
		

		if (Time.time > nextShotTime && Vector2.Distance(transform.position, Target.position) < minDistance)
			{

				Instantiate(projectile, transform.position, Quaternion.identity);
				nextShotTime = Time.time + timeBetweenShots;
			}
		
		

		if (Vector2.Distance(transform.position, Target.position) < minDistance)
		{
			transform.position = Vector2.MoveTowards(transform.position, Target.position, -speed * Time.deltaTime);

		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Target.GetComponent<PlayerHealth>().ModifyHealth(10);
		}
		if (collision.CompareTag("PlayerHit"))
		{
			this.gameObject.GetComponent<enemyhealth>().Takedamage(10);
			Instantiate(damage, transform.position, Quaternion.identity);
		}

	}
}
