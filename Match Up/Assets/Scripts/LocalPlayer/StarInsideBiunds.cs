using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInsideBiunds : MonoBehaviour
{
	public Transform Player1;
	public Transform Player2;

	
	public GameObject GameManager;

	private void Start()
	{
		GameManager = GameObject.Find("GameManager");
		
	}
	// Update is called once per frame
	void Update()
	{
		Player1.transform.position = new Vector3 (Mathf.Clamp(Player1.transform.position.x,-1.2f,17f),
			Mathf.Clamp(Player1.transform.position.y, -GameManager.transform.position.y, GameManager.transform.position.y), Mathf.Clamp(Player1.transform.position.z,0,0));

		Player2.transform.position = new Vector3(Mathf.Clamp(Player2.transform.position.x, -17f, 1.2f),
		   Mathf.Clamp(Player2.transform.position.y, -GameManager.transform.position.y, GameManager.transform.position.y), Mathf.Clamp(Player2.transform.position.z, 0, 0));
	}
}
