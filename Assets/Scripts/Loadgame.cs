using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Loadgame : MonoBehaviour
{
    public GameObject questPrefab;
    void Start()
    {
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
                    quest.name = "quest" + i.ToString();
                    i++;
                    
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
