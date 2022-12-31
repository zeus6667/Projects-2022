using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1moreplayer : MonoBehaviour
{
	//variables
	public float power,speed;
	public ParticleSystem smoke;
	public ParticleSystem smoke1;
	//player1
	[HideInInspector]
	public Vector3 touchPosition;
	[HideInInspector]
	public Vector3 startpos;
	[HideInInspector]
	public Vector3 endpos;
	[HideInInspector]
	public Vector3 direction;

	
	//player2
	[HideInInspector]
	public Vector3 touchPosition1;
	[HideInInspector]
	public Vector3 startpos1;
	[HideInInspector]
	public Vector3 endpos1;
	[HideInInspector]
	public Vector3 direction1, directionXY;

	private float ScreenWidth;
	public Transform player1;
	public Transform player2;
	private Animator anim;
	private Animator anim1;
	private Rigidbody2D rb1;
	private Rigidbody2D rb2;
	private Health player1health;
	private Health1 player2health;

	public PlayerGun gun;
	public PlayerGun gun1;
	// Use this for initialization
	void Start()
	{
		float directionX = Input.GetAxisRaw("Horizontal");
		directionXY = new Vector2(directionX, 0f).normalized;
		ScreenWidth = Screen.width;
		rb1 = player1.GetComponent<Rigidbody2D>();
		rb2 = player2.GetComponent<Rigidbody2D>();
		anim = player1.GetComponent<Animator>();
		anim1 = player2.GetComponent<Animator>();
		player1health = GameObject.Find("Player1").GetComponent<Health>();
		player2health = GameObject.Find("Player2").GetComponent<Health1>();
		gun = player1.transform.GetComponentInChildren<PlayerGun>();
		gun1 = player2.transform.GetComponentInChildren<PlayerGun>();
	}

	// Update is called once per frame
	void Update()
	{
		int i = 0;
		//loop over every touch found
		while (i < Input.touchCount)
		{
			if (Input.GetTouch(i).position.x > ScreenWidth / 2)
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
			if (Input.GetTouch(i).position.x < ScreenWidth / 2)
			{
				
				if (Input.touchCount > 0)
				{
					
					rb2.velocity = new Vector2(directionXY.x * power, 0f);
					Touch touch1 = Input.GetTouch(i);
					anim1.SetBool("touched", true);
					smoketrocket1();
					if (player2health.isdead1 == false)
					{
						gun1.shoot1();
					}
					touchPosition1 = Camera.main.ScreenToWorldPoint(touch1.position);
					touchPosition1.z = 0f;
					player2.transform.position = touchPosition1;
					if (touch1.phase == TouchPhase.Began)
					{
						startpos1 = Camera.main.ScreenToWorldPoint(touch1.position);
					}
					if (touch1.phase == TouchPhase.Ended)
					{
						endpos1 = Camera.main.ScreenToWorldPoint(touch1.position);
						Throw1();
						anim1.SetBool("touched", false);
					}
				}
				else
				{
					
					Touch touch1 = Input.GetTouch(i);
					
					startpos1 = Camera.main.ScreenToWorldPoint(touch1.position);
					rb2.velocity = new Vector2(directionXY.x * speed, 0f);
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
	public void Throw1()
	{
		direction1 = (endpos1 - startpos1).normalized;

		player2.GetComponent<Rigidbody2D>().isKinematic = false;
		player2.GetComponent<Rigidbody2D>().AddForce(direction1 * power);
	}
	public void smoketrocket()
	{
		if (player1health.isdead == false)
		{
			smoke.Play();
		}
	}
	public void smoketrocket1()
	{
		if (player2health.isdead1 == false)
		{
			smoke1.Play();
		}
	}

}

