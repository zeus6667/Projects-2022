using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private PlayerHealth life;

    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<PlayerHealth>(); 
    }

 
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && life.currentHealth != life.maxhealth)
        {
            life.ModifyHealth(-10);
           Destroy(gameObject);
        }
    }
}
