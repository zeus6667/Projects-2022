using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LevelSelector : MonoBehaviour
{
	public GameObject levelHolder;
	public GameObject levelIcon;
	public GameObject thisCanvas;
	public int numberOfLevels = 50;
	public Vector2 iconSpacing;
	private Rect panelDimensions;
	private Rect iconDimensions;
	private int amountPerPage;
	private int currentLevelCount;

	public Sprite[] cannonImages;
	public string[] cannonName;
	public  int index = -1;

	// Start is called before the first frame update
	void Start()
	{
		panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
		iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
		int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
		int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
		amountPerPage = maxInARow * maxInACol;
		int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
		LoadPanels(totalPages);
	}
	void LoadPanels(int numberOfPanels)
	{
		GameObject panelClone = Instantiate(levelHolder) as GameObject;
		PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();
		swiper.totalPages = numberOfPanels;

		for (int i = 1; i <= numberOfPanels; i++)
		{
			GameObject panel = Instantiate(panelClone) as GameObject;
			panel.transform.SetParent(thisCanvas.transform, false);
			panel.transform.SetParent(levelHolder.transform);
			panel.name = "Page-" + i;
			panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
			SetUpGrid(panel);
			int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;
			LoadIcons(numberOfIcons, panel);
		}
		Destroy(panelClone);
	}
	void SetUpGrid(GameObject panel)
	{
		GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
		grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
		grid.childAlignment = TextAnchor.MiddleCenter;
		grid.spacing = iconSpacing;
	}
	void LoadIcons(int numberOfIcons, GameObject parentObject)
	{
		for (int i = 1; i <= numberOfIcons; i++)
		{
			index++;
			currentLevelCount++;
			GameObject icon = Instantiate(levelIcon) as GameObject;
			icon.transform.SetParent(thisCanvas.transform, false);
			icon.transform.SetParent(parentObject.transform);
		    icon.name = "Level " + i;
			icon.GetComponentInChildren<TextMeshProUGUI>().SetText(""+cannonName[index]);
		   // icon.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + currentLevelCount);
			icon.GetComponentInChildren<Image>().sprite = cannonImages[index];
		
		}
	} 

	// Update is called once per frame
	void Update()
	{
		

	}
}