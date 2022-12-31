using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
   /* public int noOfEnemies;
    public GameObject[] leftenemies;*/
    // Start is called before the first frame update
   
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("enemy");
        if (totalEnemies.Length == 0  )
        {
            SceneManager.LoadScene("closingCutScene");
        }
    }
}
