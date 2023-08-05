using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : MonoBehaviour
{
    public static Document Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
}
