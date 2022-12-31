using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
	//private Text powerCount;

	public void Start()
	{
		//powerCount = GameObject.Find("powerText").GetComponent<Text>();
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !other.isTrigger)
		{
			//if player collides with power increase Ui counter
			UIManager.instance.AddPower();
			UIManager.instance.ShowPower();
			Destroy(this.gameObject);
			// death count ++
		}
	}


}
