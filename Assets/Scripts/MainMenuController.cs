using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = -1;
        Time.timeScale = 1;
    }

    public void OpenLevel() => SceneManager.LoadScene(1);
    
    public void QuitGame() => Application.Quit();
}
