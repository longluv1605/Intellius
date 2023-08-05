using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void Click()
    {
        SceneManager.LoadScene(1);
    }
}
