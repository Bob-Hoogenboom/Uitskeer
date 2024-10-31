using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




// describes a dropdown menu that acts like a binairi search tree
public class DropdownDate : MonoBehaviour, IQuestion
{
    [SerializeField] int answerDay = 0;
    [SerializeField] int answerMonth = 0;
    [SerializeField] int answerYear = 0;

    [SerializeField] string playerAnswer;
    [SerializeField] TMPro.TMP_Dropdown dropDown;

    string answer;

    // edges of beginning of the tree
    public int startDate = 1900;
    public int endDate = 2025;

    // current edges of tree and middle
    private DateTime min;
    private DateTime max;
    private DateTime middle;


    // Start set the first middle and edges of the tree
    void Start()
    {
        if (answerDay <= 0 || answerDay > 31)
        {
            Debug.LogWarning("CorrectAnswer Day on gameObject " + gameObject.name + " is imposible");
        }
        if (answerMonth <= 0 || answerMonth > 12)
        {
            Debug.LogWarning("CorrectAnswer Month on gameObject " + gameObject.name + " is imposible");
        }
        if (answerYear <= 1800 || answerYear > 2025)
        {
            Debug.LogWarning("CorrectAnswer Month on gameObject " + gameObject.name + " is out of scope");
        }

        answer = "is " + (new DateTime(answerYear, answerMonth, answerDay)).ToString("dd MMM yyyy");


        min = new DateTime(startDate, 1, 1);
        max = new DateTime(endDate, 12, 31);
        setMiddleDate();

        SetOptions();

        // will start update dates when value is changed
        dropDown.onValueChanged.AddListener(delegate { UpdateDates();});
    }

    // methode that acts when value is changed and does the binairi search tree algorithm 
    private void UpdateDates()
    {
        int selection = dropDown.value;

        if (selection == 0)
        {
            SetAnswer();
        }
        else if (selection == 1)
        {
            min = middle.AddDays(1);
            setMiddleDate();
            SetOptions();
            dropDown.value = -1;
        }
        else if (selection == 2)
        {
            max = middle.AddDays(-1);
            setMiddleDate();
            SetOptions();
            dropDown.value = -1;
        }

        
    }

    // methode that findes the middle of two dates
    private void setMiddleDate()
    {
        middle = min.AddTicks((max - min).Ticks / 2);
    }

    // methode that changes the dropdown options according to current middle
    private void SetOptions()
    {
        List<string> dropdowns = new List<string>();

        string middleString = middle.ToString("dd MMM yyyy");
        dropdowns.Add("is " + middleString);
        dropdowns.Add("> " + middleString);
        dropdowns.Add("< " + middleString);


        dropDown.ClearOptions();
        dropDown.AddOptions(dropdowns);
    }

    // methode that resets the dropdown menu
    public void Reset()
    {
        min = new DateTime(startDate, 1, 1);
        max = new DateTime(endDate, 12, 31);
        setMiddleDate();

        SetOptions();
    }

    // methode that updates the answer
    public void SetAnswer()
    {
        string selectedDate = dropDown.options[dropDown.value].text;

        playerAnswer = selectedDate;

        if (answer == playerAnswer)
        {   
            Debug.Log("GOOD ANSWER FOR " + gameObject.name);
        }
        else
        {
            Debug.Log("WRONG ANSWER FOR " + gameObject.name);
        }
    }

    // methode that checks answer and returns true for correct and false for incorrect
    public bool CheckAnswer()
    {
        if (answer == playerAnswer)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
