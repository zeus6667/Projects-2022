using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGoals : MonoBehaviour
{
	public int killsReq;
	public int magsreq;
	public int magicReq;
	public int hostagereq;
	public Text magicreqtext;
	public Text hostagereqtext;
	public Text killreqtext;
	public Text magsreqText;


	public Text magicreqtext1;
	public Text hostagereqtext1;
	public Text killreqtext1;
	public Text magsreqText1;


	public bool isgoal;
	public bool isgoalComplete = false;
	public GameObject GoalPanel;
	
	// Start is called before the first frame update
	void Start()
	{
		isgoal = false;
		goal();
		magicreqtext1.text = " / "+ magicReq.ToString(); 
		killreqtext1.text = " /"+ killsReq.ToString(); 
		hostagereqtext1.text = " / "+ hostagereq.ToString(); 
		magsreqText1.text = " / "+ magsreq.ToString(); 
	}
	// Update is called once per frame
	void Update()
	{
		if (UIManager.instance.Kills >= killsReq && UIManager.instance.powers >= magicReq && UIManager.instance.mags >= magicReq && UIManager.instance.hostage >= hostagereq)
		{
			isgoalComplete = true;
		}
	}
	public void goal()
	{
		isgoal = !isgoal;
		if (isgoal)
		{
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0f;
			GoalPanel.SetActive(true);
			killreqtext.text = killsReq.ToString();
			magsreqText.text = magsreq.ToString();
			hostagereqtext.text = hostagereq.ToString();
			magicreqtext.text = magicReq.ToString();
		}
	}
	public void StartGAme()
	{
		 Cursor.lockState = CursorLockMode.Locked;
	     Time.timeScale = 1f;
		 GoalPanel.SetActive(false);
		 isgoal = false;
	}
}
