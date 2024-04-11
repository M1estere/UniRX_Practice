using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Transform _coinsParent;
    [SerializeField] private GameObject _coinObject;

    private LevelController _levelController;

    private ReactiveProperty<int> _coinsAmount;
    private List<CoinController> _coins;
    
    private void Awake()
    {
        _coins = new();
        _levelController = FindObjectOfType<LevelController>();

        _coinsAmount = new(0);
        _coinsAmount.Skip(1).Subscribe(delegate(int i)
        {
            _coins[i - 1].EnableCoin();
            print($"You now have {i} coins");
        });
    }

    private void Start()
    {
        for (int i = 0; i < _levelController.LevelConfiguration.CoinsAmount; i++)
        {
            _coins.Add(Instantiate(_coinObject, _coinsParent).GetComponent<CoinController>());
        }

        Observable.EveryUpdate().Where(_ => Input.GetKeyDown(KeyCode.K)).Subscribe(_ => TakeCoin());
    }

    public void TakeCoin()
    {
        _coinsAmount.Value++;

        if (_coinsAmount.Value >= _coins.Count)
        {
            // TO-DO: Level Completion
            print("You've won!");
        }
    }
}
