using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMover : MonoBehaviour
{
	//variables
	public float power, speed;
	public ParticleSystem smoke;
	//player1
	[HideInInspector]
	public Vector3 touchPosition;
	[HideInInspector]
	public Vector3 startpos;
	[HideInInspector]
	public Vector3 endpos;
	[HideInInspector]
	public Vector3 direction;

	[HideInInspector]
	public Vector3 direction1, directionXY;

	private float ScreenWidth;
	public Transform player1;
	
	private Animator anim;

	private Rigidbody2D rb1;
	
	private Health player1health;
	

	public PlayerGun gun;

	// Use this for initialization
	void Start()
	{
		float directionX = Input.GetAxisRaw("Horizontal");
		directionXY = new Vector2(directionX, 0f).normalized;
		ScreenWidth = Screen.width;
		rb1 = player1.GetComponent<Rigidbody2D>();
		anim = player1.GetComponent<Animator>();
		player1health = GameObject.Find("Player1").GetComponent<Health>();
		gun = player1.transform.GetComponentInChildren<PlayerGun>();
		
	}

	// Update is called once per frame
	void Update()
	{
		int i = 0;
		//loop over every touch found
		while (i < Input.touchCount)
		{
			if (Input.GetTouch(i).position.x < ScreenWidth)
			{

				if (Input.touchCount > 0)
				{
					//Debug.Log("touched");
					rb1.velocity = new Vector2(directionXY.x * speed, 0f);
					Touch touch = Input.GetTouch(i);
					anim.SetBool("touch", true);
					smoketrocket();
					if (player1health.isdead == false)
					{
						gun.shoot();
					}
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
						Throw();
						anim.SetBool("touch", false);
					}
				}
				else
				{
					Debug.Log("nottouched");

					Touch touch = Input.GetTouch(i);
					startpos = Camera.main.ScreenToWorldPoint(touch.position);
					rb1.velocity = new Vector2(directionXY.x * speed, 0f);
				}
			}
			
			++i;
		}

	}
	public void Throw()
	{
		direction = (endpos - startpos).normalized;

		player1.GetComponent<Rigidbody2D>().isKinematic = false;
		player1.GetComponent<Rigidbody2D>().AddForce(direction * power);
	}
	public void smoketrocket()
	{
		if (player1health.isdead == false)
		{
			smoke.Play();
		}
	}
}

