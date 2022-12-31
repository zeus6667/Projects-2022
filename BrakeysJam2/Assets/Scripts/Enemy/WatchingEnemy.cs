 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingEnemy : MonoBehaviour
{
	public float rotationSpeed ,visionDistance;
	public LineRenderer lineOfSight;
	public GameObject FireEnemy;
	// Update is called once per frame
	void Update()
	{
		lineOfSight.SetPosition(0,transform.position);

		transform.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime);

		 RaycastHit2D hitinfo = Physics2D.Raycast(transform.position,transform.right,visionDistance);
		if (hitinfo.collider != null)
		{
			Debug.DrawLine(transform.position, hitinfo.point, Color.red);
			lineOfSight.SetPosition(1,hitinfo.point);
			lineOfSight.startColor = Color.red;
			lineOfSight.endColor = Color.red;
			if (hitinfo.collider.tag == "Player")
			{
				Instantiate(FireEnemy, transform.position, Quaternion.identity);
			}
		}
		else
		{
			Debug.DrawLine(transform.position, transform.position + transform.right*visionDistance, Color.green);
			lineOfSight.SetPosition(1, transform.position + transform.right * visionDistance);
			lineOfSight.startColor = Color.green;
			lineOfSight.endColor = Color.green;
		}
	}
}
