using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Playtrigger : MonoBehaviour
{
	public GameObject Player1, Player2, MatchedPlayer;
	public Boolienhai Matched;
	public PlayerTriggerCheck playerTrigger;
	public Inventory PlayerInventory;
	public TextMeshProUGUI matchedScore;
	private int maxMatchedCoin = 50;
	public TextMeshProUGUI player1Score;
	public TextMeshProUGUI player2Score;
	// Start is called before the first frame update
	void Start()
	{
		Matched = GameObject.Find("GameManager").GetComponent<Boolienhai>();
		matchedScore = GameObject.Find("matchedcoins").GetComponent<TextMeshProUGUI>();
		player1Score = GameObject.Find("Player1Coins").GetComponent<TextMeshProUGUI>();
		player2Score = GameObject.Find("Player2Coins").GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{	
		if (Matched.Matched == true)
		{
			coinstry();
		}
		player2Score.text = " " + PlayerInventory.coins2.ToString() + "x";
		player1Score.text = " " + PlayerInventory.coins1.ToString() + "x";
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//if(collision.CompareTag("Player"))
		//{
		//	Matched.Matched = true;
		//	//playerTrigger.poweruptime = 0f;
		//	Player1.SetActive(false);
		//	Player2.SetActive(false);
		//	MatchedPlayer.SetActive(true);
		//}

		if ((collision.CompareTag("Player1") || collision.CompareTag("Player2")) 
			&& PlayerInventory.coins1 > maxMatchedCoin 
			&& PlayerInventory.coins2 > maxMatchedCoin)
		{
			Debug.Log("Matched");
			Matched.Matched = true;
			playerTrigger.powerupcount();
			Player1.SetActive(false);
			Player2.SetActive(false);
			MatchedPlayer.SetActive(true);
			coinstry();
			
		}
		//else
		//{
		//	Debug.Log("sgsgMatched");
		//	Matched.Matched = false;
		//	playerTrigger.powerupcount();
		//	Player1.SetActive(true);
		//	Player2.SetActive(true);
		//	MatchedPlayer.SetActive(false);
		//}
	}
	public void coinstry()
	{
		Debug.Log("hehe");
		if (PlayerInventory.coins1 > maxMatchedCoin 
			&& PlayerInventory.coins2 > maxMatchedCoin)
		{
			PlayerInventory.matchedcoins += (PlayerInventory.coins1 + PlayerInventory.coins2);
			matchedScore.text = " " + PlayerInventory.matchedcoins.ToString() + "x";
			PlayerInventory.coins1 = 0;
			PlayerInventory.coins2 = 0;
		}
		
	}
}
