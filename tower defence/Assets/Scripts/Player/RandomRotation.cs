using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		RandomizeYRotation();
	}
	void RandomizeRotation()
	{
		transform.rotation = Random.rotation;  
	}
	void RandomizeYRotation()
	{
		Quaternion RandY = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f,360f), Random.Range(0f, 360f)); 
		transform.rotation = RandY;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
