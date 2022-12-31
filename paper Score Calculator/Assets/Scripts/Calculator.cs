using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Calculator : MonoBehaviour
{
	public float[] numbers = new float[50];
	public float result = 0;
	public TextMeshProUGUI inputField;
	bool displayedResults = false;
	string inputString;
	public int index;
	public int MAXSCORE;
	public bool Result;
	public InfoTransfer infotransfer;
	private string maxscorefrominfo;
	public bool isCorrect = false;
	public bool abscent = false;
	private float ans;
	private bool substract;

	private void Start()
	{
		infotransfer = GameObject.Find("Main Camera").GetComponent<InfoTransfer>();
		Result = false;
	}
	private void Update()
	{
		maxscorefrominfo = infotransfer.maxScore;
		int.TryParse(maxscorefrominfo, out MAXSCORE);
		if (index < 0 )
		{
			index = 0;
		}
		if (result < 0)
		{
			result = 0;
		}
	}
	public void getNos()
	{
		if (displayedResults == true)
		{
			inputField.text = "";
			inputString = "";
			displayedResults = false;
		}
		//Debug.Log(EventSystem.current.currentSelectedGameObject.name);
		string ButtonValue = EventSystem.current.currentSelectedGameObject.name;
		
		if(float.TryParse(ButtonValue,out ans))
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[index] = ans;
			}
		}
		index++;

		inputField.text += "+" + ans.ToString();
		
	}
	public void backspace()
	{
		inputField.text += "-" + ans.ToString();
		numbers[index] = -ans;
	    index++;
	}
	public void sum()
	{
		if (abscent == false)
		{
			if (Result == false)
			{
				for (int i = 0; i < numbers.Length; i++)
				{
					result += numbers[i];
				}
				if (result <= MAXSCORE)
				{
					inputString = result.ToString();
					inputField.text = inputString + "/" + MAXSCORE;
					Result = true;
					isCorrect = true;
				}
				else
				{
					isCorrect = false;
					inputField.text = "Score is greater than Max Score";
				}
			}
			else if (Result == true)
			{
				result = 0;
				for (int i = 0; i < numbers.Length; i++)
				{
						result += numbers[i];
				}
				if (result < 0)
				{
					result = 0;
				}
				if (result <= MAXSCORE)
				{
					inputString = result.ToString();
					inputField.text = inputString + "/" + MAXSCORE;
					Result = true;
					isCorrect = true;
				}
				else
				{
					isCorrect = false;
					inputField.text = "Score is greater than Max Score";
				}
			}
			else
			{
				abscent = true;
			}
		}
		
		
	}
	
	public void clear()
	{
		for (int i = 0; i <numbers.Length; i++)
		{
			numbers[i] = 0;
		}
		index = 0;
		result = 0;
		inputField.text = "";
		Result = false;
		isCorrect = false;
		abscent = false;
	}
	
	public void Abscent()
	{
		inputField.text = "AB";
		abscent = true;
	}
}

