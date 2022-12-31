using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public Vector2 direction = new Vector2(0, 1);
	public float speed = 20;

	public Vector2 Velocity;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(gameObject, 3);
	}

	// Update is called once per frame
	void Update()
	{
		Velocity = direction * speed;
	}
	private void FixedUpdate()
	{
		Vector2 pos = transform.position;
		pos += Velocity * Time.deltaTime;
		transform.position = pos;
	}
}
