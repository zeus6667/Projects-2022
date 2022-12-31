using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
	public Health player1Health;
	public Health1 player2Health;
	public float damagerate;
	public Boolienhai Matched;
	public ParticleSystem  clashEffect;
	public effectManager effectManager;
	// Start is called before the first frame update
	void Start()
	{
		effectManager = GameObject.Find("effectManager").GetComponent<effectManager>();
		clashEffect = effectManager.effects[2];

	}
	private void Update()
	{
		Matched = GameObject.Find("GameManager").GetComponent<Boolienhai>();
		if (Matched.Matched == false)
		{
			player1Health = GameObject.Find("Player1").GetComponent<Health>();
			player2Health = GameObject.Find("Player2").GetComponent<Health1>();
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
	//	Debug.Log("destroy11");
		if (collision.tag == "boder")
		{
			//Debug.Log(":>");
			Destroy(this.gameObject);
		}
		if (collision.CompareTag ("Player1") && Matched.Matched == false && player1Health.isInvisible == false)
		{
			player1Health.Damage(damagerate);
			Instantiate(clashEffect, transform.position, Quaternion.identity);
		}
		if (collision.CompareTag("Player2") && Matched.Matched == false && player2Health.isInvisible == false)
		{
			player2Health.Damage(damagerate);
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
