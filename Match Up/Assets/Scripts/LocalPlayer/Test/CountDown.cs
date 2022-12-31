using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountDown : MonoBehaviour
{
	public Text Countdown;
	public int countdounTime;
	public GameObject GameManager, spawnpoint;
	public DistanceScore playerManager;
	public Camera MainCamera;
	public DestroyAsteroids asteroids;
	public BackGround background;
	public Button pausebuttonm;
	void Start()
	{
		
		//if (Time.timeScale == 0)
		//{
		//	Time.timeScale = 1;
		//}
		background = GameObject.Find("BackGround").GetComponent<BackGround>();
		asteroids = GameObject.Find("AsteroidSpawnner").GetComponent<DestroyAsteroids>();
		playerManager = GameObject.Find("PlayerManager").GetComponent<DistanceScore>();
		GameManager = GameObject.Find("GameManager");
		//StartCoroutine("CountDownRoutine");
	}
	IEnumerator CountDownRoutine()
	{
		//Debug.Log("dfsr");
		while (countdounTime > 0)
		{
			Countdown.text = countdounTime.ToString();

			yield return new WaitForSeconds(1);
			playSound();
			countdounTime--;
		}
		Countdown.text = "GO!!";
		yield return new WaitForSeconds(0.5f);
		//startGameHere
		GameManager.GetComponent<Timer>().enabled = true;
		GameManager.GetComponent<CamFollow>().enabled = true;
		MainCamera.GetComponent<Move1moreplayer>().enabled = true;
		spawnpoint.SetActive(true);
		playerManager.enabled = true;
		asteroids.enabled = true;
		background.enabled = true;
		pausebuttonm.interactable = true;
		yield return new WaitForSeconds(1);
		Countdown.gameObject.SetActive(false);
	}
	void playSound()
	{
		FindObjectOfType<AudioManager>().play("countDown");
	}

}

