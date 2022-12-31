using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float timeStart;
	public TextMeshProUGUI textBox;
   

	bool timerActive = false;

	// Use this for initialization
	void Start()
	{
		//textBox.text = timeStart.ToString("F2");
		timerActive = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (timerActive)
		{
			timeStart += Time.deltaTime;
			//textBox.text = timeStart.ToString("F2");
			DisplayTime();
		}
	}
	public void timerStop()
	{
		timerActive = !timerActive;
	}
	public void DisplayTime()
	{
		int minutes = Mathf.FloorToInt(timeStart / 60);
		int seconds = Mathf.FloorToInt(timeStart - minutes * 60);
		textBox.text = string.Format("{0:00}:{1:00}", minutes, seconds);    
	}
	public void Reset()
	{
		timeStart = 0.0f;
	}
}