
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
	[SerializeField] private float speed = 2f;
	private Vector2 screenBounds;
	
	private void Start()
	{
		
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
	}
	private void Update()
	{
		
		if (transform.position.y < -screenBounds.y * 2 || transform.position.y > screenBounds.y * 7 || transform.position.x > screenBounds.x * 2 || transform.position.x < -screenBounds.x * 2)
		{
			Destroy(this.gameObject);
		}
		transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
	}
}