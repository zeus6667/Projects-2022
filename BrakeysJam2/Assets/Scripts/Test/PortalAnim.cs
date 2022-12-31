using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalAnim : MonoBehaviour
{
	
	public BoxCollider2D box;
	public Inventory PlayerInventory;
	public int innMatesCount, levelOpenCount;
	public Animator anim;
	bool once;
	public string Scenename;
	// Start is called before the first frame update
	void Start()
	{
		
		once = false;
		anim = this.gameObject.GetComponent<Animator>();
	   box =  this.gameObject.GetComponent<BoxCollider2D>();
	   box.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		innMatesCount = PlayerInventory.innametsCount;
		AnimTry();
	}
	public void AnimTry()
	{
		if (innMatesCount >= levelOpenCount)
		{
			anim.SetTrigger("OpenTrue");
			box.enabled = true;
		}
		else if(levelOpenCount < innMatesCount)
		{
			anim.ResetTrigger("OpenTrue");
			box.enabled = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && !once)
		{
			once = true;
			FindObjectOfType<AudioManager>().play("portal");
			SceneManager.LoadScene(Scenename);
		}
	}
}
