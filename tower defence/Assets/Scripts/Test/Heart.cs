

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Heart : PowerUp
{

	public Inventory playerInventory;
	public PlayerHealth playerHealth;
	//public Collider colliderOfCoin;
	

	public Transform objTrans;
	private float delay = 0;
	private float pasttime = 0;
	private float when = 1.0f;
	private Vector3 off;

	[Header("Magnet")]
	public Rigidbody rig;
	public GameObject player;
	private bool magnetize = false;
	
	// Start is called before the first frame update
	void Start()
	{
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
		powerUpSignal.Raise();
		rig = GetComponent<Rigidbody>();
		player = GameObject.Find("Trackertraget");
		//player = transform.GetChild(3).gameObject;
		if (player)
		{
			//player = GameObject.FindWithTag("Player");
			StartCoroutine(Magnet());
		}
	}
	private void Awake()
	{
		off = new Vector3(Random.Range(-3, 3), off.y, off.z);
		off = new Vector3(off.x, Random.Range(-3, 3), off.z);
		off = new Vector3(off.x, off.y, Random.Range(-3, 3));
	}
	// Update is called once per frame
	void Update()
	{
		if (when >= delay)
		{
			pasttime = Time.deltaTime;
			// position of coin
			objTrans.position += off * Time.deltaTime;
			delay += pasttime;
		}
		if (magnetize && player != null)
		{
			Vector3 playerPoint = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, -0.3f, 0), 250 * Time.deltaTime);
			rig.MovePosition(playerPoint);
		}


	}
	private IEnumerator Magnet()
	{
		
		yield return new WaitForSeconds(0.1f);
		magnetize = true;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (playerHealth.currentHealth == playerHealth.maxhealth)
			{
				Debug.Log("heartkhatam");
				StartCoroutine(DestroyObject());
			}
			else
			{
				Debug.Log("heartAdded");
				playerHealth.ModifyHealth(-10);
				powerUpSignal.Raise();
				StartCoroutine(DestroyObject());
			}
			
		}
	}
	IEnumerator DestroyObject()
	{
		yield return new WaitForSeconds(1.2f);
		Destroy(this.gameObject);
	}
	
}

