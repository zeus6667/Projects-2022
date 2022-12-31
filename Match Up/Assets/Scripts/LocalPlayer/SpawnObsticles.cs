using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticles : MonoBehaviour
{
	public string spawnnerName;
	public GameObject[] obstacles;
	public int index;
	public float maxX,maxY, minX,minY,timeBetweenSpawn,spawnTime;
	public Timer timer;
	public SingleplayerTimer singlePlayerTimer;

	private void Awake()
	{
		timer = GameObject.Find("GameManager").GetComponent<Timer>();
		singlePlayerTimer = GameObject.Find("GameManager").GetComponent<SingleplayerTimer>();
	
	}
	// Update is called once per frame
	void Update()
	{
		if (timer != null)
		{
			if (timer.timeStart > spawnTime)
			{
				spawn();
				spawnTime = timer.timeStart + timeBetweenSpawn;
			}
		}

		if (singlePlayerTimer != null)
		{
			if (singlePlayerTimer.timeStart > spawnTime)
			{
				spawn();
				spawnTime = singlePlayerTimer.timeStart + timeBetweenSpawn;
			}
		}
		
	}
	void spawn()
	{
		index = Random.Range(0, obstacles.Length);

		float randomY = Random.Range(minY,maxY);
		float randomX = Random.Range(minX,maxX);

		Instantiate(obstacles[index], transform.position + new Vector3(randomX, randomY, 0),transform.rotation);
	}
}
