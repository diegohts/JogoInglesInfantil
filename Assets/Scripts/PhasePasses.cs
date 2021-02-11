using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PhasePasses : MonoBehaviour
{
    void Start()
    {        
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else if (other.gameObject.CompareTag("Player") && SceneManager.GetActiveScene().buildIndex == 5) {
            Application.LoadLevel(0);
        }
    }
}
