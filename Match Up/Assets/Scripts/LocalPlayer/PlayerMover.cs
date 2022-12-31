using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
	//variables
	public float power;

	//player1
	[HideInInspector]
	public Vector3 touchPosition;
	[HideInInspector]
	public Vector3 startpos;
	[HideInInspector]
	public Vector3 endpos;
	[HideInInspector]
	public Vector3 direction;

	private float ScreenWidth;
	public Transform player1;

	private Rigidbody2D rb1;
	public MatchedplayerGun[] gun1;
	bool shoot;

	// Start is called before the first frame update
	void Start()
	{
		rb1 = player1.GetComponent<Rigidbody2D>();
		gun1 = transform.GetComponentsInChildren<MatchedplayerGun>();
	}

	// Update is called once per frame
	void Update()
	{
		float directionX = Input.GetAxisRaw("Horizontal");
		direction = new Vector2(directionX, 0f).normalized;
		if (shoot)
		{
			shoot = false;
			foreach (MatchedplayerGun gun in gun1)
			{
				gun.shoot();
			}
		}
	}
	private void FixedUpdate()
	{
		int i = 0;
		//loop over every touch found
		while (i < Input.touchCount)
		{
			if (Input.GetTouch(i).position.x > ScreenWidth / 2)
			{
				if (Input.touchCount > 0)
				{
					rb1.velocity = new Vector2(direction.x * power, 0f);
					Touch touch = Input.GetTouch(i);
					shoot = true;
					touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
					touchPosition.z = 0f;
					player1.transform.position = touchPosition;
					if (touch.phase == TouchPhase.Began)
					{
						startpos = Camera.main.ScreenToWorldPoint(touch.position);
					}
					if (touch.phase == TouchPhase.Ended)
					{
						endpos = Camera.main.ScreenToWorldPoint(touch.position);
						//Throw();
					}
				}
			}
			
			++i;
		}


	}
	
}
