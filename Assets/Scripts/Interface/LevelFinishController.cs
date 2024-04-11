using UnityEngine;

public class LevelFinishController : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _completionScreen;
    
    public void DisplayGameOver(bool completed)
    {
        (completed ? _completionScreen : _gameOverScreen).SetActive(true);
        Time.timeScale = 0;
    }
}
