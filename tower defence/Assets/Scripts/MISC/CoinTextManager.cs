using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
	public Inventory playerInventory;
	public TextMeshProUGUI coinDisplay;

	//private TextMeshProUGUI TotalcoinDisplay;
	private void Update()
	{
		updateCoinCount();

	}
	public void updateCoinCount()
   {
	   coinDisplay.text = "" + playerInventory.coins;
	  // TotalcoinDisplay.text = "" + playerInventory.TotalCoins;
	}
}
