
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleplayerinvisible : MonoBehaviour
{
	public Health Player1;
	public int powerTime = 5;
	Renderer rend1;
	Color c1;
	SpriteRenderer sprite;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(this.gameObject, 20);
		Player1 = GameObject.Find("Player1").GetComponent<Health>();
		rend1 = Player1.GetComponent<Renderer>();
		c1 = rend1.material.color;
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
		//if (collision.CompareTag("boder"))
		//{
		//	//Debug.Log(":>");
		//	Destroy(this.gameObject);
		//}

	}
	IEnumerator invisible()
	{
		Player1.isInvisible = true;
		//Player1.enabled = false;
		c1.a = 0.5f;
		rend1.material.color = c1;
		yield return new WaitForSeconds(powerTime);
		Debug.Log("Player1hai bhai");
		Player1.isInvisible = false;
		//Player1.enabled = true;
		c1.a = 1f;
		rend1.material.color = c1;
		Destroy(this.gameObject);
	}
	
}
