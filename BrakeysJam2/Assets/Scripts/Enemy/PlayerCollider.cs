using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
	public PlayerHealth player;
	public ParticleSystem damage;
	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerHealth>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			player.ModifyHealth(10);
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
