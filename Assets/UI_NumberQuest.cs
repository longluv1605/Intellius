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
