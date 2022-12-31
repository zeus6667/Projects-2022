
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
	public GameObject player;
	public PlayerHealth health;
	public InnMatesHealth innMatesHealth;
	// Start is called before the first frame update
	void Start()
	{
		
		player = GameObject.Find("Player");
		
		if (player != null)
		{
			health = player.GetComponent<PlayerHealth>();
		}
		
	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && health.currentHealth < health. maxhealth)
		{
			Destroy(this.gameObject);
			health.Heal(10);
		}
		if (collision.CompareTag("innMates") )
		{
			collision.GetComponent<InnMatesHealth>().Heal(5);
			Destroy(this.gameObject);
		}
	}
}
