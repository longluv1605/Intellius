using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Quit : MonoBehaviour
{
    public void quitButton() {
        SceneManager.LoadScene(2);
    }
}
