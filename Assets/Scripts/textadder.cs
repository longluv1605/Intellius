using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textaddertest : MonoBehaviour
{
    #region  Public Enumerations

    #endregion

    #region  Public Events

    #endregion

    #region  Public Properties

    #endregion

    #region  Public Methods

    #endregion

    #region  Private Fielids

    [SerializeField] private TextMeshProUGUI _text;

    #endregion

    #region Private Methods

    private void Awake()
    {

    }
    private void Update()
    {
        _text.text = Loadgame.Instance.getDocument();
    }

    #endregion
}
