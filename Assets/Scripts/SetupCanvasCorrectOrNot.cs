using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCanvasCorrectOrNot : MonoBehaviour
{
    public Canvas canvasCorrect;
    public Canvas canvasIncorrect;

    private void Start() {
        canvasCorrect.enabled = false;
        canvasIncorrect.enabled = false;
    }
}
