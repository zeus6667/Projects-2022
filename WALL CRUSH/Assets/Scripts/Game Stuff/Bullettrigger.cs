
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullettrigger : MonoBehaviour
{
	private Projectilegun player;
	public int maxmag;
	[HideInInspector]
	public LevelGoals levelGoals;


	// Start is called before the first frame update
	void Start()
	{
		levelGoals = GameObject.Find("LevelGoal").GetComponent<LevelGoals>();
		player = GameObject.Find("Player").GetComponent<Projectilegun>();
		maxmag = levelGoals.magsreq;
	}
	void Update()
	{

	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && UIManager.instance.mags < maxmag)
		{
			UIManager.instance.AddMag();
			UIManager.instance.ShowMag();
			Destroy(this.gameObject);

		}
	}
}