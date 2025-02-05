using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseButton;
    public void PauseButton()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
    }

    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
    }

    public void HomeButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen");
    }
}
