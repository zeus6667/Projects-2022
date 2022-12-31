using UnityEngine;
using UnityEngine.Pool;

public class CoinPoolSpawn : MonoBehaviour
{
	[SerializeField] private COIN CoinPrefab;
	[SerializeField] private int spawnAmount = 50;
	[SerializeField] private bool usepool;
	private ObjectPool<COIN> pool;
	// Start is called before the first frame update
	void Start()
	{
		pool = new ObjectPool<COIN>(() =>
		{
			return Instantiate(CoinPrefab);
		}, COIN =>
		{
			COIN.gameObject.SetActive(true);
		}, COIN =>
		{
			COIN.gameObject.SetActive(false);
		}, COIN =>
		{
			Destroy(COIN.gameObject);
		}, false, 10, 20);
		InvokeRepeating(nameof(spawn), 0.2f, 0.2f);
	}       // Update is called once per frame
	void spawn()
	{
		for (int i = 0; i < spawnAmount; i++)
		{
			var COIN = usepool?pool.Get() : Instantiate(CoinPrefab);
			COIN.transform.position = transform.position + Random.insideUnitSphere*10;
			COIN.Init(KillCoin);
		}   
	}

	private void KillCoin(COIN obj)
	{
		throw new System.NotImplementedException();
	}

	private void KillCoin(Coin COIN)
	{
		if (usepool)
		{
			pool.Release(CoinPrefab);
		}
		else
		{
			Destroy(COIN.gameObject);
		}
	  
	}
}
