using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float ti;
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,ti);
    }
}
