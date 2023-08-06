using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Documentary : MonoBehaviour
{
    public static UI_Documentary Instance { get; private set; }

    private TMP_InputField doc;

    private void Awake()
    {
        Instance = this;
        doc = transform.Find("Doc").GetComponent<TMP_InputField>();
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
        return doc.text;
    }
}
