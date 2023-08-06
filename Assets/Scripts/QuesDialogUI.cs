using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey;
using System.Collections;
using System.Collections.Generic;

public class QuesDialogUI : MonoBehaviour
{
    public static QuesDialogUI Instance { get; private set; }
    private int Score; 
    private TextMeshProUGUI textMessPro;
    private Button aButton;
    private Button bButton;
    private Button cButton;
    private Button dButton;
    private Button skipButton;
    public TextMeshProUGUI textScore;
    private bool isAnswered = false;
    public Canvas canvasCorrect;
    public Canvas canvasIncorrect;


    private void Awake()
    {   
        Instance = this;
        gameObject.SetActive(false);
        textMessPro = transform.Find("QuesText").GetComponent<TextMeshProUGUI>();
        aButton = transform.Find("AnsA").GetComponent<Button>();
        bButton = transform.Find("AnsB").GetComponent<Button>();
        cButton = transform.Find("AnsC").GetComponent<Button>();
        dButton = transform.Find("AnsD").GetComponent<Button>();
        skipButton = transform.Find("Skip").GetComponent<Button>();
        Score = 0;
        textScore.text = Score.ToString();
        PlayerPrefs.SetInt("PlayerScore", Score);
    }

    public void trueAns()
    {
            Score += 10;
            textScore.text = Score.ToString();
            Health.Instance.currentHealth += 10f;
            PlayerPrefs.SetInt("PlayerScore", Score);
            setCorrect();
    }

    public void falseAns()
    {
        CineCamShake.Instance.ShakeCam(5f, .1f);
        Health.Instance.currentHealth -= 10f;
        setIncorrect();
    }

    public bool answered()
    {
        bool temp = isAnswered;
        isAnswered = false;
        return temp;
    }

    public void ShowQuestion(string quesText, char trueAnswer)
    {
        gameObject.SetActive(true);
        Backpackscript.Instance.gameObject.SetActive(false);
        textMessPro.text = quesText;
        aButton.onClick.RemoveAllListeners();
        aButton.onClick.AddListener(() =>
        {
            isAnswered = true;
            Backpackscript.Instance.gameObject.SetActive(true);
            if (trueAnswer == 'A' || trueAnswer == 'a')
            {
                trueAns();
            }
            else
            {
                falseAns();
            }
            Hide();
        });
        bButton.onClick.RemoveAllListeners();
        bButton.onClick.AddListener(() =>
        {
            isAnswered = true;
            Backpackscript.Instance.gameObject.SetActive(true);
            if (trueAnswer == 'B' || trueAnswer == 'b')
            {
                trueAns();
            }
            else
            {
                falseAns();
            }
            Hide();
        });
        cButton.onClick.RemoveAllListeners();
        cButton.onClick.AddListener(() => {
            isAnswered = true;
            Backpackscript.Instance.gameObject.SetActive(true);
            if (trueAnswer == 'C' || trueAnswer == 'c')
            {
                trueAns();
            }
            else
            {

                falseAns();
            }
            Hide();
        });
        dButton.onClick.RemoveAllListeners();
        dButton.onClick.AddListener(() => {
            isAnswered = true;
            Backpackscript.Instance.gameObject.SetActive(true);
            if (trueAnswer == 'D' || trueAnswer == 'd')
            {
                trueAns();
            }
            else
            {
                falseAns();
            }
            Hide();
        });
        skipButton.onClick.RemoveAllListeners();
        skipButton.onClick.AddListener(() =>
        {
            Backpackscript.Instance.gameObject.SetActive(true);
            Hide();
        });

    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator setCorrect() {
        canvasCorrect.enabled = true;
        yield return new WaitForSeconds(5f);
        canvasCorrect.enabled = false;
    }

    private IEnumerator setIncorrect() {
        canvasIncorrect.enabled = true;
        yield return new WaitForSeconds(5f);
        canvasIncorrect.enabled = false;
    }
}
