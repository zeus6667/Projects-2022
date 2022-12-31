using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
	public MusicTransition music;
	public Button musicToggleButton;
	public Sprite musicOnSprite;
	public Sprite musicOffSprite;

	private void Start()
	{
		music = GameObject.FindObjectOfType<MusicTransition>();
		UpdateIcon();
	}
	public void PauseMusic()
	{
		music.ToggleSound();
		UpdateIcon();
	}
	void UpdateIcon()
	{
		if (PlayerPrefs.GetInt("Muted", 0) == 0)
		{
			AudioListener.volume = 1;
			musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
		}
		else
		{
			AudioListener.volume = 0;
			musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
		}
	}
}







//[SerializeField] Slider volume;
//Start is called before the first frame update
//void Start()
//{

//	if (!PlayerPrefs.HasKey("musicVolume")) ;
//	{
//		PlayerPrefs.SetFloat("musicVolume", 1);
//		Load();
//	}
//}

//public void ChangeVolume()
//{
//	AudioListener.volume = volume.value;
//	Save();
//}
//private void Load()
//{
//	volume.value = PlayerPrefs.GetFloat("musicVolume");
//}
//private void Save()
//{
//	PlayerPrefs.SetFloat("musicVolume", volume.value);
//}