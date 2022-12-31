using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]

public class Inventory : ScriptableObject
{
	public Item currentItem;
	public List<Item> items = new List<Item>();
	public int numberOfKeys;
	public int coins;
	public int matchedcoins;
	public int TotalCoins;
	public float maxMagic = 10;
	public float currentMagic;
	public int enemykillscore;
	public int innametsCount;


	
	public void OnEnable()
	{
		currentMagic = maxMagic;
		coins = 0;
	}
	private void OnDisable()
	{
		if (coins != 0)
		{
			TotalCoins += coins;

		}
		//TotalCoins += coins;
		//PlayerPrefs.SetInt("TotalCoins", TotalCoins);
	}
	private void Awake()
	{
		
		if (coins != 0)
		{
			TotalCoins += coins + enemykillscore;

		}
		//TotalCoins = PlayerPrefs.GetInt("TotalCoins");
	}
	
	public void Reducemagic(float magicCost)
	{
		currentMagic -= magicCost;
	}
	public bool ChecForItem(Item item)
	{
		if (items.Contains(item))
		{
			return true;
		}
		return false;
	}

	public void AddItem(Item itemToAdd)
	{
		// is the item a key
		if (itemToAdd.isKey)
		{
			numberOfKeys++;
		}
		else
		{
			if (!items.Contains(itemToAdd))
			{
				items.Add(itemToAdd);
			}
		}
	}
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu]
//[System.Serializable]
//public class Inventory : ScriptableObject
//{
//	public Item currentItem;
//	public List<Item> items = new List<Item>();
//	public int numberOfKeys;
//	public int coins;
//	public float maxMagic = 10;
//	public float currentMagic;

//	public void OnEnable()
//	{
//		currentMagic = maxMagic;

//	}
//	public void Reducemagic(float magicCost)
//	{
//		currentMagic -= magicCost;
//	}
//	public bool ChecForItem(Item item)
//	{
//		if (items.Contains(item))
//		{
//			return true;
//		}
//		return false;
//	}

//	public void AddItem(Item itemToAdd)
//	{
//		// is the item a key
//		if (itemToAdd.isKey)
//		{
//			numberOfKeys++;
//		}
//		else
//		{
//			if (!items.Contains(itemToAdd))
//			{
//				items.Add(itemToAdd);
//			}
//		}
//	}
//}