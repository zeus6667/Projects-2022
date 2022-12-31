using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MusicTransition : MonoBehaviour
{
    private static MusicTransition instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }

        else
        {
            Destroy(gameObject);
        }

    }
    public void ToggleSound()
    {
        Debug.Log("hua");
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            //AudioListener.volume  = 1;
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            //AudioListener.volume = 0;
        }
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class SwapScenes : MonoBehaviour
//{
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//        }

//        if (SceneManager.GetActiveScene().name == "Level 3")
//            BGmusic.instance.GetComponent<AudioSource>().Pause();
//        //BGmusic.instance.GetComponent<AudioSource>().Play();

//    }
//}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BGmusic : MonoBehaviour
//{
//    public static BGmusic instance;

//    void Awake()
//    {
//        if (instance != null)
//            Destroy(gameObject);
//        else
//        {
//            instance = this;
//            DontDestroyOnLoad(this.gameObject);
//        }
//    }
//}