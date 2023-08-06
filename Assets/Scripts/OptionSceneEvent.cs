using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class OptionSceneEvent : MonoBehaviour
{
    public void Literature()
    {

    }

    public void Math()
    {

    }

    public void Physic()
    {

    }

    public void Biology()
    {
        string[] questions = File.ReadAllLines(Application.dataPath + "/TemplateQuest.txt");
        string documentary = File.ReadAllText(Application.dataPath + "/TemplateDoc.txt");

        File.WriteAllLines(Application.dataPath + "/Quest.txt", questions);
        File.WriteAllText(Application.dataPath + "/Document.txt", documentary);
        SceneManager.LoadScene(1);
    }

    public void Chemistry()
    {

    }

    public void Art()
    {

    }

    public void Geography()
    {
    }

    public void History()
    {

    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
