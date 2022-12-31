using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{


	public Inventory PlayerInventory;
	public TextMeshProUGUI playerScore;

	//public Health player1health;
	//public Health1 player2health;

	// Start is called before the first frame update
	void Start()
	{

		playerScore = GameObject.Find("PlayerCoins").GetComponent<TextMeshProUGUI>();

	}

	// Update is called once per frame
	void Update()
	{

		//Debug.Log("matchplayerposition:" + child_position);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Debug.Log("player");
			Destroy(this.gameObject);
			//FindObjectOfType<AudioManager>().play("CoinCollect");
			PlayerInventory.coins++;
			playerScore.text = " " + PlayerInventory.coins.ToString() + "x";
		}
	}
}


