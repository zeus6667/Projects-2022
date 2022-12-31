using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public bool rotateConstantly, rotateleft, rotateright;
	private float RotateAmount;
	// Start is called before the first frame update
	void Start()
	{
		rotateConstantly = true;
		RotateAmount = Random.Range(1,3);
	}

	// Update is called once per frame
	void Update()
	{
		
		if (rotateConstantly && rotateright)
		{
			transform.Rotate(Vector3.back * RotateAmount);
		}
		if (rotateConstantly && rotateleft)
		{
			transform.Rotate(Vector3.forward * RotateAmount);
		}
	}
}
