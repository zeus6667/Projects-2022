using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
	private Vector3 attackPoint;
	public float maxforce,minforce;
	private float shootForce;
	public GameObject bullet;
	public Vector3 targetPoint;
	public float spawnTime , spread,spreadmax ,spreadmin;
	public float DelayTime;
	
	// Start is called before the first frame update
	void Start()
	{
		attackPoint = new Vector3(Random.Range(-25, 25), Random.Range(2, 15), Random.Range(80, 120));
	//	InvokeRepeating("shoot", spawnTime, DelayTime);
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	public void shoot()
	{
		shootForce = Random.Range(minforce, maxforce);
		float x = Random.Range(-spread, spread);
		float y = Random.Range(spreadmin, spreadmax);

		//Calculate direction from attackPoint to targetPoint
		Vector3 directionWithoutSpread = targetPoint - attackPoint;

		Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
		GameObject currentBullet = Instantiate(bullet, attackPoint, Quaternion.identity);
		currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);    
	}
}
