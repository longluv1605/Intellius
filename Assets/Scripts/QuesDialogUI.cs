using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
    }

    public void trueAns()
    {
            Score += 10;
            textScore.text = Score.ToString();
            Health.Instance.currentHealth += 10f;
    }

    public void falseAns()
    {
        CineCamShake.Instance.ShakeCam(5f, .1f);
         Health.Instance.currentHealth -= 10f;
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
            Hide();
            if (trueAnswer == 'A' || trueAnswer == 'a')
            {
                trueAns();
            }
            else
            {
                falseAns();
            }
        });
        bButton.onClick.RemoveAllListeners();
        bButton.onClick.AddListener(() =>
        {
            isAnswered = true;
            Backpackscript.Instance.gameObject.SetActive(true);
            Hide();
            if (trueAnswer == 'B' || trueAnswer == 'b')
            {
                trueAns();
            }
            else
            {
                falseAns();
            }
        });
        cButton.onClick.RemoveAllListeners();
        cButton.onClick.AddListener(() => {
            isAnswered = true;
            Backpackscript.Instance.gameObject.SetActive(true);
            Hide();
            if (trueAnswer == 'C' || trueAnswer == 'c')
            {
                trueAns();
            }
            else
            {
                falseAns();
            }
        });
        dButton.onClick.RemoveAllListeners();
        dButton.onClick.AddListener(() => {
            isAnswered = true;
            Backpackscript.Instance.gameObject.SetActive(true);
            falseAns();
            if (trueAnswer == 'D' || trueAnswer == 'd')
            {
                trueAns();
            }
            else
            {
                falseAns();
            }
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
}
