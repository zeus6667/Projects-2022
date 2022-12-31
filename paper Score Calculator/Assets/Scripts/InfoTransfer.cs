using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InfoTransfer : MonoBehaviour
{
	public string maxScore;
	TouchScreenKeyboard normalkeyboard;
	TouchScreenKeyboard numberskeyboard;
	public InputField gradeinputfield;
	public InputField maxscoreinputfield;
	public Calculator calcResult;
	private string textDocsName;
	public Button startbutton;
	public string url = "https://deril-miranda.itch.io/";
	private void Start()
	{
		gradeinputfield.onEndEdit.AddListener(ConvertToUppercase);
		Directory.CreateDirectory(Application.persistentDataPath + "/Scores/");
		deleteFileContents();
	}
	private void Update()
	{
		if (gradeinputfield.text == "" || maxscoreinputfield.text == "")
		{
			startbutton.interactable = false;
		}
		else
		{
			startbutton.interactable = true;
		}
	}
	void ConvertToUppercase(string text)
	{
		gradeinputfield.text = text.ToUpper();
	}
	public void openNormalkeyboard()
	{
		normalkeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NamePhonePad);
	}
	public void opennumberkeyboard()
	{
		numberskeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
	}
	public void creatTextFile()
	{
		Debug.Log("th");
		if (gradeinputfield.text == "")
		{
			return;
		}
		//create the text file at the directory
		 textDocsName = Application.persistentDataPath + "/Scores/" + "marks" + ".txt";

		if (!File.Exists(textDocsName))
		{
			File.WriteAllText(textDocsName, "Scores \n\n");
		}
		File.AppendAllText(textDocsName, gradeinputfield.text + "\n");
	}
	public void storemaxscore()
	{
		maxScore = maxscoreinputfield.text;
	}
	public void newpaper()
	{
		if (calcResult != null && calcResult.isCorrect == true)
		{
			File.AppendAllText(textDocsName, calcResult.result + "\n");
		}
		if (calcResult.abscent == true)
		{
			File.AppendAllText(textDocsName,calcResult.inputField.text  + "\n");
		}
	}
	public void newGarde()
	{
		maxscoreinputfield.text = null;
		gradeinputfield.text = null;
		deleteFileContents();
	}
	public void deleteFileContents()
	{
		string readfromfile = Application.persistentDataPath + "/Scores/" + "marks" + ".txt";
		File.WriteAllText(readfromfile, string.Empty);
	}
	public void OpenLink()
	{
		Application.OpenURL(url);
	}

}

