//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class innMatesFollowAnim : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
		
//    }

//    // Update is called once per frame
//    void Update()
//    {
		
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innMatesFollowAnim : Enemy
{
	public Rigidbody2D myRigidbody;

	[Header("Target Variable")]
	public Transform target;
	public float chaseRadius;
	public float attackRadius;

	public bool follow;
	[Header("animator")]
	public Animator anim;
	public bool Unfollow;
	// Start is called before the first frame update
	void Start()
	{
		follow = false;
		currentState = EnemyState.idle;
		myRigidbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		target = GameObject.FindWithTag("Player").transform;
		//anim.SetBool("wakeUp", true);
		anim.SetBool("walking", true);
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		if (Input.GetKeyDown(KeyCode.E))
		{
			unfollow();
			//CheckDistance();
		}
		if (!follow && !Unfollow )
		{
			CheckDistance();
		}
		if (follow)
		{
			followingPlayer();
			
		}
	}
	public virtual void CheckDistance()
	{
		if (Vector3.Distance(target.position, transform.position) <= chaseRadius/* && Vector3.Distance(target.position, transform.position) >= chaseRadius/*attackRadius*/)
		{
			if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
			{
				Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
				follow = true;
				ChangeAnim(temp - transform.position);
				myRigidbody.MovePosition(temp);
				ChangeState(EnemyState.walk);
				anim.SetBool("walking", true);
				//anim.SetBool("wakeUp", true);
			}
		}
		else if (Vector3.Distance(target.position, transform.position) >= chaseRadius)
		{
			anim.SetBool("walking", false);
		}
	}
	public void SetAnimFloat(Vector2 setVector)
	{
		anim.SetFloat("moveX", setVector.x);
		anim.SetFloat("moveY", setVector.y);
	}
	public void ChangeAnim(Vector2 direction)
	{
		if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
		{
			if (direction.x > 0)
			{
				SetAnimFloat(Vector2.right);
			}
			else if (direction.x < 0)
			{
				SetAnimFloat(Vector2.left);
			}
		}
		else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
		{
			if (direction.y > 0)
			{
				SetAnimFloat(Vector2.up);
			}
			else if (direction.y < 0)
			{
				SetAnimFloat(Vector2.down);
			}
		}
	}
	public void ChangeState(EnemyState newState)
	{
		if (currentState != newState)
		{
			currentState = newState;
		}
	}
	public void followingPlayer()
	{
		if (follow == true)
		{
			Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
			ChangeAnim(temp - transform.position);
			myRigidbody.MovePosition(temp);
			ChangeState(EnemyState.walk);
			anim.SetBool("walking", true);
		}
		
	}
	public void unfollow()
	{
	
		
			Debug.Log("unfolow");
			if (follow == true)
			{
				follow = false;
			    Unfollow = true;
				anim.SetBool("walking", false);
			     
			}
			else if (Unfollow == true)
	     	{
		    	Unfollow = false;
		    }
		  	
		
	}

}
