using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;
    public float snapos;

    void Start()
    {
        StartPosition = transform.position;
    }

    //update is called once per frame

    void Update()
    {
        transform.Translate( Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < snapos)
        {
            transform.position = StartPosition;
        }
    }
}
