using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private string nameScene;
   
    public void StartScene()
    {
        Time.timeScale = 1;
        Application.LoadLevel(2);
    }

    public void InfoScene()
    {
        Time.timeScale = 1;
        Application.LoadLevel(1);
    }

    public void ExitScene()
    {
        Application.Quit(); 
    }

    public void AddScene(string sceneName) 
    {
        nameScene = sceneName;
        StartCoroutine("Open");
        Time.timeScale = 1;
    }

    private IEnumerator Open()
    {
        yield return new WaitForSeconds(0.2f);
        Application.LoadLevel(nameScene);
    }

    public void resetScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
