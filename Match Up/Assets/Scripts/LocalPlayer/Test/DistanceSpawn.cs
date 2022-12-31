using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSpawn : MonoBehaviour
{
    public GameObject[] Traps;
    public Transform spawnPos;
    public int index;
    public Vector3 DeltaPosition = 10 * Vector3.up;
    private int instancesCount = 0;
    public float spawnTime, spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandom", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
      
        //if (Input.GetMouseButtonDown(0))  // 0 is left mouse button
        //{
        //    SpawnRandom();
        //}
    }
    void SpawnRandom()
    {
        index = Random.Range(0, Traps.Length);
        Vector3 position = spawnPos.position + DeltaPosition * instancesCount++;
        Instantiate(Traps[index], position, spawnPos.rotation);
    }
}

