using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
	[SerializeField] GameObject GroundBlock;
	public GameObject[] GroundTop;
	[SerializeField] float width , height;
	[SerializeField] float minHeight, maxHeight;
	[SerializeField] float repeatNum;
	public int actualheight;
	public int actualwidth;
	private int index;
	public float angle;
	public int speed,snaposi;
	private Vector2 screenBounds;
	// Start is called before the first frame update
	void Start()
	{
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		Generation();
	}
	private void Update()
	{
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (transform.position.y < snaposi )
		{
			Debug.Log("hua");
			snaposi += -65;
			Generation();
			
		}

	}
	void Generation()
	{
		
		float repeatValue = 0;
		for (int y = - actualheight + 21; y < height-actualheight; y++)//this is for tile on x
		{
			if (repeatValue == 0)
			{
				width = Random.Range(minHeight, maxHeight);
				GeneratePlatform(y);
				repeatValue = repeatNum;
			}
			else
			{
				GeneratePlatform(y);
				repeatValue--;
			}
			GeneratePlatform1(y);
		}
	}
	
	void GeneratePlatform(int y)
	{
		index = Random.Range(0, GroundTop.Length);
		for (int x = -actualwidth; x < width-actualwidth; x++)//this is for tile on y
		{
			spawnObj(GroundBlock, x, y);
		}
		spawnObj(GroundTop[index], width- actualwidth, y);
	}

	void GeneratePlatform1(int y)
	{
		index = Random.Range(0, GroundTop.Length);
		for (int x = -actualwidth; x < width - actualwidth; x++)//this is for tile on y
		{
			spawnObj(GroundBlock, -x, y);
		}
		spawnObj1(GroundTop[index], -width +actualwidth, y);
	}
	void spawnObj(GameObject obj , float width, float height)
	{
		obj.transform.rotation = Quaternion.AngleAxis(angle,Vector3.up);
		obj = Instantiate(obj,new Vector2(width,height), Quaternion.identity);
		obj.transform.parent = this.transform;
	}
	void spawnObj1(GameObject obj, float width, float height)
	{
		obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
		obj = Instantiate(obj, new Vector2(width, height), obj.transform.rotation);
		obj.transform.parent = this.transform;
	}
}
//void Generation()
//{

//	float repeatValue = 0;
//	for (int y = -actualheight; y < height - actualheight; y++)//this is for tile on x
//	{
//		if (repeatValue == 0)
//		{
//			width = Random.Range(minHeight, maxHeight);
//			GeneratePlatform(y);
//			repeatValue = repeatNum;
//		}
//		else
//		{
//			GeneratePlatform(y);
//			repeatValue--;
//		}
//		GeneratePlatform1(y);
//	}
//}