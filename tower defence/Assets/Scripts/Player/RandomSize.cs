using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{

	public float globalScaleMultiplier = 1f;
	public bool scaleUniformly;
	public float uniformScaleMin ;
	public float uniformScaleMax ;

	// Start is called before the first frame update
	void Start()
	{
		RandomizeObjectScale();
	}

	// Update is called once per frame
	void Update()
	{
	   
	}

	void RandomizeObjectScale()
	{
		Vector3 randomizedScale = Vector3.one;
		if (scaleUniformly)
		{
			float uniformScale = Random.Range(uniformScaleMin, uniformScaleMax);
			randomizedScale = new Vector3(uniformScale, uniformScale, uniformScale);
			
		}
		transform.localScale = randomizedScale * globalScaleMultiplier;
	}
}
