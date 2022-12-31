using UnityEngine;
using TMPro;

public class SinglePlayerTrigger : MonoBehaviour
{
	public GameObject Player1;
	public Inventory PlayerInventory;
	public TextMeshProUGUI player1Score;
	
	// Start is called before the first frame update
	void Start()
	{
		player1Score = GameObject.Find("Player1Coins").GetComponent<TextMeshProUGUI>();
	}

	// Update is called once per frame
	void Update()
	{
		player1Score.text = " " + PlayerInventory.coins3.ToString() + "x";
	}

}
