using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinTextManager : MonoBehaviour
{
	public Inventory playerInventory;
	public TextMeshProUGUI coinDisplay;
	public TextMeshProUGUI coinDisplay1;

	//private TextMeshProUGUI TotalcoinDisplay;
	private void Update()
	{
		
		updateCoinCount();

	}
	public void updateCoinCount()
   {
	   coinDisplay.text = "" + playerInventory.coins1;
		coinDisplay1.text = "" + playerInventory.coins2;
		// TotalcoinDisplay.text = "" + playerInventory.TotalCoins;
	}
}
