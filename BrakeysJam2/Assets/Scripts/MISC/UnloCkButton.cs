using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnloCkButton : MonoBehaviour
{
	public SpriteRenderer Spritechange;
	public Sprite lockSprite;
	public Sprite unlockSprite;
	public GameObject wall;
	public Inventory playerInventory;
	bool once, twice;
	public innMatesFollowAnim innplayer;
	public PlayerHealth player;
	public int increseAmount;
	// Start is called before the first frame update
	void Start()
	{
		player= FindObjectOfType<PlayerHealth>();
		Spritechange = this.gameObject.GetComponent<SpriteRenderer>();
		Spritechange.sprite = lockSprite;
	}

	// Update is called once per frame
	void Update()
	{
	 
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && !twice)
		{
			Debug.Log("pressed");
			twice = true;
			FindObjectOfType<AudioManager>().play("unlockdoor");
			this.GetComponent<BoxCollider2D>().enabled = false;
			innplayer.GetComponent<innMatesFollowAnim>().enabled = true;
			Spritechange.sprite = unlockSprite;
			wall.SetActive(false);
			countUp();

		}
	}
	public void countUp()
	{
		if (!once)
		{
			once = true;
			playerInventory.innametsCount += 1;
			if (player.currentHealth < player.maxhealth)
			{
				player.Heal(increseAmount);
			}
			if (player.currentHealth == player.maxhealth)
			{
				player.maxhealth += increseAmount;
				player.currentHealth = player.maxhealth;
			}
			
		}
	}
}
