using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
	public float speed,minDistance;
	public Transform Target;
	public ParticleSystem damage;
	// Start is called before the first frame update

	private void Start()
	{
		Target = GameObject.Find("Player").transform;
	}
	// Update is called once per frame
	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(gameObject);
			Debug.Log("Player");
			Target.GetComponent<PlayerHealth>().ModifyHealth(5);
			damage =   FindObjectOfType<effectManager>().effect[1];
			Instantiate(damage,transform.position,Quaternion.identity);
			//FindObjectOfType<AudioManager>().play("PlayerDeath");
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
			//FindObjectOfType<AudioManager>().play("EnemyDeath");
		}
	}
}
