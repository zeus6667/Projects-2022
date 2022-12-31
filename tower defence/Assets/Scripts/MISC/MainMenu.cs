using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
	public int magSize  = 100;
	public int maxcoin = 7;
	public int mincoin = 2;
	public int maxBullet = 10;
	public int minBullet = 5;

	private void Start()
	{
		magSize = PlayerPrefs.GetInt("magsize");
		maxcoin = PlayerPrefs.GetInt("maxcoinAmount1");
		mincoin = PlayerPrefs.GetInt("mincoinAmount1");
		maxBullet = PlayerPrefs.GetInt("maxBulletDamage");
		minBullet = PlayerPrefs.GetInt("minBulletDamage");
	}
	public void Update()
	{
		magSize = PlayerPrefs.GetInt("magsize");
		maxcoin = PlayerPrefs.GetInt("maxcoinAmount1");
		mincoin = PlayerPrefs.GetInt("mincoinAmount1");
		maxBullet = PlayerPrefs.GetInt("maxBulletDamage");
		minBullet = PlayerPrefs.GetInt("minBulletDamage");
		PlayerPrefs.Save();
	}
	public void PlayGame()
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
	}
   public void QuitGame()
   {
	   Application.Quit();
   }
	public void Back()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
