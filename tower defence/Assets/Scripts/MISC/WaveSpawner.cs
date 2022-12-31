using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

	public enum SpawnState { SPAWNING, WAITING, COUNTING };

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	private Vector3 attackPoint;
	public float maxforce, minforce;
	private float shootForce;
	public GameObject bullet;
	public Vector3 targetPoint;
	public float spawnTime, spread, spreadmax, spreadmin;
	public float reloadTime = 0.1f;
	public EnemyHealth enemyHealth;
	public int increaseamount =25;
	

	//public List<Wave> waves;
	public Wave[] waves;
	private int nextWave = 0;
	public int NextWave
	{
		get { return nextWave + 1; }
	}

	public Transform[] spawnPoints;

	public float timeBetweenWaves = 5f;
	private float waveCountdown;
	public float WaveCountdown
	{
		get { return waveCountdown; }
	}

	private float searchCountdown = 1f;

	private SpawnState state = SpawnState.COUNTING;
	public SpawnState State
	{
		get { return state; }
	}

	void Start()
	{
		
		if (spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points referenced.");
		}

		waveCountdown = timeBetweenWaves;
		attackPoint = new Vector3(Random.Range(-25, 25), Random.Range(2, 15), Random.Range(80, 120));
	}

	void Update()
	{
		
		if (state == SpawnState.WAITING)
		{
			if (!EnemyIsAlive())
			{
				WaveCompleted();
			}
			else
			{
				return;
			}
		}

		if (waveCountdown <= 0)
		{
			if (state != SpawnState.SPAWNING)
			{
				StartCoroutine( SpawnWave ( waves[nextWave] ) );
			}
		}
		else
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	void WaveCompleted()
	{
		Debug.Log("Wave Completed!");

		state = SpawnState.COUNTING;
		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1)
		{
			nextWave = 6;
			Debug.Log("ALL WAVES COMPLETE! Looping...");
		}
		else
		{
			nextWave++;
			enemyHealth.maxHealth += increaseamount;
			enemyHealth.minHealth += increaseamount;
		}
	}

	bool EnemyIsAlive()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0f)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag("Rock") == null)
			{
				Debug.Log("enemy hatam");
				return false;
			}
		}
		return true;
	}

	IEnumerator SpawnWave(Wave _wave)
	{
		Debug.Log("Spawning Wave: " + _wave.name);
		state = SpawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++)
		{
			SpawnEnemy(_wave.enemy);
			yield return new WaitForSeconds( 1f/_wave.rate );
		}

		state = SpawnState.WAITING;
		yield break;
	}

	void SpawnEnemy(Transform _enemy)
	{
		Debug.Log("Spawning Enemy: " + _enemy.name);
		//Transform _sp = spawnPoints[ Random.Range (0, spawnPoints.Length) ];
		//Instantiate(_enemy, _sp.position, _sp.rotation);
		shoot();
	}

	public void shoot()
	{
		shootForce = Random.Range(minforce, maxforce);
		float x = Random.Range(-spread, spread);
		float y = Random.Range(spreadmin, spreadmax);

		//Calculate direction from attackPoint to targetPoint
		Vector3 directionWithoutSpread = targetPoint - attackPoint;
		Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);
		GameObject currentBullet = Instantiate(bullet, _sp.position, _sp.rotation);
		currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce , ForceMode.Impulse);
	}

}
