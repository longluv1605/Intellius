using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class endgame : MonoBehaviour
{

    private int Score; 
    public TextMeshProUGUI textScore;

    private void Awake() {
        Score = PlayerPrefs.GetInt("PlayerScore", 0);
        textScore.text = Score.ToString();
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }
}
