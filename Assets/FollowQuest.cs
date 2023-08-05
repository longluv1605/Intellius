using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowQuest : MonoBehaviour
{
    public GameObject quest;
    private Vector2 position;
    private Button btn;

    private void Awake()
    {
        position = quest.transform.position;
        position.x += 0.25f;
        position.y += 1;
        gameObject.transform.position = position;
        
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener(() =>
        {
            QuesDialogUI.Instance.ShowQuestion(quest.GetComponent<Quest>().getQuesTxt(), 'A');
        });

        gameObject.SetActive(false);
    }
}
