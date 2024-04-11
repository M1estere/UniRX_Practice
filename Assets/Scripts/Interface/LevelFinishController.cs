using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _completionScreen;
    
    public void DisplayGameOver(bool completed)
    {
        (completed ? _completionScreen : _gameOverScreen).SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
