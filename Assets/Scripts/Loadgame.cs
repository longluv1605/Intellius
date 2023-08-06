using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Loadgame : MonoBehaviour
{
    public static Loadgame Instance { get; private set; }
    private string[] positions;
    private string[] questions;
    private string documentary;
    private int numberOfQuestions;

    public GameObject questPrefab;

    void Start()
    {
        /*
        string filePath = Application.dataPath + "/Position.txt";
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                int i = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split() as string[];
                    //Debug.Log(parts[0] + " " + parts[1] + "\n");

                    float.TryParse(parts[0], out float x);
                    float.TryParse(parts[1], out float y);
                    //Debug.Log(x + " " + y);

                    GameObject quest = Instantiate(questPrefab);
                    quest.transform.position = new Vector3((float) x, (float) y, 1);
                    quest.name = "Quest" + i.ToString();
                    i++;
                    
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        */
        Instance = this;

        positions = File.ReadAllLines(Application.dataPath + "/Position.txt");
        questions = File.ReadAllLines(Application.dataPath + "/Quest.txt");
        documentary = File.ReadAllText(Application.dataPath + "/Document.txt");
        numberOfQuestions = int.Parse(questions[0]);

        int q = 0;
        for (int i = 1; i < questions.Length; i++) 
        {
            if (questions[i] == "|")
            {
                ++i;
                string questText = "";
                while (questions[i + 1] != "|") 
                {
                    questText += questions[i] += "\n";
                    ++i;
                }
                
                char trueAns = char.Parse(questions[i++]);
                
                string[] parts = positions[q++].Split() as string[];

                float.TryParse(parts[0], out float x);
                float.TryParse(parts[1], out float y);

                GameObject quest = Instantiate(questPrefab);
                quest.transform.position = new Vector3((float)x, (float)y, 1);
                quest.name = "Quest" + q.ToString();
                quest.transform.GetComponent<Quest>().setInput(questText, trueAns);
            }
        }
    }

    public string getDocument()
    {
        return documentary;
    }

    public int getNumberOfQuestions()
    {
        return numberOfQuestions;
    }
}
