using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_NumberQuest : MonoBehaviour
{
    public static UI_NumberQuest Instance { get; private set; }

    private TMP_InputField inputField;

    private void Awake()
    {
        Instance = this;
        inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        inputField.onValidateInput = (string text, int charIndex, char addChar) =>
        {
            return ValidateChar("123456890", addChar);
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

    public string getText()
    {
        return inputField.text;
    }
}
