using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
	MeshRenderer meshRenderer;
	[SerializeField][Range(0f, 5f)] float lerpTime;
	[SerializeField] Color[] myColors;
	int colorIndex = 0;
	float t = 0f;
	int len;

	// Start is called before the first frame update
	void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		len = myColors.Length;
	}

	// Update is called once per frame
	void Update()
	{
		meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, 
			myColors[colorIndex], lerpTime * Time.deltaTime);  
		t= Mathf.Lerp(t, 1, lerpTime * Time.deltaTime);
		if (t>0.9f)
		{
			t = 0f;
			colorIndex++;
			colorIndex = (colorIndex >= len) ? 0 : colorIndex;
		}

	}
}
