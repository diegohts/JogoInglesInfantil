using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTheme : MonoBehaviour
{
    public Button       btnPlay;
    public Text         textThemeName;

    public GameObject   infoLevel;
    public Text         textInfoLevel;
    public GameObject   star1;
    public GameObject   star2;
    public GameObject   star3;

    public string[]     themeName;
    public int          questionsNumbers;
    private int         idTheme;

    void Start()
    {
        idTheme = 0;
        textThemeName.text = themeName[idTheme];
        textInfoLevel.text = "Você acertou X de X perguntas!";
        infoLevel.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        btnPlay.interactable = false;
    }

    public void selectTheme(int i)
    {
        idTheme = i;
        PlayerPrefs.SetInt("idTheme",idTheme); 

        textThemeName.text = themeName[idTheme];

        int finalNote = PlayerPrefs.GetInt("finalNote" + idTheme.ToString()); ; 
        int hits = PlayerPrefs.GetInt("hitsTemp" + idTheme.ToString()); 

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        if (finalNote == 10) {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        } else if ((finalNote >= 7) && (finalNote < 10)) {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        } else if ((finalNote >= 3) && (finalNote < 7)) {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        } else {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }

        textInfoLevel.text = "Você acertou "+hits.ToString()+" de "+questionsNumbers.ToString()+" perguntas!";
        infoLevel.SetActive(true);
        btnPlay.interactable = true;
    }

    public void play() 
    {
        Application.LoadLevel("T"+idTheme.ToString());
    }
}
