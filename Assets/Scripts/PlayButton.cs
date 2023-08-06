using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private string number;
    private int num;
    private bool created = false;
    public GameObject play;
    public GameObject quit;
    public GameObject options;
    public GameObject create;


    /*private void Awake()
    {
        play = GameObject.Find("Play");
        quit = GameObject.Find("quit");
        options = GameObject.Find("options");
    }*/

    public void Play()
    {
        if (!created)
        {
            string[] questions = File.ReadAllLines(Application.dataPath + "/TemplateQuest.txt");
            string documentary = File.ReadAllText(Application.dataPath + "/TemplateDoc.txt");

            File.WriteAllLines(Application.dataPath + "/Quest.txt", questions);
            File.WriteAllText(Application.dataPath + "/Document.txt", documentary);
        }
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Create()
    {
        created = true;
        play.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        create.gameObject.SetActive(false);
        UI_NumberQuest.Instance.Show();
    }

    public void NextBtnNumQuest()
    {
        UI_NumberQuest.Instance.Hide();
        number = UI_NumberQuest.Instance.getText();
        num = int.Parse(number);
        string[] lines = new string[1];
        lines[0] = number;
        File.WriteAllLines(Application.dataPath + "/Quest.txt", lines);
        UI_QuestType.Instance.Show();
    }

    public void CancelBtnNumQuest()
    {
        created = false;
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        create.gameObject.SetActive(true);
        UI_NumberQuest.Instance.Hide();
    }

    public void NextBtnTypeQuest()
    {
        if (num > 0)
        {
            //UI_QuestType.Instance.Hide();
            num--;
            string[] lines = new string[4];
            lines[0] = "|";
            lines[1] = UI_QuestType.Instance.getQuestion();
            lines[2] = UI_QuestType.Instance.getAnswer();
            lines[3] = "|";
            File.AppendAllLines(Application.dataPath + "/Quest.txt", lines);
            UI_QuestType.Instance.Show();

            if (num <= 0)
            {
                UI_QuestType.Instance.Hide();
                UI_Documentary.Instance.Show();
            }
        }
    }

    public void CancelBtnDocument()
    {
        UI_Documentary.Instance.Hide();
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        create.gameObject.SetActive(true);
        File.WriteAllText(Application.dataPath + "/Document.txt", "");
    }

    public void FinishBtnDocument()
    {
        UI_Documentary.Instance.Hide();
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        create.gameObject.SetActive(true);
        File.WriteAllText(Application.dataPath + "/Document.txt", UI_Documentary.Instance.getText());
    }
}
