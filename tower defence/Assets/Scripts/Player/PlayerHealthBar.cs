using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
	public PlayerHealth playerHealth;
	public Image foreGroundImage;
	public float updateSpeedSeconds = 0.5f;
	// Start is called before the first frame update
	void Awake()
	{
		playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
		playerHealth.OnHealthPctChanged += HandleHealthChanged;
		//GetComponentInParent<PlayerHealth>().OnHealthPctChanged += HandleHealthChanged;
	}

	private void HandleHealthChanged(float pct)
	{
		StartCoroutine(ChangeToPct(pct));
	}
	private IEnumerator ChangeToPct(float pct)
	{
		float preChangePct = foreGroundImage.fillAmount;
		float elapsed = 0f;

		while (elapsed < updateSpeedSeconds)
		{
			elapsed += Time.deltaTime;
			foreGroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
			yield return null;
		}
		foreGroundImage.fillAmount = pct;

	}
	// Update is called once per frame
	private void LateUpdate()
	{
		transform.LookAt(Camera.main.transform);
		transform.Rotate(0, 180, 0);
	}
}

