using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boolienhai : MonoBehaviour
{
	public bool Matched = false;



	public void Update()
	{
		if (Matched == true)
		{
			StartCoroutine(abool());
		}
		
	}
	IEnumerator abool()
	{
		yield return new WaitForSeconds(60);
		Matched = false;
	}
}
