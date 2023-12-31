using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Backpackscript : MonoBehaviour
{
    public static Backpackscript Instance { get; private set; }
    private Button thisButton;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(true);
        thisButton = this.GetComponent<Button>();
        thisButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            OpenBackpack();
        });
    }

    private void OpenBackpack()
    {
        Document.Instance.gameObject.SetActive(true);
    }
}
