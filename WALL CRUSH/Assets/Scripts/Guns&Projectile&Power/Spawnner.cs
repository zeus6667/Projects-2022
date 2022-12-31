using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{

	public GameObject wall;
	private int xPos;
	private int zPos;
	private int wallCount;
	public int walls;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(wallDrop());
	}
	IEnumerator wallDrop()
	{
	  while (wallCount < walls)
	  {
		  xPos = Random.Range(90,-90);
		  zPos = Random.Range(90,-90);
		  Instantiate (wall , new Vector3(xPos , 0, zPos),Quaternion.identity);
		  yield return new WaitForSeconds(0.0001f);
		  wallCount += 1;
	  }
	}
}
