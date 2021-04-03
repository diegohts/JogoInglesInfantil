using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ReplyScene : MonoBehaviour
{
    private int idQuestion;          

    public Text question;
    public Text answerA;
    public Text answerB;
    public Text answerC;
    public Text infoQuestion;

    public GameObject CanvasPrimary;
    public GameObject QuizScene;

    public Image imageQuestion;
    public AudioSource ButtonImage;

    public string[] questions;       
    public string[] alternativeA;    
    public string[] alternativeB;     
    public string[] alternativeC;    
    public string[] correct;         

    private int questionsNumbers;    
    private int number;

    public Sprite[] imageQuestions;
    public AudioClip[] audios;
    public AudioSource audioSource;

    void Start()
    {
        CanvasPrimary.SetActive(false);
        QuizScene.SetActive(true);
        audioSource.mute = true;

        number = Random.Range(0,9);

        idQuestion = number;
        questionsNumbers = questions.Length;

        imageQuestion.sprite = imageQuestions[idQuestion];
        ButtonImage.clip = audios[idQuestion];

        question.text = questions[idQuestion];
        answerA.text = alternativeA[idQuestion];
        answerB.text = alternativeB[idQuestion];
        answerC.text = alternativeC[idQuestion];

        Time.timeScale = 0;
        infoQuestion.enabled = false;
    }

    public void answer(string alternative)
    {
        if (alternative == "A") {
            if (alternativeA[idQuestion] == correct[idQuestion]) {
                QuizScene.SetActive(false);
                CanvasPrimary.SetActive(true);
                audioSource.mute = false;
                Time.timeScale = 1;
            } else { 
                infoQuestion.enabled = true;
                StartCoroutine("OpenAnswer");
            }
        } else if (alternative == "B") {
            if (alternativeB[idQuestion] == correct[idQuestion]) {
                QuizScene.SetActive(false);
                CanvasPrimary.SetActive(true);
                audioSource.mute = false;
                Time.timeScale = 1;
            } else {
                infoQuestion.enabled = true;
                StartCoroutine("OpenAnswer");
            }
        } else if (alternative == "C") {
            if (alternativeC[idQuestion] == correct[idQuestion]) {
                QuizScene.SetActive(false);
                CanvasPrimary.SetActive(true);
                audioSource.mute = false;
                Time.timeScale = 1;
            } else {
                infoQuestion.enabled = true;
                StartCoroutine("OpenAnswer");
            }
        }
    }

    private IEnumerator OpenAnswer()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
