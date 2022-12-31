using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ShopSystem : MonoBehaviour
{
	public Inventory playerinventory;
	bool upgraded = false;
	[Header("Player Health")]
	public TextMeshProUGUI upgradedhealthtext;
	private float basehealthvalue = 100;
	public Health healthPlayer;
	private int upgradeCoinValue = 1000;
	private float healthUpgardevalue = 10;
	public float Playerhealth;
	private int upgradeAmount = 1000;
	public TextMeshProUGUI upgradetext;
	private float maxUpgardeValue = 200;
	public Button healthbutton;
	public int healthupgradebasevalue=1000;

	[Header("Gun Damage")]
	public TextMeshProUGUI upgradedguntext;
	private int basegunValue = 8 ;
	public enemyhealth playergunDamage;
	private int gunupgradeCoinValue = 2000;
	private int gunupgradevalue = 2;
	public int gunDamage;
	private float GunmaxUpgardeValue = 20;
	public TextMeshProUGUI guntext;
	private int gunupgradeAmount = 2000;
	public Button gunUpgardebutton;
	public int gunupgradebasevalue = 2000;
	// Start is called before the first frame update
	void Start()
	{
		
		if (upgraded == false)
		{
			PlayerPrefs.SetFloat("health", basehealthvalue);
			PlayerPrefs.SetInt("GunDamage", basegunValue);
			upgradeCoinValue = healthupgradebasevalue;
			PlayerPrefs.SetInt("reqcoin", upgradeCoinValue);
			gunupgradeCoinValue = gunupgradebasevalue;
			PlayerPrefs.SetInt("gunreqcoin", gunupgradeCoinValue);
		}
		Playerhealth = PlayerPrefs.GetFloat("health");
		upgradedhealthtext.text = Playerhealth.ToString();
		
		upgradeCoinValue = PlayerPrefs.GetInt("reqcoin");
		upgradetext.text = upgradeCoinValue.ToString();
		if (Playerhealth < basehealthvalue)
		{
			Playerhealth = basehealthvalue;
		}

		gunDamage = playergunDamage.damage;
		gunDamage = PlayerPrefs.GetInt("GunDamage");
		upgradedguntext.text = gunDamage.ToString();
		gunupgradeCoinValue =PlayerPrefs.GetInt("gunreqcoin");
		guntext.text = gunupgradeCoinValue.ToString();

		if (gunDamage < basegunValue)
		{
			gunDamage = basegunValue;
		}
		
	}

	// Update is called once per frame
	void Update()
	{
		Playerhealth = PlayerPrefs.GetFloat("health");
		gunDamage = PlayerPrefs.GetInt("GunDamage");
		upgradetext.text = upgradeCoinValue.ToString();
		guntext.text = gunupgradeCoinValue.ToString();
		if (Playerhealth == maxUpgardeValue)
		{
			//Debug.Log("maxed");
			upgradetext.text = "MAXED";
			healthbutton.interactable = false;
		}
		if (gunDamage == GunmaxUpgardeValue)
		{
			//Debug.Log("maxed");
			guntext.text = "MAXED";
			gunUpgardebutton.interactable = false;
		}
		upgradedhealthtext.text = Playerhealth.ToString();
		upgradedguntext.text = gunDamage.ToString();
	}
	public void healthupgarde()
	{
		
		if (playerinventory.TotalCoins >= upgradeCoinValue && Playerhealth < maxUpgardeValue)
		{
			upgraded = true;
			FindObjectOfType<AudioManager>().play("upgrade");
			Playerhealth += healthUpgardevalue;
			PlayerPrefs.SetFloat("health", Playerhealth);
			playerinventory.TotalCoins -= upgradeCoinValue;
			upgradeCoinValue += upgradeAmount;
			PlayerPrefs.SetInt("reqcoin",upgradeCoinValue);
			PlayerPrefs.SetInt("TotalCoins",playerinventory.TotalCoins);
			upgradetext.text = upgradeCoinValue.ToString();
		}
		
		
	}
	public void bulletPowerUpgarde()
	{
		if (playerinventory.TotalCoins >= gunupgradeCoinValue && gunDamage < GunmaxUpgardeValue)
		{
			upgraded = true;
			FindObjectOfType<AudioManager>().play("upgrade");
			gunDamage += gunupgradevalue;
			PlayerPrefs.SetInt("GunDamage", gunDamage);
			playerinventory.TotalCoins -= gunupgradeCoinValue;
			gunupgradeCoinValue += gunupgradeAmount;
			PlayerPrefs.SetInt("gunreqcoin", gunupgradeCoinValue);
			PlayerPrefs.SetInt("TotalCoins", playerinventory.TotalCoins);
			guntext.text = gunupgradeCoinValue.ToString();
		}
		
	}
	public void Reset()
	{
		if (upgraded == true)
		{
			PlayerPrefs.SetFloat("health", basehealthvalue);
			PlayerPrefs.SetInt("GunDamage", basegunValue);
			upgradeCoinValue = healthupgradebasevalue;
			PlayerPrefs.SetInt("reqcoin", upgradeCoinValue);
			gunupgradeCoinValue = gunupgradebasevalue;
			PlayerPrefs.SetInt("gunreqcoin", gunupgradeCoinValue);
			guntext.text = gunupgradeCoinValue.ToString();
			upgradetext.text = upgradeCoinValue.ToString();
			upgradedhealthtext.text = Playerhealth.ToString();
			upgradedguntext.text = gunDamage.ToString();
			if (healthbutton.interactable == false || gunUpgardebutton.interactable == false)
			{
				healthbutton.interactable = true;
				gunUpgardebutton.interactable = true;
				guntext.text = gunupgradeCoinValue.ToString();
				upgradetext.text = upgradeCoinValue.ToString();
			}
		}
	}
}
