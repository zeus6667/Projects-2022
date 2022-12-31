
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SinglePlayerDistance : MonoBehaviour
{
    public GameObject startPos, ScoreTextObj, Player1;
    public TextMeshProUGUI scoreText;

    public int Distance;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = ScoreTextObj.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Distance = ((int)startPos.transform.position.y + (int)Player1.transform.position.y);
        scoreText.text = Distance.ToString();
    }
}

