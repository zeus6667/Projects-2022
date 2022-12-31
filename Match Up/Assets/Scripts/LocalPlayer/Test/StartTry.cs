using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTry : MonoBehaviour
{
	public GameObject enemy;
	
	void Start()
	{
		InvokeRepeating("spawn",.1f,16);
	}
	public void spawn()
	{
		Instantiate(enemy, this.transform.position, Quaternion.identity);
	}
   
}
