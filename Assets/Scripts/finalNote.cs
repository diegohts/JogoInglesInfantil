using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class finalNote : MonoBehaviour
{
    private int idTheme;

    public Text txtNote;
    public Text txtInfoTheme;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int noteFinal;
    private int hits;

    void Start()
    {
        idTheme = PlayerPrefs.GetInt("idTheme"); 

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        noteFinal = PlayerPrefs.GetInt("finalNoteTemp" + idTheme.ToString());
        hits = PlayerPrefs.GetInt("hitsTemp" + idTheme.ToString());

        txtNote.text = noteFinal.ToString();
        txtInfoTheme.text = "Você acertou " + hits.ToString() + " de 10 perguntas !";

        if (noteFinal == 10) {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        } else if ((noteFinal >= 7) && (noteFinal < 10)) {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
        } else if ((noteFinal >= 3) && (noteFinal < 7)) {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
        } else {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

    public void playAgain()
    {
        Application.LoadLevel("T" + idTheme.ToString()); 
    }
}
