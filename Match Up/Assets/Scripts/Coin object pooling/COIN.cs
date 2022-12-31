using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class COIN : MonoBehaviour
{
	//   [SerializeField] CoinSetting _coinSetting;
	//   float _timeInTrigger;

	//   IObjectPool<COIN> _pool;
	//   bool _inWaterTrigger;
	//   Transform _transform;

	//   public void SetPool(IObjectPool<COIN> pool) => _pool = pool;

	//private void OnTriggerEnter(Collider other)
	//{
	//	_inWaterTrigger = true;
	//}

	//private void OnDisable()
	//{
	//	_inWaterTrigger = false;
	//}
	//   // Update is called once per frame
	//   void Update()
	//   {
	//	if (_inWaterTrigger == false)
	//	{
	//		return;
	//	}

	//	_timeInTrigger += Time.deltaTime;
	////	transform.localScale = Vector3.one * (1f + _timeInTrigger / _coinSetting.LifeAfetrLanding);
	//	if (_timeInTrigger >= _coinSetting.LifeAfetrLanding)
	//	{
	//		if (_pool !=null)
	//		{
	//			_pool.Release(this);
	//		}
	//		else
	//		{
	//			Destroy(gameObject);
	//		}
	//	}
	//   }
	//private void Awake()
	//{
	//	_transform = transform;
	//}
	private Action<COIN> _killAction;

	public void Init(Action<COIN> killAction)
	{
		_killAction = killAction;
	}

}
