using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
