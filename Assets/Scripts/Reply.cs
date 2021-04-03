using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Reply : MonoBehaviour
{
    private int idTheme;             
    private int idQuestion;          

    public Text question;
    public Text answerA;
    public Text answerB;
    public Text answerC;
    public Text infoQuestion;
    
    public Image imageQuestion;
    public AudioSource ButtonImage;

    public string[] questions;       
    public string[] alternativeA;    
    public string[] alternativeB;    
    public string[] alternativeC;    
    public string[] correct;         

    private float hits;              
    private float questionsNumbers;  
    private int finalNote;           
    private float average;           

    public Sprite[] imageQuestions;
    public AudioClip[] audios;
    
    void Start()
    {
        idTheme = PlayerPrefs.GetInt("idTheme");
        idQuestion = 0;
        questionsNumbers = questions.Length;

        imageQuestion.sprite = imageQuestions[idQuestion];
        ButtonImage.clip = audios[idQuestion];

        question.text = questions[idQuestion];
        answerA.text  = alternativeA[idQuestion];
        answerB.text =  alternativeB[idQuestion];
        answerC.text =  alternativeC[idQuestion];

        infoQuestion.text = "Respondendo "+ (idQuestion+1).ToString() +" de "+ questionsNumbers +" perguntas!";
    }

    
    public void answer( string alternative )
    {
        if (alternative == "A") {
            if (alternativeA[idQuestion] == correct[idQuestion]) {
                hits += 1;
            }
        } else if (alternative == "B") {
            if (alternativeB[idQuestion] == correct[idQuestion]) {
                hits += 1;
            }
        } else if(alternative == "C") {
            if (alternativeC[idQuestion] == correct[idQuestion]) {
                hits += 1;
            }
        }

        nextQuestion();
    }

    void nextQuestion() 
    {
        idQuestion += 1;

        if (idQuestion <= (questionsNumbers-1)) {
            imageQuestion.sprite = imageQuestions[idQuestion];
            ButtonImage.clip = audios[idQuestion];
            question.text = questions[idQuestion];
            answerA.text = alternativeA[idQuestion];
            answerB.text = alternativeB[idQuestion];
            answerC.text = alternativeC[idQuestion];

            infoQuestion.text = "Respondendo " + (idQuestion + 1).ToString() + " de " + questionsNumbers + " perguntas!";

        } else {
            average = 10 * (hits / questionsNumbers); 
            finalNote = Mathf.RoundToInt(average); 

            if (finalNote > PlayerPrefs.GetInt("finalNote" + idTheme.ToString())) { 
                PlayerPrefs.SetInt("finalNote" + idTheme.ToString(), finalNote);
                PlayerPrefs.SetInt("hits" + idTheme.ToString(), (int) hits);
            }

            PlayerPrefs.SetInt("finalNoteTemp" + idTheme.ToString(), finalNote);
            PlayerPrefs.SetInt("hitsTemp" + idTheme.ToString(), (int)hits);

            Application.LoadLevel("NotaFinal");
        } 
    }
}
