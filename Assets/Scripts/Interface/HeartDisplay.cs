using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private Transform _heartsParent;
    [SerializeField] private GameObject _heartObject;

    private LevelController _levelController;

    private ReactiveProperty<int> _lives;
    private List<HeartController> _hearts;
    
    private void Awake()
    {
        _hearts = new();
        _levelController = FindObjectOfType<LevelController>();

        _lives = new (_levelController.LevelConfiguration.LivesAmount);
        _lives.Skip(1).Subscribe(delegate(int i)
        {
            _hearts[i].DisableHeart();
            print($"Damage taken (health: {i})");
        });
    }

    private void Start()
    {
        for (int i = 0; i < _levelController.LevelConfiguration.LivesAmount; i++)
        {
            _hearts.Add(Instantiate(_heartObject, _heartsParent).GetComponent<HeartController>());
        }

        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.L)).Subscribe(_ => TakeDamage());
    }

    public void TakeDamage()
    {
        _lives.Value--;
        if (_lives.Value <= 0)
        {
            FindObjectOfType<LevelFinishController>().DisplayGameOver(false);
        }
    }
}