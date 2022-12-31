using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PushButtons : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate{};

    private int deviderposition;
    private string buttonName, buttonValue;
    // Start is called before the first frame update
    void Start()
    {
        buttonName = gameObject.name;
        deviderposition = buttonName.IndexOf("-");
        buttonValue = buttonName.Substring(0, deviderposition);

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

   private void ButtonClicked()
   {
        ButtonPressed(buttonValue);
   }
}
