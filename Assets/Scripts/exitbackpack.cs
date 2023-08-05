using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitbackpack : MonoBehaviour
{
    public void exit()
    {
        Backpackscript.Instance.gameObject.SetActive(true);
        GameObject.Find("UI").gameObject.SetActive(false);
    }

}
