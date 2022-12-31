using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SaveData
{
//	public static void SavePlayer(Inventory player)
//	{
//		BinaryFormatter formatter = new BinaryFormatter();
//		string path = Application.persistentDataPath + " /player.fun ";
//		FileStream stream = new FileStream(path, FileMode.Create);
//		//playerData data = new playerData(player);
//		formatter.Serialize(stream, data);
//		stream.Close();
//	}
//		public static playerData LoadPlayer()
//		{
//			string path = Application .persistentDataPath + " /player.fun ";
//			if (File.Exists(path))
//			{
//				BinaryFormatter formatter = new BinaryFormatter();
//				FileStream stream = new FileStream(path, FileMode.Open);
//				playerData data = formatter.Deserialize(stream) as playerData;
//				stream.Close();
//				return data;
//			}
//			else
//			{
//				Debug.LogError("savefile not found " + path);
//				return null;
//			}
//		}
	
}
