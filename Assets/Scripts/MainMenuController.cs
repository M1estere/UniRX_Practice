using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _soundCross;
    [SerializeField] private GameObject _musicCross;
        
    private ReactiveProperty<bool> _soundOn = new (true);
    private ReactiveProperty<bool> _musicOn = new (true);
    
    private void Awake()
    {
        Application.targetFrameRate = -1;
        Time.timeScale = 1;

        _soundOn.Subscribe(delegate(bool b)
        {
            _soundCross.SetActive(!b);
        });

        _musicOn.Subscribe(delegate(bool b)
        {
            _musicCross.SetActive(!b);
        });
    }

    public void ToggleValue(int type)
    {
        if (type == 0)
        {
            _soundOn.Value = !_soundOn.Value;
        }
        else
        {
            _musicOn.Value = !_musicOn.Value;
        }
    }
    
    public void OpenLevel() => SceneManager.LoadScene(1);
    
    public void QuitGame() => Application.Quit();
}
