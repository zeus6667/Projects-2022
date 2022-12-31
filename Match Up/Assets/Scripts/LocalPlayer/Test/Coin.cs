using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
	private Vector3 child_position;
	public GameObject GameManager;
	public Boolienhai Matched ;
	public GameObject MatchedPlayer;
	public bool isMagnet;
	public Inventory PlayerInventory;
	//public TextMeshProUGUI player1Score;
	//public TextMeshProUGUI player2Score;
	//public TextMeshProUGUI matchedScore;
	//public Health player1health;
	//public Health1 player2health;
	public Rigidbody2D matchedrig;
	// Start is called before the first frame update
	void Start()
	{
		
		//player1Score = GameObject.Find("Player1Coins").GetComponent<TextMeshProUGUI>();
		//player2Score = GameObject.Find("Player2Coins").GetComponent<TextMeshProUGUI>();
		//matchedScore = GameObject.Find("matchedcoins").GetComponent<TextMeshProUGUI>();

		Matched = GameObject.Find("GameManager").GetComponent<Boolienhai>();
		matchedrig = this.GetComponent<Rigidbody2D>();
		//if (MatchedPlayer != null )
		//{
		//	StartCoroutine(Magnet());
		//}
		GameManager = GameObject.Find("GameManager");
		 /*GameManager.transform.GetChild(1).transform.position;*/
		//Vector3 child_position = parent_gameObject.transform.GetChild(0).transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		isMagnet = Matched.Matched;
		if (MatchedPlayer == null)
		{
			MatchedPlayer = GameObject.Find("MatchedPlayer");
		}
		child_position = GameManager.transform.position + MatchedPlayer. transform.localPosition;
		//player1health = GameObject.Find("Player1").GetComponent<Health>();
		//player2health = GameObject.Find("Player2").GetComponent<Health1>();
		if (isMagnet  == true )
		{
			transform.position = Vector3.Lerp(transform.position, child_position, 1f);
			//Vector3 playerPoint = Vector3.MoveTowards(transform.position, MatchedPlayer.transform.position + new Vector3(0, -0.3f, 0), 250 * Time.deltaTime);
			//matchedrig.MovePosition(playerPoint);
		}
		//Debug.Log("matchplayerposition:" + child_position);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("boder"))
		{
			//Debug.Log(":>");
			Destroy(this.gameObject);
		}
		if (collision.CompareTag("Player1") )
		{
			//Debug.Log("player1");
			Destroy(this.gameObject);
			FindObjectOfType<AudioManager>().play("CoinCollect");
			PlayerInventory.coins1 ++;
			//player1Score.text = " " + PlayerInventory.coins1.ToString() +"x";
		}
		if (collision.CompareTag("Player2")  )
		{
			//Debug.Log("player2");
			Destroy(this.gameObject);
			FindObjectOfType<AudioManager>().play("CoinCollect");
			PlayerInventory.coins2 ++;
		//	player2Score.text = " " +PlayerInventory.coins2.ToString() + "x";
		}
		if (collision.CompareTag("Player"))
		{
			//Debug.Log("player2");
			Destroy(this.gameObject);
			FindObjectOfType<AudioManager>().play("CoinCollect");
			PlayerInventory.matchedcoins++;
			//matchedScore.text = " " + PlayerInventory.matchedcoins.ToString() + "x";
		}
		
	}

	//private IEnumerator Magnet()
	//{
	//	yield return new WaitForSeconds(0.1f);
	//	isMagnet = true;
	//}

}

//if (inventory.coins != 0)
//{
//	inventory.TotalCoins += inventory.coins;

//inventory.TotalCoins = inventory.coins1 + inventory.coins2 ;
//&& player1health.isdead == false
//}





//	}
