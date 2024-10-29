using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// Script for open questions 
/// CheckAnswer() function and the value change has to be set by a UI InputField
/// I suggest setting the good answer to something other than ""
/// this will make it possible to check if answer haven't been filled in yet so it returns a warning
/// </summary>
public class OpenQuestion : MonoBehaviour
{
    [SerializeField] string goodAnswer = "";
    [SerializeField] string questionAnswered = "";


    private void Start()
    {
        if (goodAnswer == "")
        {
            Debug.LogWarning("CorrectAnswer on gameObject " + gameObject.name + " is still empty");
        }
    }

    public void SetAnswer(string newValue)
    {
        questionAnswered = newValue;
        Debug.Log(questionAnswered);

        if (questionAnswered == goodAnswer)
        {
            Debug.Log("GOOD ANSWER FOR " + gameObject.name);
        }
    }


    public bool CheckAnswer()
    {
        // check if answer is equal to solution
        if (questionAnswered.Equals(goodAnswer, System.StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}