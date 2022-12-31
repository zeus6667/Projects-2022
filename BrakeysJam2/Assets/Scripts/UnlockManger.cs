using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnlockManger : MonoBehaviour
{
	public GameObject[] walls;
	public innMatesFollowAnim[] innMates;
	public Button[] unlockButtons;
	public int index;

	// Start is called before the first frame update
	void Start()
	{
		innMates = FindObjectsOfType<innMatesFollowAnim>();
	    
	}
	
}
