
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SinglePlayerCountDown : MonoBehaviour
{
	public Text Countdown;
	public int countdounTime;
	public GameObject GameManager, spawnpoint;
	public SinglePlayerDistance singlePlayerDistance;
	public Camera MainCamera;
	public DestroyAsteroids asteroids;
	public Singleplayernbackground background;
	public Button pausebutton;
	void Start()
	{
		//if (Time.timeScale == 0)
		//{
		//	Time.timeScale = 1;
		//}
		background = GameObject.Find("BackGround").GetComponent<Singleplayernbackground>();
		asteroids = GameObject.Find("AsteroidSpawnner").GetComponent<DestroyAsteroids>();
		singlePlayerDistance = GameObject.Find("PlayerManager").GetComponent<SinglePlayerDistance>();
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
		GameManager.GetComponent<SingleplayerTimer>().enabled = true;
		GameManager.GetComponent<CamFollow>().enabled = true;
		MainCamera.GetComponent<SinglePlayerMover>().enabled = true;
		singlePlayerDistance.enabled = true;
		spawnpoint.SetActive(true);
		asteroids.enabled = true;
		background.enabled = true;
		pausebutton.interactable = true;
		yield return new WaitForSeconds(1);
		Countdown.gameObject.SetActive(false);
	}
	void playSound()
	{
		FindObjectOfType<AudioManager>().play("countDown");
	}
}

