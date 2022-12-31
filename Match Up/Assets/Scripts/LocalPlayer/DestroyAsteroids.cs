using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroids : MonoBehaviour
{
	public GameObject CoinPrefab;
	public float respawnTime = 0.5f;
	public int coinamount;
	public float minY, maxY, minX, maxX;
	// Use this for initialization
	void Start()
	{
		 
		StartCoroutine(asteroidWave());
	}
	private void spawnEnemy()
	{
		coinamount = Random.Range(0, 5);
		for (int i = 0; i < coinamount; i++)
		{
			float randomY = Random.Range(minY, maxY);
			float randomX = Random.Range(minX, maxX);

			Instantiate(CoinPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
		}
		//Debug.Log("Spawnned Asteroid");
	}
	IEnumerator asteroidWave()
	{
		while (true)
		{
			yield return new WaitForSeconds(respawnTime);
			spawnEnemy();
		}
	}
}