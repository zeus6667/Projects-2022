using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoverupdown : MonoBehaviour
{
	public float movespeed;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void FixedUpdate()
	{
		Vector2 pos = transform.position;

		pos.y -= movespeed* Time.fixedDeltaTime;

		transform.position = pos;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("boder"))
		{
			//Debug.Log("boder");
			Destroy(this.gameObject);
		}
	}
}
