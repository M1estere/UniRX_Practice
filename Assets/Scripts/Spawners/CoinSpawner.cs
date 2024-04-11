using Redcode.Extensions;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 10;
    [SerializeField] private GameObject _coinObject;
    
    private int _coinsAmount;
    
    private void Start()
    {
        _coinsAmount = FindObjectOfType<LevelController>().LevelConfiguration.CoinsAmount;
        
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _coinsAmount; i++)
        {
            var spawnPosition = (Random.insideUnitSphere * _spawnRadius).WithY(1.5f);
            Instantiate(_coinObject, spawnPosition, _coinObject.transform.rotation);
        }
    }
}
