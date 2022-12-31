using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplode : MonoBehaviour
{
	public GameObject explosion;
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Rock"))
		{
			
			Explode();
			
		}
	}
	public void Explode()
	{
		if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
		Debug.Log("phuta bhai ");
	}
}
