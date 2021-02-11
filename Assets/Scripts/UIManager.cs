using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
    public Text healthText; 
    public Slider healthBar; 
    public Text coinsText; 
   
    void Awake()
    {   
        UpdateHealthBar();
        UpdateCoins();
    }

    public void UpdateHealthUI(int health) 
    { 
        healthText.text = health.ToString();
        healthBar.value = health; 
    }

    public void UpdateCoins() 
    { 
        coinsText.text = GameManager.gameManager.coins.ToString(); 
    }

    public void UpdateHealthBar() 
    {
        healthBar.maxValue = GameManager.gameManager.health;
    }
}
