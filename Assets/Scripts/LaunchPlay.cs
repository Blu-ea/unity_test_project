using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchPlay : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
