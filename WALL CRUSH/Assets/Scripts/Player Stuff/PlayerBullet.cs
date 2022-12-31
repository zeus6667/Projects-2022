using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	
	public int maxmag;
	[HideInInspector]
	public LevelGoals levelGoals;
	

	// Start is called before the first frame update
	void Start()
	{
		levelGoals = GameObject.Find("LevelGoal").GetComponent<LevelGoals>();	
		maxmag = levelGoals.magsreq;
		
	}
	void Update()
	{

	}
	public void OnTriggerEnter(Collider other)
	{
		
		if (other.CompareTag("wall") )
		{
			Debug.Log("wall bhai");
			Destroy(this.gameObject);
		}
	}
}


