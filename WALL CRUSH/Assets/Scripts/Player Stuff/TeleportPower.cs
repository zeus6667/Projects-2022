using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPower : MonoBehaviour
{
	private int xPos;
	private int zPos;
	private GameObject player;
	

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update()
	{
		MyImput();
	}
	private void MyImput()
	{
		if (Input.GetKeyDown(KeyCode.E) && UIManager.instance.powers != 0)
		{
			xPos = Random.Range(90, -90);
			zPos = Random.Range(90, -90);
			player.transform.position =  new Vector3(xPos, 0, zPos);
			UIManager.instance.SubPower();
			FindObjectOfType<AudioManager>().play("teleport");
		}
	}

   
}
