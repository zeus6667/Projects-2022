using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health1 : MonoBehaviour
{
	public GameObject Player1;
	public float startingHealth1;
	public float currenthealth1;
	public bool isdead1;
	public Animator anim;
	public bool isInvisible;

	public void Awake()
	{
		isdead1 = false;
		startingHealth1 = PlayerPrefs.GetFloat("health");
	}
	private void Start()
	{
		currenthealth1 = startingHealth1;
	}
	private void FixedUpdate()
	{

		if (currenthealth1 < 0)
		{
			currenthealth1 = 0;
		}
	}
	public void Damage(float damagePoints)
	{
		if (currenthealth1 < 0)
		{
			currenthealth1 = 0;
		}
		if (currenthealth1 > 0)
		{
			//Debug.Log("damage");
			currenthealth1 -= damagePoints;
		}
		if(currenthealth1 == 0)
		{
			//Debug.Log("dead");
			isdead1 = true;
			//Player1.SetActive(false);
			anim.SetBool("isdead1", true);
			//Destroy(this.gameObject);
		}
		
			
	}
	public void Heal(float healingPoints)
	{
		if (currenthealth1 < startingHealth1)
		{
			currenthealth1 += healingPoints;
		}
		else
		{
			//Debug.Log("healthfull");
		}
		

	}
}
