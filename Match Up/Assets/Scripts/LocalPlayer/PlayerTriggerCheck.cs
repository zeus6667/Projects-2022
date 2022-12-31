using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCheck : MonoBehaviour
{
	public GameObject Player1, Player2, MatchedPlayer;
	//public bool isMatched;
	//public bool isMatched1;
	private SpriteRenderer Matchedsprite;
	private Color col;
	public float poweruptime;
	public float powertime;
	public Inventory playerInventory;
	private Animator anim;
	private Animator anim1;
	public Boolienhai Matched;
	private int maxpowerup = 40;
	//public Playtrigger istouch;
	//public Playtrigger istouch1;
	// Start is called before the first frame update
	void Start()
	{
		Matched = GameObject.Find("GameManager").GetComponent<Boolienhai>();
		//istouch = Player1.GetComponent<Playtrigger>();
		//istouch1 = Player2.GetComponent<Playtrigger>();
		Matchedsprite = MatchedPlayer.GetComponent<SpriteRenderer>();
		
		poweruptime = 0f;
		//isMatched = false;
		col = Matchedsprite.color;
		anim = Player1.GetComponent<Animator>();
		anim1 = Player2.GetComponent<Animator>();
		//Player1.GetComponent<PlayerTriggerCheck>().enabled = false;
		//Player2.GetComponent<PlayerTriggerCheck>().enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		poweruptime += Time.deltaTime;
		if (Matched.Matched == true && poweruptime >= powertime)
		{
			Matched.Matched = false;
			
			col.a = 1;
		    Matchedsprite.color = col;
			notmatched();
			MatchedPlayer.SetActive(false);
		}
	}
	public void powerupcount()
	{
		
		if (playerInventory.coins1 == playerInventory.coins2)
		{
			powertime = ((playerInventory.coins1 + playerInventory.coins2 + 200)/5)/10;
			if (powertime > maxpowerup)
			{
				powertime = maxpowerup;
			}
		}
		else
		{
			powertime = ((playerInventory.coins1 + playerInventory.coins2) / 5) / 10;
			if (powertime > maxpowerup)
			{
				powertime = maxpowerup;
			}
		}
	}
	
	public void matched()
	{
		Player1.SetActive(false);
		Player2.SetActive(false);
		MatchedPlayer.SetActive(true);
		anim.SetBool("ismatched", true);
		anim1.SetBool("ismatched1", true);
		col.a = 0.3f;
		Matchedsprite.color = col;
	}
	public void notmatched()
	{

		Debug.Log("notmatched");
		Player1.SetActive(true);
		Player2.SetActive(true);
		anim.Play("player1aftermatched",-1,0f);
		anim1.Play("player2aftermatched",-1,0f);
		anim.SetBool("ismatched", false);
		anim1.SetBool("ismatched1", false);
		poweruptime = 0f;
	}
	
}

