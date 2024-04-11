using System;
using UniRx;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _timerText;

    private int _startTime;
    private int _currentTime;

    private LevelController _levelController;
    
    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        
        _startTime = _levelController.LevelConfiguration.LevelTime;
        _currentTime = 0;
        
        _timerText.SetText(_startTime.ToString("00"));
    }

    private void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(15)).Subscribe(delegate(long l)
        {
            // TO-DO: Display Game Over
            print("Time's up");
        });

        var stream = Observable.EveryUpdate();
        stream.Sample(TimeSpan.FromSeconds(1)).Subscribe(time => _timerText.SetText((_startTime - ++_currentTime).ToString("00")));
    }
}
