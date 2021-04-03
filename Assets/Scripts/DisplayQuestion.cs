using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayQuestion : MonoBehaviour
{
    public GameObject QuizScene;
    public int contador = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null) {
            if (contador == 0) {
                QuizScene.SetActive(true);
                contador = 1;
            }
        }    
    }
}
