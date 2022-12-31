using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
	public GameObject player1, player2;
	public Health health;
	public Health1 health1;
	// Start is called before the first frame update
	void Start()
	{
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
		if (player1 != null)
		{
			health = player1.GetComponent<Health>();
		}
		if (player2 != null)
		{
			health1 = player2.GetComponent<Health1>();
		}
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player1"))
		{
			Destroy(this.gameObject);
			health.Heal(10);
		}
		if (collision.CompareTag("Player2"))
		{
			Destroy(this.gameObject);
			health1.Heal(10);
		}
		if (collision.CompareTag("boder"))
		{
			Destroy(this.gameObject);
		}
	}
}
