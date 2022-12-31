using UnityEngine;
using System.IO;
using TMPro;
public class GetText : MonoBehaviour
{
	string[] SCORES;
	public TextMeshProUGUI allscores;
	private void Start()
	{
	  readfromfile();
		refresh();
	}
	public void readfromfile()
	{
		string readfromfile = Application.persistentDataPath + "/Scores/" + "marks" + ".txt";
		SCORES = File.ReadAllLines(readfromfile);
		displayNames();
	}
	public void refresh()
	{
		clearfile();
		readfromfile();
	}
	void displayNames()
	{
		foreach (string score in SCORES)
		{
			allscores.text +=  score + "\n";
		}
	}
	public void copy()
	{
		if (allscores.text != null)
		{
			TextEditor texteditor = new TextEditor();
			texteditor.text = allscores.text;
			texteditor.SelectAll();
			texteditor.Copy();
		}
	}
	public void clearfile()
	{
		allscores.text = null;
	}
}
