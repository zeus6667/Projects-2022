//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class unlocktry : MonoBehaviour
//{
//	public Inventory inventory;
//	public int requiredcoins;
//	public TextMeshProUGUI requiredtext;
//	public GameObject[] lockPanel;
//	public Characerselect characterselect;
//	public int index;
//	public bool unlocked;
//	// Start is called before the first frame update
//	void Start()
//	{
//		characterselect = GetComponent<Characerselect>();

//		requiredtext.text = requiredcoins.ToString();
//		if (unlocked)
//		{
//			lockPanel[index].SetActive(false);
//		}
//	}

//	// Update is called once per frame
//	void Update()
//	{
//		unlocked = characterselect.isunlocked;

//		index = characterselect.selectedCharacter;

//	}

//	public void unlock()
//	{
//		if (inventory.TotalCoins >= requiredcoins || unlocked)
//		{

//			//PlayerPrefs.SetInt("unlocked", (unlocked ? 1 : 0));
//			unlocked = (PlayerPrefs.GetInt("isunlocked") != 0);
//			PlayerPrefs.GetInt("selectedCharacter");
//			lockPanel[index].SetActive(false);
//			characterselect.isunlocked = true;			
//			inventory.TotalCoins -= requiredcoins;
//		}
//	}

//}
[System.Serializable]
public class unlocktry 
{
	public bool isunloced  = false;
}