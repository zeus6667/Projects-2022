using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
	public MainMenu menu;
	public unlocktry unlockable;
	public GameObject unlocpanel;
	public Button unlockButton;

	private string UnlockedPath;

	public Inventory inventory;
	public int requiredcoins;
	public int[] upgradeMagRequired;
	public int[] upgradeCoinRequired;
	public int[] upgradeBulletRequired;
	public TextMeshProUGUI requiredtext;
	public TextMeshProUGUI upgradeMagRequiredText;
	public TextMeshProUGUI upgradeCoinRequiredText;
	public TextMeshProUGUI upgradeBulletRequiredText;
	public GameObject[] lockPanel;
	public Characerselect characterselect;
	public int index;
	public int index1;
	public int index2;
	public int index3;
	public int magsize = 100;
	public int maxcoinAmount1 = 7;
	public int mincoinAmount1 = 2;
	public int maxBulletDamage = 10;
	public int minBulletDamage = 5;
	public Button MagsUpgradebutton;
	public Button CoinUpgradebutton;
	public Button BulletUpgradebutton;
	public bool Maxed = false;
	public bool Maxed1 = false;
	public bool Maxed2 = false;


	// Start is called before the first frame update
	void Start()
	{
		
		menu = GetComponent<MainMenu>();
		UnlockedPath = $"{Application.persistentDataPath}/unloced.json";

		if (File.Exists(UnlockedPath))
		{
			Debug.Log("File Exists");
			string json = File.ReadAllText(UnlockedPath);
			unlockable = JsonUtility.FromJson<unlocktry>(json);
			
		}
		RenderShop();
		index1 = PlayerPrefs.GetInt("index1");
		index2 = PlayerPrefs.GetInt("index2");
		index3 = PlayerPrefs.GetInt("index3");
		characterselect = GetComponent<Characerselect>();
		requiredtext.text = requiredcoins.ToString();
		upgradeMagRequiredText.text = upgradeMagRequired[index1].ToString();
		upgradeCoinRequiredText.text = upgradeCoinRequired[index2].ToString();
		upgradeBulletRequiredText.text = upgradeBulletRequired[index3].ToString();
		magsize = PlayerPrefs.GetInt("magsize");
		maxcoinAmount1 = PlayerPrefs.GetInt("maxcoinAmount1");
		mincoinAmount1 = PlayerPrefs.GetInt("mincoinAmount1");
		maxBulletDamage = PlayerPrefs.GetInt("maxBulletDamage");
		minBulletDamage = PlayerPrefs.GetInt("minBulletDamage");
		
	}

	// Update is called once per frame
	void Update()
	{
		index = characterselect.selectedCharacter;
		upgradeMagRequiredText.text = upgradeMagRequired[index1].ToString();
		upgradeCoinRequiredText.text = upgradeCoinRequired[index2].ToString();
		upgradeBulletRequiredText.text = upgradeBulletRequired[index3].ToString();
		if (menu.magSize == 1000)
		{
			Maxed = true;
			MagsUpgradebutton.interactable = false;
			upgradeMagRequiredText.text = ("Maxed");
		}
		if (menu.maxcoin == 157)
		{
			Maxed1 = true;
			CoinUpgradebutton.interactable = false;
			upgradeCoinRequiredText.text = ("Maxed");
		}
		if (menu.maxBullet == 30)
		{
			Maxed2 = true;
			BulletUpgradebutton.interactable = false;
			upgradeBulletRequiredText.text = ("Maxed");
		}
	}
	public void unlockkarrhehai()
	{
		if (inventory.TotalCoins >= requiredcoins)
		{
			unlockable.isunloced = true;
			RenderShop();
			SaveJson();
			inventory.TotalCoins -= requiredcoins;
		}
	}
	public void RenderShop()
	{
		if (!unlockable.isunloced)
		{
			lockPanel[index].SetActive(false);
			SaveJson();
		}
	}
	private void SaveJson()
	{
		Debug.Log("saved");
		string json = JsonUtility.ToJson(unlockable);
		File.WriteAllText(UnlockedPath, json);
	}
	public void StartGame()
	{
		PlayerPrefs.SetInt("selectedCharacter", index);
		SceneManager.LoadScene(1, LoadSceneMode.Single);
		inventory.coins = 0;
		FindObjectOfType<AudioManager>().play("ButtonClick");
	}
	public void MagSize()
	{
		if (inventory.TotalCoins > upgradeMagRequired[index1] && !Maxed)
		{
			FindObjectOfType<AudioManager>().play("Unlocksound");
		    magsize += 100;
			inventory.TotalCoins -= upgradeMagRequired[index1]; 
			index1++;
			Saved();
		}
	}
	public void coins()
	{
		if (inventory.TotalCoins > upgradeCoinRequired[index2] && !Maxed1)
		{
			FindObjectOfType<AudioManager>().play("Unlocksound");
			
			maxcoinAmount1 += 15;
			mincoinAmount1 += 8;
			inventory.TotalCoins -= upgradeCoinRequired[index2];
			index2++;
			Saved();
		}
	}
	public void BulletDamage()
	{
		if(inventory.TotalCoins > upgradeBulletRequired[index3] && !Maxed2)
		{
			FindObjectOfType<AudioManager>().play("Unlocksound");
			
			maxBulletDamage += 2;
			minBulletDamage += 2;
			inventory.TotalCoins -= upgradeBulletRequired[index3];
			index3++;
			Saved();
		}
	}
	public void Saved()
	{
		PlayerPrefs.SetInt("index1", index1);
		PlayerPrefs.SetInt("index2", index2);
		PlayerPrefs.SetInt("index3", index3);
		PlayerPrefs.SetInt("magsize", magsize);
		PlayerPrefs.SetInt("maxcoinAmount1",maxcoinAmount1);
		PlayerPrefs.SetInt("mincoinAmount1",mincoinAmount1);
		PlayerPrefs.SetInt("maxBulletDamage", maxBulletDamage);
	    PlayerPrefs.SetInt("minBulletDamage", minBulletDamage);
	}
	public void ResetData()
	{
		File.Delete(UnlockedPath);
		index1 = 0;
		index2 = 0;
		index3 = 0;
		magsize = 100;
		maxcoinAmount1 = 7;
		mincoinAmount1 = 2;
		maxBulletDamage = 10;
		minBulletDamage = 5;
		Maxed = false;
		Maxed1 = false;
		Maxed2 = false;
		BulletUpgradebutton.interactable = true;
		CoinUpgradebutton.interactable = true;
		MagsUpgradebutton.interactable = true;
		inventory.coins = 0;
		inventory.TotalCoins = 0;
		Saved();
	}
}


   