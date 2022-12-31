using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HostageEnemy : MonoBehaviour
{
	public NavMeshAgent agent;
	private GameObject enemy;
	[HideInInspector]
	public Transform player;

	public LayerMask whatIsGround, whatIsPlayer;

	public int health;
	public int damage;

	public GameObject DeathEffect;

	//Attacking
	public float timeBetweenAttacks;
	bool alreadyAttacked;
	public GameObject projectile;

	//States
	public float sightRange, attackRange;
	public bool playerInSightRange, playerInAttackRange;
	
	private HostageHealth helth;

	private void Awake()
	{
		player = GameObject.Find("Player").transform;
		enemy = GameObject.Find("hostage enemy");
		agent = GetComponent<NavMeshAgent>();
		helth = GetComponent<HostageHealth>();
		
	}
	private void FixedUpdate()
	{
		//Check for sight and attack range
		playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		if (playerInSightRange && !playerInAttackRange) ChasePlayer();
		if (playerInAttackRange && playerInSightRange) AttackPlayer();
	}
	
	private void ChasePlayer()
	{
		agent.SetDestination(player.position);
	}
	private void AttackPlayer()
	{
		//Make sure enemy doesn't move
		agent.SetDestination(transform.position);

		transform.LookAt(player);

		if (!alreadyAttacked)
		{
			///Attack code here
			Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
			rb.AddForce(transform.up * 8f, ForceMode.Impulse);
			///End of attack code

			alreadyAttacked = true;
			Invoke(nameof(ResetAttack), timeBetweenAttacks);
		}
	}
	private void ResetAttack()
	{
		alreadyAttacked = false;
	}

	public void TakeDamage()
	{
		//health -= damage;
		helth.ModifyHealth();
		if (helth.currentHealth <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackRange);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, sightRange);
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("bullet"))
		{
			TakeDamage();
			Destroy(other.gameObject);
		}
	}
	private void DestroyEnemy()
	{
		Debug.Log("ye q ");
		Destroy(gameObject);
		if (DeathEffect != null)
		{
			Instantiate(DeathEffect, transform.position, Quaternion.identity);
		}
		FindObjectOfType<AudioManager>().play("PlayerDeath");
		
		UIManager.instance.AddKill();
		UIManager.instance.ShowKill();
		UIManager.instance.AddHostage();
		UIManager.instance.ShowHostage();
		
	}
}