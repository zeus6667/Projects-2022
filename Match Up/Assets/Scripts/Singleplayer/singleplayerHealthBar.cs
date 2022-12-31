
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class singleplayerHealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText1 ;
    public Image healthBar1 ;
    public Health player1Health;
  

    public float health;

    float lerpSpeed;

    private void Start()
    {
        player1Health = GameObject.Find("Player1").GetComponent<Health>();
       
    }

    private void Update()
    {
        health = player1Health.currenthealth;
      
        healthText1.text = health + "%";
       
        if (health > player1Health.startingHealth) health = player1Health.startingHealth;
      

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar1.fillAmount = Mathf.Lerp(healthBar1.fillAmount, health / player1Health.startingHealth, lerpSpeed);
      
    }

    void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / player1Health.startingHealth));
        healthBar1.color = healthColor;
    }


}