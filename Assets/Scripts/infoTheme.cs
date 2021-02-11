using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoTheme : MonoBehaviour
{
    public int idTheme;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int finalNote;

    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        finalNote = PlayerPrefs.GetInt("finalNote" + idTheme.ToString());

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
    }

    void Update()
    {        
    }
}
