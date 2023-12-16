using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;
    [SerializeField] private TextMeshProUGUI factText;
    [SerializeField] private TextMeshProUGUI trueAnswerText;
    [SerializeField] private TextMeshProUGUI falseAnswerText;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeBetweenQuestions = 1f;

    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);   
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;

        if (currentQuestion.isTrue) 
        {
            trueAnswerText.text = "Correct";
            falseAnswerText.text = "Wrong";
        }else
        {
            trueAnswerText.text = "Wrong";
            falseAnswerText.text = "Correct";
        }
    }

    IEnumerator TransistionToNextQuestion () 
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }

        StartCoroutine(TransistionToNextQuestion());
    }

    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
        StartCoroutine(TransistionToNextQuestion());
    }

}