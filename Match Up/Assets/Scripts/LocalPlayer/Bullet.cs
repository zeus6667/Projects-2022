using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	//private Vector2 screenBounds;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(gameObject,1);
		//screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}

	// Update is called once per frame
	void Update()
	{
		//if (transform.position.x > screenBounds.x * 1 || transform.position.x < -screenBounds.x * 1)
		//{
		//	Destroy(this.gameObject);
		//}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(this.gameObject);
	}
}
