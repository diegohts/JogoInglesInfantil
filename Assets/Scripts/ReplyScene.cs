using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class ReplyScene : MonoBehaviour
{
    private int idQuestion;          // id da pergunta
    private string alt;

    public Text question;
    public Text answerA;
    public Text answerB;
    public Text answerC;
    public Text infoQuestion;

    public GameObject CanvasPrimary;
    public GameObject QuizScene;

    public Image imageQuestion;
    public AudioSource ButtonImage;

    public string[] questions;       // armazena todas as perguntas
    public string[] alternativeA;    // armazena todas as alternativas A
    public string[] alternativeB;    // armazena todas as alternativas B 
    public string[] alternativeC;    // armazena todas as alternativas C
    public string[] correct;         // armazena todas as alternativas corretas

    private int questionsNumbers;    // numero de perguntas 
    private int number;

    public Sprite[] imageQuestions;
    public AudioClip[] audios;

    void Start()
    {
        CanvasPrimary.SetActive(false);
        QuizScene.SetActive(true);

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
                Time.timeScale = 1;
            } else { 
                infoQuestion.enabled = true;
                StartCoroutine("OpenAnswer");
            }
        } else if (alternative == "B") {
            if (alternativeB[idQuestion] == correct[idQuestion]) {
                QuizScene.SetActive(false);
                CanvasPrimary.SetActive(true);
                Time.timeScale = 1;
            } else {
                infoQuestion.enabled = true;
                StartCoroutine("OpenAnswer");
            }
        } else if (alternative == "C") {
            if (alternativeC[idQuestion] == correct[idQuestion]) {
                QuizScene.SetActive(false);
                CanvasPrimary.SetActive(true);
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
