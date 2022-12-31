using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Childspawn : MonoBehaviour
{
	public string spawnnerName;
	private GameObject boss;
	public GameObject bossPrefab;
	public int index;
	public float maxX, minX, timeBetweenSpawn, spawnTime;
	public GameObject GameManager;
	public Timer timer;
	public SingleplayerTimer singletimer;
	// Start is called before the first frame update
	void Start()
	{
		GameManager = GameObject.Find("GameManager");
		timer = GameObject.Find("GameManager").GetComponent<Timer>();
		singletimer = GameObject.Find("GameManager").GetComponent<SingleplayerTimer>();
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
		if (singletimer != null)
		{
			if ( singletimer.timeStart > spawnTime)
			{
				spawn();
				spawnTime = singletimer.timeStart + timeBetweenSpawn;
			}
		}
	}
	void spawn()
	{
		boss = Instantiate(bossPrefab,GameManager. transform.position + new Vector3(0, 6, 0),Quaternion.identity);
		boss.transform.SetParent(GameManager.transform);
	}
}

