using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        timescale();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void timescale()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
