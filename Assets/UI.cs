using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
}
