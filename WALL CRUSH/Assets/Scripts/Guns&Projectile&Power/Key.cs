using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public bool rotateConstantly;
	public float RotateAmount;
	// Start is called before the first frame update
	void Start()
	{
		rotateConstantly = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (rotateConstantly)
		{
			transform.Rotate(Vector3.up * RotateAmount);
		}  
	}
}

