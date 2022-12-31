
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnMatesHealth : MonoBehaviour
{
	///public GameObject Player;
	public float startingHealth = 30;
	public float currenthealth;
	public bool isdead;
	public InnmatesCheck innMate;
	//public Animator anim;
	//public int innMatesRdius;
	public Inventory playerInventory;
	public void Awake()
	{
		isdead = false;

	}
	private void Start()
	{
		innMate = GameObject.Find("EffectManager").GetComponent<InnmatesCheck>();
		currenthealth = startingHealth;
	}

	private void FixedUpdate()
	{
		if (playerInventory.innametsCount < 0)
		{
			playerInventory.innametsCount = 0;
		}
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
		if (currenthealth == 0)
		{
			Debug.Log("dead1");
			isdead = true;
			playerInventory.innametsCount --;
			innMate.length--;
			//this.gameObject.SetActive(false);
			Destroy(this.gameObject);
		
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

