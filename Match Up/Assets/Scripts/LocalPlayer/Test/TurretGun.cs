using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
	public Transform Target1;
	public Transform Target2;
	public Transform MatchedTarget;
	public float Range ;
	public bool isDected = false,inverted, isDected1 = false, isDected2 = false;
	Vector2 Direction, Direction1, Direction2;
	public GameObject gun;
	public GameObject bullet;
	public float FireRate;
	float nextTimeToFire = 0;
	public Transform Shootpoint;
	public float Force;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(gameObject,10);
		Target1 = GameObject.Find("Player1").transform;
		Target2 = GameObject.Find("Player2").transform;
		
	
		if (inverted == true)
		{
			Flip();
		}
	}

	// Update is called once per frame
	void Update()
	{
		
		if (MatchedTarget != null)
		{
			MatchedTarget = GameObject.Find("MatchedPlayer").transform;
		}
	
		Vector2 Target1pos = Target1.position;
		Direction = Target1pos - (Vector2)transform.position;
		RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Direction, Range);
		if (hitinfo)
		{
			if (hitinfo.collider.gameObject.tag == "Player1")
			{
				if (isDected == false)
				{
					isDected = true;
				}
			}
			else
			{
				if (isDected == true)
				{
					isDected = false;
				}
			}
			if (isDected)
			{
				gun.transform.up = Direction;
				if (Time.time > nextTimeToFire)
				{
					nextTimeToFire = Time.time + 1 / FireRate;
					shoot();
				}
			}
		}



		Vector2 Target2pos = Target2.position;
		Direction1 = Target2pos - (Vector2)transform.position;
		RaycastHit2D hitinfo2 = Physics2D.Raycast(transform.position, Direction1, Range);
		if (hitinfo2)
		{

			if (hitinfo2.collider.gameObject.tag == "Player2")
			{
				//Debug.Log("hmm");
				if (isDected1 == false)
				{
					isDected1 = true;
				}
			}

			if (isDected1)
			{
				gun.transform.up = Direction1;
				if (Time.time > nextTimeToFire)
				{
					nextTimeToFire = Time.time + 1 / FireRate;
					shoot1();
				}
			}
		}


		if (MatchedTarget != null)
		{
			Vector2 matchedTargetpos = MatchedTarget.position;
			Direction2 = matchedTargetpos - (Vector2)transform.position;
			RaycastHit2D matchedhitinfo = Physics2D.Raycast(transform.position, Direction2, Range);
			if (matchedhitinfo)
			{
				if (matchedhitinfo.collider.gameObject.tag == "MatchedPlayer")
				{
					if (isDected2 == false)
					{
						isDected2 = true;
					}
				}

				if (isDected2)
				{
					gun.transform.up = Direction2;
					if (Time.time > nextTimeToFire)
					{
						nextTimeToFire = Time.time + 1 / FireRate;
						shoot2();
					}
				}
			}
		}
	}
	
	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position,Range);
	}

	void shoot()
	{
		GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
		BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
	}
	void shoot1()
	{
		GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
		BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction1 * Force);
	}
	void shoot2()
	{
		GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
		BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction2 * Force);
	}

	 
	public void Flip()
	{
		transform.Rotate(0f, 180f, 0f);
	}

}
