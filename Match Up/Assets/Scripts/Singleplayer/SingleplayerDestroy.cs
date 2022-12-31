
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleplayerDestroy : MonoBehaviour
{
	public Health player1Health;

	public float damagerate;
	public ParticleSystem clashEffect;
	public effectManager effectManager;
	// Start is called before the first frame update
	void Start()
	{
		player1Health = GameObject.Find("Player1").GetComponent<Health>();
		effectManager = GameObject.Find("effectManager").GetComponent<effectManager>();
		clashEffect = effectManager.effects[2];
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		//	Debug.Log("destroy11");
		if (collision.tag == "boder")
		{
			//Debug.Log(":>");
			Destroy(this.gameObject);
		}
		if (collision.CompareTag("Player1") && player1Health.isInvisible == false)
		{
			player1Health.Damage(damagerate);
			Instantiate(clashEffect, transform.position, Quaternion.identity);
		}
	}

}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class destroy : MonoBehaviour
//{
//    private Vector2 screenBounds;
//    // Start is called before the first frame update
//    void Start()
//    {

//        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (transform.position.y < -screenBounds.y * 2)
//        {
//            Destroy(this.gameObject);
//        }
//    }

//}
