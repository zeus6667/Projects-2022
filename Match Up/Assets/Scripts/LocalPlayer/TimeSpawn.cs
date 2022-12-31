using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpawn : MonoBehaviour
{

	public GameObject spawnee;
	public bool stopSpawning = false;
	public float spawnTime, spawnDelay, shootTime, shootDelay;
	public bool shootLeft;

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
		InvokeRepeating("shoot", shootTime, shootDelay);
	}
	private void Update()
	{
		
	}
	public void SpawnObject()
	{
		 Instantiate(spawnee, transform.position, transform.rotation);
		if (stopSpawning)
		{
			CancelInvoke("SpawnObject");
		}
	}
	public void shoot()
	{
		if (shootLeft == true)
		{
			shootLeft = false;
		}
		else if (shootLeft == false)
		{
			shootLeft = true;
		}
	}
}
