using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public float Camspeed;
 
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f,Camspeed * Time.deltaTime,0f);
    }
}
