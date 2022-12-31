
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SinglePlayerCoin : MonoBehaviour
{


	public Inventory PlayerInventory;
	//public TextMeshProUGUI player1Score;

	//public Health player1health;
	//public Health1 player2health;
	
	// Start is called before the first frame update
	void Start()
	{

		//player1Score = GameObject.Find("Player1Coins").GetComponent<TextMeshProUGUI>();

	}

	// Update is called once per frame
	void Update()
	{
		
		//Debug.Log("matchplayerposition:" + child_position);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("boder"))
		{
			//Debug.Log(":>");
			Destroy(this.gameObject);
		}
		if (collision.CompareTag("Player1"))
		{
			//Debug.Log("player1");
			Destroy(this.gameObject);
			FindObjectOfType<AudioManager>().play("CoinCollect");
			PlayerInventory.coins3++;
		//	player1Score.text = " " + PlayerInventory.coins3.ToString() + "x";
		}
	}
}


