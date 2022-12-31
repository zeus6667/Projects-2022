using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doubletouch : MonoBehaviour
{
	private float ScreenWidth;
	float touchDuration;
	Touch touch;
   
	private void Start()
	{
		ScreenWidth = Screen.width;
	}
	void Update()
	{
		int i = 0;
		while (i <Input.touchCount)
		if (Input.GetTouch(i).position.x > ScreenWidth / 2)
		{ 
			if (Input.touchCount > 0)
			{ //if there is any touch
				touchDuration += Time.deltaTime;
				touch = Input.GetTouch(0);

				if (touch.phase == TouchPhase.Ended && touchDuration < 0.2f) //making sure it only check the touch once && it was a short touch/tap and not a dragging.
					StartCoroutine("singleOrDouble");
			}
			else
				touchDuration = 0.0f;
		}
		if (Input.GetTouch(i).position.x < ScreenWidth / 2)
		{
			if (Input.touchCount > 0)
			{ //if there is any touch
				touchDuration += Time.deltaTime;
				touch = Input.GetTouch(0);

				if (touch.phase == TouchPhase.Ended && touchDuration < 0.2f)
				{
					Debug.Log("koi to double tuch");
					//making sure it only check the touch once && it was a short touch/tap and not a dragging.
					StartCoroutine("singleOrDouble");
				}
			}
			else
				touchDuration = 0.0f;
		}
		
	}

	IEnumerator singleOrDouble()
	{
		yield return new WaitForSeconds(0.3f);
		if (touch.tapCount == 1)
			Debug.Log("Single");
		else if (touch.tapCount == 2)
		{
			//this coroutine has been called twice. We should stop the next one here otherwise we get two double tap
			StopCoroutine("singleOrDouble");
			Debug.Log("Double");
		}
	}
}
