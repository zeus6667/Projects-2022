using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShoot : MonoBehaviour
{
	public float speed =10;
	private Rigidbody2D rb;
	private Vector2 screenBounds;
	public bool shootleft = false;
	public TimeSpawn spanner;
	// Start is called before the first frame update
	void Start()
	{
		spanner = GameObject.Find("Time Spawnner(Clone)").GetComponent<TimeSpawn>();
		shootleft = spanner.shootLeft;
		if (shootleft == true)
		{
			speed = -1 * speed;
		}
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(speed,0);
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}
	private void Update()
	{
		
		if ( transform.position.x > screenBounds.x * 1 || transform.position.x < -screenBounds.x * 1)
		{
			Destroy(this.gameObject);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(this.gameObject);
	}
}
