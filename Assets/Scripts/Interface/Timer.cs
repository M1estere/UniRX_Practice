using System;
using UniRx;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _timerText;

    private int _startTime;
    private int _currentTime;

    private LevelController _levelController;

    private IDisposable _timer;
    
    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        
        _startTime = _levelController.LevelConfiguration.LevelTime;
        _currentTime = 0;
        
        _timerText.SetText(_startTime.ToString("00"));
    }

    private void Start()
    {
        _timer = Observable.Timer(TimeSpan.FromSeconds(_startTime)).Subscribe(delegate(long l)
        {
            FindObjectOfType<LevelFinishController>().DisplayGameOver(false);
            print("Time's up");
        });

        var stream = Observable.EveryUpdate();
        stream.Sample(TimeSpan.FromSeconds(1)).Subscribe(time => _timerText.SetText((_startTime - ++_currentTime).ToString("00")));
    }

    private void OnDisable()
    {
        _timer.Dispose();
    }
}
