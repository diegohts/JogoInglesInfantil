using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseButton;
   
    public void PauseFuction()
    {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
            PauseButton.SetActive(false);
            PauseMenu.SetActive(true);
        } else {
            Time.timeScale = 1;
            PauseButton.SetActive(true);
            PauseMenu.SetActive(false);
        }
    }
}
