using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UI_QuestType : MonoBehaviour
{
    public static UI_QuestType Instance { get; private set; }

    private TMP_InputField question;
    private TMP_InputField answer;

    private void Awake()
    {
        Instance = this;
        question = transform.Find("Question").GetComponent<TMP_InputField>();
        answer = transform.Find("Answer").GetComponent<TMP_InputField>();
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        question.text = null;
        answer.text = null;
        answer.characterLimit = 1;
        answer.onValidateInput = (string text, int charIndex, char addChar) =>
        {
            return ValidateChar("ABCDabcd", addChar);
        };
    }

    private char ValidateChar(string validateChars, char addChar)
    {
        if (validateChars.IndexOf(addChar) != -1)
        {
            return addChar;
        }
        else
        {
            return '\0';
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public string getAnswer()
    {
        return answer.text;
    }

    public string getQuestion()
    {
        return question.text;
    }
}
