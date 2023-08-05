using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    protected bool onClicked = false;
    protected string quesTxt;
    public GameObject excIcon;

    protected void OnTriggerStay2D(Collider2D collision)
    {
        onClicked = true;
        if (collision.gameObject.tag == "Player")
        {
            excIcon.gameObject.SetActive(true);
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        onClicked = false;
        excIcon.gameObject.SetActive(false);
    }

    protected void Update()
    {
        if (onClicked && QuesDialogUI.Instance.answered())
        {
            gameObject.SetActive(false);
        }
    }

    public void setQuesTxt(string input)
    {
        quesTxt = input;
    }

    public string getQuesTxt()
    {
        return quesTxt;
    }
}
