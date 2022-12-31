
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerTurretGun : MonoBehaviour
{
	public Transform Target1;
	public float Range;
	public bool isDected = false, inverted;
	Vector2 Direction;
	public GameObject gun;
	public GameObject bullet;
	public float FireRate;
	float nextTimeToFire = 0;
	public Transform Shootpoint;
	public float Force;

	// Start is called before the first frame update
	void Start()
	{
		Destroy(this.gameObject,10);
		Target1 = GameObject.Find("Player1").transform;
		if (inverted == true)
		{
			Flip();
		}
	}

	// Update is called once per frame
	void Update()
	{

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

	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, Range);
	}

	void shoot()
	{
		GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
		BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
	}

	public void Flip()
	{
		transform.Rotate(0f, 180f, 0f);
	}

}

