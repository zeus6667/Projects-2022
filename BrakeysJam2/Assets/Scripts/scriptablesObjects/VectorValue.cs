using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject,ISerializationCallbackReceiver
{
    [Header("value running in game ")]
    public Vector2 initialValue;
    [Header("value by default when starting")]
    public Vector2 defaultValue;

     public void OnAfterDeserialize()
   {
      initialValue = defaultValue;
   }

   public void OnBeforeSerialize()
   {

   }

}
