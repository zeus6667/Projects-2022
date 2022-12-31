using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText1, healthText2;
    public Image healthBar1, healthBar2;
    public Health player1Health;
    public Health1 player2Health;

    public float health;
    public float health1;
    float lerpSpeed;

    private void Start()
    {
       player1Health = GameObject.Find("Player1").GetComponent<Health>();
       player2Health = GameObject.Find("Player2").GetComponent<Health1>();
    }

    private void Update()
    {
        health = player1Health.currenthealth;
        health1 = player2Health.currenthealth1;
        healthText1.text = health + "%";
        healthText2.text = health1 + "%";
        if (health > player1Health.startingHealth) health = player1Health.startingHealth;
        if (health1 > player2Health.startingHealth1) health1 = player2Health.startingHealth1;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar1.fillAmount = Mathf.Lerp(healthBar1.fillAmount, health / player1Health.startingHealth, lerpSpeed);
        healthBar2.fillAmount = Mathf.Lerp(healthBar2.fillAmount, health1 / player2Health.startingHealth1, lerpSpeed);
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / player1Health.startingHealth));
        healthBar1.color = healthColor;
        Color healthColor1 = Color.Lerp(Color.red, Color.green, (health1 / player2Health.startingHealth1));
        healthBar2.color = healthColor1;
    }

  
}