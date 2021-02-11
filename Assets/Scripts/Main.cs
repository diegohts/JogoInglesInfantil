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

    private void OnDisable()
    {
       /* if ((gameObject.name == "Miner" && SceneManager.GetActiveScene().buildIndex == 1)) //chega no final da fase muda pra proxima
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //isso faz com que passede fase pegando a cena ataul e acrescentando 1 para a proxima
        }
        else if ((gameObject.name == "Miner" && SceneManager.GetActiveScene().buildIndex == 2))
        {
            Application.LoadLevel(0);
        }*/

        //if(gameObject.name == "Water")
    }

    /* Para excluir as estrelinhas e a pontuação */
    public void resetScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
