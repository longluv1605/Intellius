using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCanvas : MonoBehaviour
{
    public Canvas canvasWin;
    public Canvas canvasLose;
    private int Score;
    // Example condition: The canvasWin will be shown if the player completed a specific level,
    // otherwise, canvasLose will be shown.
    private bool playerCompletedLevel;

    private void Awake()
    {
        Score = PlayerPrefs.GetInt("PlayerScore", 0);

        // Perform your condition check here.
        // For this example, let's assume playerCompletedLevel is true when the level is completed.

        if (Score >= 50)
        {
            ShowCanvasWin();
        }
        else
        {
            ShowCanvasLose();
        }
    }

    private void ShowCanvasWin()
    {
        canvasWin.enabled = true; // Show canvasWin.
        canvasLose.enabled = false; // Hide canvasLose.
    }

    private void ShowCanvasLose()
    {
        canvasWin.enabled = false; // Hide canvasWin.
        canvasLose.enabled = true; // Show canvasLose.
    }
}
