using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public Sound[] sound;
	public bool playing;
	public static AudioManager instance;
	// Start is called before the first frame update
	void Awake()
	{
	   
		playing = false;
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(instance);

			}

			else
			{
				Destroy(gameObject);
			}

	
		foreach (Sound s in sound)
		{
		   s.source = gameObject.AddComponent<AudioSource>();
		   s.source.clip = s.clip;

		   s.source.volume = s.volume;
		   s.source.pitch = s.pitch;
		   s.source.loop = s.loop;

		}
	}
	void Start()
	{
		
	}

   public void play(string name)
   {
	  Sound s = Array.Find(sound,sound => sound.name == name);
	  if(s == null)
	  {
		  
		  return;
	  }
	  s.source.Play();
   }
}
