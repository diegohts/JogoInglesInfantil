using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public int health = 5; 
    public int damage = 1; 
    public int coins; 

    public static GameManager gameManager; 

    private void Awake()
    {
        if (gameManager == null) { 
            gameManager = this;
        }
     
        DontDestroyOnLoad(gameManager); 
    }

    void Update()
    {
    }
}
