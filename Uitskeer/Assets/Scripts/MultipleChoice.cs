using UnityEngine;


/// <summary>
/// Script explicitly for a multiple choice question. its value cvan be checked by simply calling 
/// CheckAnswer() function and the value change has to be set by a UI button
/// I suggest setting the yes answer to 1 and the no answer to 2
/// this will make it possible to check if answer haven't been filled in yet so it returns 0
/// </summary>
public class MultipleChoice : MonoBehaviour
{
    [Tooltip("0 = Not filled in, 1 = yes, 2 = no. PS. if the questionm is altered this may differ")]
    [SerializeField] private int correctAnswer = 0;
    [SerializeField] private int answer = 0;


    private void Start()
    {
        if (correctAnswer == 0)
        {
            Debug.LogWarning("CorrectAnswer on gameObject " + gameObject.name + " is still 0!");
        }
    }

    public void SetAnswer(int value)
    {
        answer = value;
        Debug.Log(answer);
    }

    public bool CheckAnswer()
    {
        if(answer == correctAnswer)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
