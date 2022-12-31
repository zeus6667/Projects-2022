
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Characerselect : MonoBehaviour
{
	public unlocktry unlockable;
	public GameObject[] characters;
	public int selectedCharacter = 0;
	public TextMeshProUGUI TotalcoinDisplay;
	public Inventory playerInventory;
	public GameObject[] lockPanel;

	public unlocktry reqamount;
	public bool isunlocked;
	private void Awake()
	{
		//isunlocked = false;
		
	}
	private void Update()
	{
		if (TotalcoinDisplay)
		{
			TotalCoins();
		}
	}
	public void NextCharacter()
	{
		FindObjectOfType<AudioManager>().play("ButtonClick");
		//isunlocked = (PlayerPrefs.GetInt("isunlocked") != 0);
		characters[selectedCharacter].SetActive(false);
		selectedCharacter = (selectedCharacter + 1) % characters.Length;
		characters[selectedCharacter].SetActive(true);
		if (!unlockable.isunloced)
		{
			lockPanel[selectedCharacter].SetActive(false);
		}
		//reqamount.requiredcoins += 5000;

	}
	public void PreviousCharacter()
	{
		FindObjectOfType<AudioManager>().play("ButtonClick");
		characters[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += characters.Length;
			//reqamount.requiredcoins -= 5000;
		}
		characters[selectedCharacter].SetActive(true);
		
	}
	//public void StartGame()
	//{
	//	if (isunlocked && selectedCharacter == 1)
	//	{

	//		//PlayerPrefs.SetInt("isunlocked", (isunlocked ? 1 : 0));
	//		//isunlocked = (PlayerPrefs.GetInt("isunlocked") != 0);
	//		PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
	//		SceneManager.LoadScene(1, LoadSceneMode.Single);
	//	}
	//	else if (selectedCharacter == 0)
	//	{
	//		SceneManager.LoadScene(1, LoadSceneMode.Single);
	//	}
	//}
	public void TotalCoins()
	{
		TotalcoinDisplay.text = "" + playerInventory.TotalCoins;
	}
}
