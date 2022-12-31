using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnmatesCheck : MonoBehaviour
{
	public int length=7;
	public PortalAnim portal;
	public GameObject GameOverPanel;
	// Start is called before the first frame update
	void Start()
	{
	   portal = GameObject.Find("portal"). GetComponent<PortalAnim>();
	   
	}

	// Update is called once per frame
	void Update()
	{
		;
		if (length < portal.levelOpenCount)
		{
			GameOverPanel.SetActive(true);
			Time.timeScale = 0f;
		}
	}
}
