using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawn : MonoBehaviour
{
	public GameObject power;
	private int xPos;
	private int zPos;
	private int powerCount;
	public int powerNo;
	public float spawnTime;
	public float DelayTime ;
	public bool stopSpawn = false;
 
	// Start is called before the first frame update
	void Start()
	{
		// repeating function to spawn 
		InvokeRepeating("TimedSpawn", spawnTime, DelayTime);	
	}

	public void TimedSpawn()
	{
		for (int i = 0; i < powerNo; i++)
		{
			// spawn at random place between 90 and -90 and instantiating power at rondom place 
				xPos = Random.Range(90, -90);
				zPos = Random.Range(90, -90);
				Instantiate(power, new Vector3(xPos, 0, zPos), Quaternion.identity);
				powerCount += 1;
		
		}
		
	}
}
