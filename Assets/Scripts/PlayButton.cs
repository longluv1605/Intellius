using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private string number;
    private int num;

    public void Click()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        SceneManager.LoadScene(4);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Create()
    {
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
        UI_NumberQuest.Instance.Hide();
    }

    public void NextBtnTypeQuest()
    {
        if (num > 0)
        {
            //UI_QuestType.Instance.Hide();
            num--;
            string[] lines = new string[4];
            lines[0] = "|\n";
            lines[1] = UI_QuestType.Instance.getQuestion();
            lines[2] = UI_QuestType.Instance.getAnswer();
            lines[3] = "\n|";
            File.AppendAllLines(Application.dataPath + "/Quest.txt", lines);
            UI_QuestType.Instance.Show();

            if (num <= 0)
            {
                UI_QuestType.Instance.Hide();
            }
        }
    }
}
