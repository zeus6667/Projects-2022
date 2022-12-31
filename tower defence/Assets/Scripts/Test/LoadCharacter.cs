
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadCharacter : MonoBehaviour
{
	public Quaternion startQuaternion;
	public float lerpTime = 1;
	public bool rotate;
	public GameObject myplayer;

	public GameObject[] characterPrefabs;
	public int selectedCharacter;
	public Transform spawnPoint;
   // public TMP_Text label;
   void Start()
   {
		snapRotation();
		startQuaternion = transform.rotation;
		loadCharacter();
		
	 //label.text = prefab.name;
	}

	public void loadCharacter()
	{
		
		selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
		GameObject prefab = characterPrefabs[selectedCharacter];
		GameObject clone = Instantiate(prefab, spawnPoint.position, startQuaternion,spawnPoint.transform);
	}
	private void Update()
	{
		if (rotate)
		{
			transform.rotation = Quaternion.Lerp(transform.rotation, startQuaternion, Time.deltaTime * lerpTime);
		}
	}
	public void snapRotation()
	{
		transform.rotation = startQuaternion;
	}
	
}

//// Storeaboolean into PlayerPrefs
//PlayerPrefs.SetInt("NameOfBool", (yourBool ? 1 : 0));
//// EXPLANATION
//int value;
//value = yourBool ? 1 : 0;
//// it's like writing:
//if (yourBool true)
//{
//	value = 1;
//else
//		value = 0;
//	// Access the boolean
//	yourBool(PlayerPrefs.GetInt("NameOfBool") != 0); H

