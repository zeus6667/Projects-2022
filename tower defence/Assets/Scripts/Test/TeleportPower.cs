using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPower : MonoBehaviour
{
	private int xPos;
	private int zPos;
	private int yPos;
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
		if (Input.GetKeyDown(KeyCode.E) /*&& UIManager.instance.powers != 0*/)
		{
			if (yPos > 1)
			{
				Debug.Log("Teleported");
				xPos = Random.Range(60, -50);
				zPos = Random.Range(12, 15);
				yPos = 0;
				player.transform.position = new Vector3(xPos,yPos, zPos);
			}
			else
			{
				Debug.Log("Teleported");
				xPos = Random.Range(55, -45);
				zPos = Random.Range(2, -2);
				yPos=12;
				player.transform.position = new Vector3(xPos,yPos,zPos);
			}
		
			//UIManager.instance.SubPower();
			FindObjectOfType<AudioManager>().play("Teleport");
		}
	}

   
}
