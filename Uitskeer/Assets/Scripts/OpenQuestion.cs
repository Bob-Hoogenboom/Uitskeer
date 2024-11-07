using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for open questions 
/// CheckAnswer() function and the value change has to be set by a UI InputField
/// I suggest setting the good answer to something other than ""
/// this will make it possible to check if answer haven't been filled in yet so it returns a warning
/// </summary>
public class OpenQuestion : MonoBehaviour, IQuestion
{
    [SerializeField] string goodAnswer = "";
    [SerializeField] string questionAnswered = "";
    [SerializeField] TMPro.TMP_InputField inputField;

    public Color wrongColor = new Color(255, 192, 192);

    [SerializeField] Image Image;

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

        if (questionAnswered.ToLower() == goodAnswer.ToLower())
        {
            Debug.Log("GOOD ANSWER FOR " + gameObject.name);
        }
    }


    public void Reset()
    {
        questionAnswered = "";
        inputField.text = "";
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

    public void TurnRed()
    {
        Image.color = new Color(1, 0.71f, 0.71f);
    }
    public void TurnNormal()
    {
        Image.color = new Color(0.95f, 0.95f, 0.95f);
    }
}
