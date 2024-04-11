using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private Transform _coinsParent;
    [SerializeField] private GameObject _coinObject;

    private LevelController _levelController;

    private int _coinsAmount = 0;
    private List<CoinController> _coins;

    private ReactiveCommand<int> _increaseCoins;
    
    private void Awake()
    {
        _coins = new();
        _levelController = FindObjectOfType<LevelController>();

        _increaseCoins = new ReactiveCommand<int>();
        _increaseCoins.Subscribe(delegate(int i)
        {
            _coinsAmount += i;
            _coins[_coinsAmount - 1].EnableCoin();

            if (_coinsAmount >= _coins.Count)
            {
                FindObjectOfType<LevelFinishController>().DisplayGameOver(true);
            }
        });

        /*_coinsAmount = new(0);
        _coinsAmount.Skip(1).Subscribe(delegate(int i)
        {
            _coins[i - 1].EnableCoin();
            print($"You now have {i} coins");
        });*/
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
        _increaseCoins.Execute(1);
    }
}
