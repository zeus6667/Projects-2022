using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  //[CreateAssetMenu]
    public class Signal : ScriptableObject
    {
    public List<signalListner> listners = new List<signalListner>();
    public void Raise()
    {
      for (int i = listners.Count -1; i >= 0; i--)
      {
          listners[i].OnSignalRaised();
      }
    }
    public void RegisterListner(signalListner listner) 
    {
        listners.Add(listner);

    }
    public void  DeRegisterListner(signalListner listner)
    {
         listners.Remove(listner);
    }
}
