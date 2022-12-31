using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Coin : PowerUp
{

	public Inventory playerInventory;
	//public Collider colliderOfCoin;
	public int coinAmount;
	public int MaxcoinAmount;
	public int MincoinAmount;


	public Transform objTrans;
	private float delay = 0;
	private float pasttime = 0;
	private float when = 1.0f;
	private Vector3 off;

	[Header("Magnet")]
	public Rigidbody rig;
	public GameObject player;
	private bool magnetize = false;
	public bool hascoinAmount;
	// Start is called before the first frame update
	void Start()
	{
		powerUpSignal.Raise();
		rig = GetComponent<Rigidbody>();
		player = GameObject.Find("Trackertraget");
		//player = transform.GetChild(3).gameObject;
		if (player)
		{
			//player = GameObject.FindWithTag("Player");
			StartCoroutine(Magnet());
		}
		MaxcoinAmount = PlayerPrefs.GetInt("maxcoinAmount1");
		MincoinAmount = PlayerPrefs.GetInt("mincoinAmount1");
		coinAmount = Random.Range(MincoinAmount,MaxcoinAmount);	
		//InvokeRepeating("CoinAmount", 2, 2);
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
			//colliderOfCoin.enabled = false;
			playerInventory.coins += coinAmount;
			powerUpSignal.Raise();
			//Destroy(this.gameObject);
			StartCoroutine(DestroyObject());
		}
	}
	IEnumerator DestroyObject()
	{
		yield return new WaitForSeconds(1.2f);
		Destroy(this.gameObject);
	}
	public void CoinAmount()
	{
		coinAmount = Random.Range(MincoinAmount,MaxcoinAmount);
	}
}




