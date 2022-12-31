using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boom : MonoBehaviour
{
	public float destroyTime = 15;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(this.gameObject,destroyTime);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("destroy");
		if (collision.tag == "boder")
		{
			//Debug.Log(":>");
			Destroy(this.gameObject);
		}
	}
}
