using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTry : MonoBehaviour
{
	public Health Player1;
	public Health1 Player2;
	public int powerTime = 5;
	Renderer rend1;
	Renderer rend2;
	Color c1;
	Color c2;
	SpriteRenderer sprite;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(this.gameObject, 20);
		Player1 = GameObject.Find("Player1").GetComponent<Health>();
		Player2 = GameObject.Find("Player2").GetComponent<Health1>();
		rend1 = Player1.GetComponent<Renderer>();
		rend2 = Player2.GetComponent<Renderer>();
		c1 = rend1.material.color;
		c2 = rend2.material.color;
		sprite = this.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.CompareTag("Player1"))
		{
			sprite.enabled = false;
			
			StartCoroutine(invisible());
		}
		if (collision.CompareTag("Player2"))
		{
			sprite.enabled = false;
		
			StartCoroutine(invisible1());
		}
	}
	IEnumerator invisible()
	{
		Player1.isInvisible = true;
		//Player1.enabled = false;
		c1.a = 0.5f;
		rend1.material.color = c1;

		yield return new WaitForSeconds(powerTime);
		//Debug.Log("Player1hai bhai");
		Player1.isInvisible = false;
		//Player1.enabled = true;
		c1.a = 1f;
		rend1.material.color = c1;
		Destroy(this.gameObject);
	}
	IEnumerator invisible1()
	{
		Player2.isInvisible = true;
		//Player2.enabled = false;
		c2.a = 0.5f;
		rend2.material.color = c2;
		yield return new WaitForSeconds(powerTime);
		//Debug.Log("Player2hai bhai");
		Player2.isInvisible = false;
		//Player2.enabled = true;
		c2.a = 1f;
		rend2.material.color = c2;
		Destroy(this.gameObject);
	}
	
}
