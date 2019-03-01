using UnityEngine.SceneManagement;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void ScenesManager()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitToGame()
    {
        Application.Quit();
    }
}
