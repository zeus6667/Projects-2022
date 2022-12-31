using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu]
//[System.Serializable]

public class Inventory : ScriptableObject
{
	public Item currentItem;
	public List<Item> items = new List<Item>();
	public int numberOfKeys;
	public int coins1;
	public int coins2, coins3;
	public int matchedcoins;
	public int TotalCoins;
	public int highScore;
	public float maxMagic = 10;
	public float currentMagic;
	public int enemykillscore;
	//public void OnEnable()
	//{
	//	currentMagic =  maxMagic;
	//	coins1 = 0;
	//	coins2 = 0;
	//	coins3 = 0;
	//	matchedcoins = 0;
	//	enemykillscore = 0;

	//}
	//on
	//private void OnDisable()
	//{
		
	//	PlayerPrefs.Save();
	//	if (coins1 != 0 || coins2 != 0)
	//	{
	//		//inventory.TotalCoins += inventory.coins;

	//		matchedcoins += (coins1 + coins2);
	//		TotalCoins += matchedcoins;
	//	}
	//	if (coins3 != 0)
	//	{
	//		TotalCoins += coins3;

	//	}
		
	//	//TotalCoins += coins;
	//	PlayerPrefs.SetInt("TotalCoins", TotalCoins);
	//}
	//private void Awake()
	//{
	//	//saveplayer();
	//	PlayerPrefs.Save();
	//	if (coins1 != 0 || coins2 != 0)
	//	{
	//		//inventory.TotalCoins += inventory.coins;

	//		matchedcoins += (coins1 + coins2 + enemykillscore);
	//		TotalCoins += matchedcoins;
	//	}
	//	if (coins3 != 0)
	//	{
	//		TotalCoins += coins3 + enemykillscore;

	//	}
	//	PlayerPrefs.SetInt("TotalCoins", TotalCoins);
	//	//TotalCoins = PlayerPrefs.GetInt("TotalCoins");
	//}
	//public void Reducemagic(float magicCost)
	// {
	//	 currentMagic -= magicCost;
	// }
	// public bool ChecForItem(Item item)
	// {
	//	 if(items.Contains(item))
	//	 {
	//		 return true;
	//	 }
	//	 return false;
	// }

	//public void AddItem(Item itemToAdd)
	//{
	//	// is the item a key
	//	if(itemToAdd.isKey)
	//	{
	//		numberOfKeys++;
	//	}else
	//	{
	//		if(!items.Contains(itemToAdd))
	//		{
	//			items.Add(itemToAdd);
	//		}
	//	}
	//}
	//public void saveplayer()
	//{
	//	Debug.Log("saved");
	//	SaveData.SavePlayer(this);
	//}
	//public void loadplayer()
	//{
	//	playerData data = SaveData.LoadPlayer();

	//	TotalCoins = data.score;
	//}
	

}
