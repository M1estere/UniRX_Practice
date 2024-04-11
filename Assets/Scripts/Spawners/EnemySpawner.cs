using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyObject;

    private List<Vector3> _spawnPositions;
    private int _enemiesAmount;
    
    private void Awake()
    {
        _spawnPositions = new();
        foreach (Transform positionObject in transform)
        {
            _spawnPositions.Add(positionObject.position);
        }
    }

    private void Start()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        _enemiesAmount = Random.Range(levelController.LevelConfiguration.MinEnemies, levelController.LevelConfiguration.MaxEnemies + 1);
        
        Spawn();
    }

    private void Spawn()
    {
        _enemiesAmount = Mathf.Clamp(_enemiesAmount, 0, _spawnPositions.Count);
        
        List<Vector3> positions = new(_spawnPositions);
        
        for (int i = 0; i < _enemiesAmount; i++)
        {
            int positionIndex = Random.Range(0, positions.Count);
            Instantiate(_enemyObject, positions[positionIndex], _enemyObject.transform.rotation);
            positions.RemoveAt(positionIndex);
        }
    }
}
