using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	///public GameObject Player;
	public float startingHealth = 100;
	public float currenthealth;
	public bool isdead;
	//public Animator anim;
	//public int innMatesRdius;
	public Inventory playerInventory;
	public void Awake()
	{
		isdead = false;
		
	}
	private void Start()
	{
		currenthealth = startingHealth;
	}
	
	private void FixedUpdate()
	{

		if (currenthealth < 0)
		{
			currenthealth = 0;
		}
	}
	public void Damage(float damagePoints)
	{
		
		if (currenthealth > 0)
		{
			Debug.Log("damage1");
			currenthealth -= damagePoints;
		}
		if(currenthealth == 0)
		{
			Debug.Log("dead1");
			isdead = true;
			//Player.SetActive(false);
			//anim.SetBool("isdead",true);
		}
			
	}
	public void Heal(float healingPoints)
	{
		if (currenthealth < startingHealth)
		{
			Debug.Log("healed");
			currenthealth += healingPoints;
		}
		else
		{
			Debug.Log("healthfull");
		}
			

	}
}

