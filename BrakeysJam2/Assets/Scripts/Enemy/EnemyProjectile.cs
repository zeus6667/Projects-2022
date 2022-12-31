using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
	public PlayerHealth player;
	Vector3 targetPosition;
	public float speed;
	public ParticleSystem damage;
	// Start is called before the first frame update
	void Start()
	{
		targetPosition = FindObjectOfType<PlayerMovement>().transform.position;
		player = GameObject.Find("Player").GetComponent<PlayerHealth>();
	}

	// Update is called once per frame
	void Update()
	{
	 
		transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		if (transform.position == targetPosition)
		{
			Destroy(gameObject);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("playerHurt");
			Destroy(gameObject);
			//damage
			player.ModifyHealth(10);
			FindObjectOfType<AudioManager>().play("Damage");
			Instantiate(damage, transform.position, Quaternion.identity);
		}
		if (collision.CompareTag("innMates"))
		{
			Debug.Log("playerHurt");
			Destroy(gameObject);
			//damage
			collision.GetComponent<InnMatesHealth>().Damage(10f);
			//FindObjectOfType<InnMatesHealth>().Damage(10f);
			FindObjectOfType<AudioManager>().play("Damage");
			Instantiate(damage, transform.position, Quaternion.identity);
		}
		if (collision.CompareTag("PlayerHit"))
		{
			this.gameObject.GetComponent<enemyhealth>().Takedamage(10);
			Instantiate(damage, transform.position, Quaternion.identity);
		}
	}
}
