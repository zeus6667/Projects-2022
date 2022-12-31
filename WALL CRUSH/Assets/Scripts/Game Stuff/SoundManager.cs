using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] Slider volume;
    // Start is called before the first frame update
    void Start()
    {
      
        if(!PlayerPrefs.HasKey("musicVolume"));
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volume.value;
        Save();
    }
    private void Load()
    {
        volume.value =  PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",volume.value);
    }
}

