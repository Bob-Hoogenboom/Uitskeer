using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownQuestion : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Dropdown dropDown;

    [SerializeField] List<string> optionsList;
    [SerializeField] string correctAnswer;



    // Start is called before the first frame update
    void Start()
    {
        dropDown.ClearOptions();
        dropDown.AddOptions(optionsList);
    }

    private bool CheckAnswer()
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



}
