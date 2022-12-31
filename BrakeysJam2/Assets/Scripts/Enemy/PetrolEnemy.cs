using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrolEnemy : MonoBehaviour
{
	public float speed, waitTime;
	public Transform[] petrolPoints;
	private int currentIndex;
	bool once;
	public GameObject player;
	public ParticleSystem damage;
	
	private void Start()
	{
		
		player = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update()
	{
		if (transform.position != petrolPoints[currentIndex].position)
		{
			transform.position = Vector2.MoveTowards(transform.position, petrolPoints[currentIndex].position, speed * Time.deltaTime);
		}
		else
		{
			if (once == false)
			{
				once = true;
				StartCoroutine(wait());
			}
		   
		}
	}
	public IEnumerator wait()
	{
		yield return new WaitForSeconds(waitTime);
		if (currentIndex +1 < petrolPoints.Length)
		{
			currentIndex++;
		}
		else
		{
			currentIndex = 0;
		}
		once = false;	
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("playerHurt");
			player.GetComponent<PlayerHealth>().ModifyHealth(10);
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
