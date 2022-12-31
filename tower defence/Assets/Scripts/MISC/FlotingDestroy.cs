using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlotingDestroy : MonoBehaviour
{
    public EnemyHealth healthamount;
    private float destroytime;
    public Vector3 offset = new Vector3 (0,-4,0);
    public Vector3 RandomizeIntensity = new Vector3(0.5f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        healthamount = GameObject.Find( "rockEnemy(Clone)").GetComponent<EnemyHealth>();
        destroytime = healthamount.healthAmount;
        Destroy(gameObject,destroytime);
        transform.localPosition += offset;
        transform.localPosition = new Vector3(Random.Range(-RandomizeIntensity.x,RandomizeIntensity.x),
            Random.Range(-RandomizeIntensity.y,RandomizeIntensity.y),
            Random.Range(-RandomizeIntensity.z,RandomizeIntensity.z));
    }
}
//"rockEnemy",
