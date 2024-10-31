using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Page : MonoBehaviour
{
    [SerializeField] List<GameObject> questionObjects;
    [SerializeField] GameObject nextPage;
    [SerializeField] GameObject prevPage;

    [SerializeField] UnityEngine.UI.Button nextButton;
    [SerializeField] UnityEngine.UI.Button prevButton;

    [SerializeField] GameObject wrongAnswer;

    private List<IQuestion> questions = new List<IQuestion>();

    public void Start()
    {
        foreach (GameObject Object in questionObjects)
        {
            var question = Object.GetComponent<IQuestion>();
            if (question == null)
            {
                continue;
            }
            else
            {
                questions.Add(question);
            }
        }

        if (nextButton != null)
            nextButton.onClick.AddListener(GoToNextPage);

        if (prevButton != null)
            prevButton.onClick.AddListener(GoToPrevPage);
    }



    public void GoToNextPage()
    {
        if (CheckAnswers())
        {
            wrongAnswer.gameObject.SetActive(false);
            nextPage.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            ResetQuestions();
            wrongAnswer.gameObject.SetActive(true);
        }
    }

    public void GoToPrevPage()
    {
        prevPage.SetActive(true);
        gameObject.SetActive(false);
    }

    private bool CheckAnswers()
    {
        foreach (IQuestion question in questions)
        {
            Debug.Log("q0");
            if (!question.CheckAnswer())
            {
                Debug.Log("q10");
                return false;
            }
        }

        return true;
    }

    private void ResetQuestions()
    {
        foreach (IQuestion question in questions)
        {
            question.Reset();
        }
    }

}
