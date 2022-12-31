using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class screenorientation : MonoBehaviour
{
	private void Start()
	{
		if (Application.isMobilePlatform == true)
		{
			if (SceneManager.GetActiveScene().name == "SinglePlayer")
			{
				Screen.orientation = ScreenOrientation.Portrait;
			}
			else
			{
				Screen.orientation = ScreenOrientation.LandscapeLeft;
			}
		}




		//if (landscape == true)
		//{
		//	Screen.orientation = ScreenOrientation.LandscapeRight;
		//}
		//else
		//{
		//	Screen.orientation = ScreenOrientation.Portrait;
		//}

	}
}
