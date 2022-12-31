using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoaderfadeScreen : MonoBehaviour
{
	public Animator transition;
	public float transitionTime = 1f;
	public int no;
	// Update is called once per frame
	void Update()
	{
		
	}
	public void loadNextLevel()
	{
	   StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+no));
	}
	IEnumerator LoadLevel(int levelIndex)
	{
		transition.SetTrigger("Startfade");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(levelIndex);
	}
}
