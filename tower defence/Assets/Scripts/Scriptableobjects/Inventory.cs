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
	public int TotalCoins;
	public float maxMagic = 10;
	public float currentMagic;

	public void OnEnable()
	{
		currentMagic =  maxMagic;
		coins = 0;  
	}
	//private void OnDisable()
	//{
	//	TotalCoins += coins;
	//	//PlayerPrefs.SetInt("TotalCoins", TotalCoins);
	//}
	private void Awake()
	{
		//TotalCoins = PlayerPrefs.GetInt("TotalCoins");
	}
	public void Reducemagic(float magicCost)
	 {
		 currentMagic -= magicCost;
	 }
	 public bool ChecForItem(Item item)
	 {
		 if(items.Contains(item))
		 {
			 return true;
		 }
		 return false;
	 }

	public void AddItem(Item itemToAdd)
	{
		// is the item a key
		if(itemToAdd.isKey)
		{
			numberOfKeys++;
		}else
		{
			if(!items.Contains(itemToAdd))
			{
				items.Add(itemToAdd);
			}
		}
	}
}
