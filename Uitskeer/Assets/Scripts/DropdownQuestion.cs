using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownQuestion : MonoBehaviour, IQuestion
{
    [SerializeField] TMPro.TMP_Dropdown dropDown;

    [SerializeField] List<string> optionsList;
    [SerializeField] string correctAnswer;
    [SerializeField] Image Image;
    public Color wrongColor = new Color(255, 192, 192);



    // Start is called before the first frame update
    void Start()
    {
        dropDown.ClearOptions();
        dropDown.AddOptions(optionsList);
    }


    public void Reset()
    {
        dropDown.value = 0;
        dropDown.RefreshShownValue();
    }

    public bool CheckAnswer()
    {
        string currentOption = dropDown.options[dropDown.value].text;

        if (currentOption == correctAnswer)
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
        Image.color = new Color (0.95f, 0.95f, 0.95f);
    }

}
