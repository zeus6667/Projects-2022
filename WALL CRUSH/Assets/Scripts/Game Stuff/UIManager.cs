
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
	public Text DeathText;
	public Text powerText;
	public Text MagText;
	public Text HostageText;

	[HideInInspector]
	public float Kills;
	public float powers;
	public float mags;
	public float hostage;

	public static UIManager instance;
	// Start is called before the first frame update
	void Awake()
	{  if(instance == null)
		{
			instance = this;
		}else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		ShowKill();
		ShowPower();
		ShowMag();
		ShowHostage();
	}
	public void ShowKill()
	{
		DeathText.text = Kills.ToString(); 
	}
	public void ShowPower()
	{
		powerText.text = powers.ToString();
	}
	public void ShowMag()
	{
		MagText.text = mags.ToString();
	}
	public void ShowHostage()
	{
		HostageText.text = hostage.ToString();
	}
	public void AddKill()
	{
		Debug.Log("kill");
		Kills++;
	}
	public void AddPower()
	{
		powers++;
	}
	public void AddMag()
	{
		mags++;
	}
	public void AddHostage()
	{
		hostage++;
	}
	public void SubMag()
	{
		mags -= 1; 
	}
	public void SubPower()
	{
		powers -= 1; 
	}
	public void SubHostage()
	{
		hostage -= 1; 
	}
}
