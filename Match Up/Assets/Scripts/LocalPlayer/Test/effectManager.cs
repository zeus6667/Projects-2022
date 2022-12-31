using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class effectManager : MonoBehaviour
{
	public ParticleSystem[] effects;
	public static effectManager instance;
	public GameObject floatingTextPrefab;
	// Start is called before the first frame update
	void Start()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	//public void play(string name)
	//{
	//	Particleeffects s = Array.Find(effects, effects => effects.name == name);
	//	if (s == null)
	//	{

	//		return;
	//	}
	//	s.source.Play();
	//}
}
