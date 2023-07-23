using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnController : MonoBehaviour
{
    [SerializeField] private GameObject _zombiePrefab;
    [Header("Spawn Period")]
    [SerializeField] private float _spawnPeriod = 5;
    [Header("Spawn Location")]
    [SerializeField] private Transform _player;
    [SerializeField] private float _minSpawnDistanceFromPlayer = 3;
    [SerializeField] private float _maxSpawnDistanceFromPlayer = 10;
    private float _timeUntilNextSpawn;

    private void Start()
    {
        _timeUntilNextSpawn = _spawnPeriod;
    }

    private void Update()
    {
        _timeUntilNextSpawn -= Time.deltaTime;
        if (_timeUntilNextSpawn <= 0)
        {
            _timeUntilNextSpawn += _spawnPeriod;
            _SpawnNew();
        }
    }

    private void _SpawnNew()
    {
        GameObject newZombie = Instantiate(_zombiePrefab);
        newZombie.transform.position = _GetNextZombieSpawnLocation();
    }

    private Vector2 _GetNextZombieSpawnLocation()
    {
        float distanceFromPlayer = Random.Range(_minSpawnDistanceFromPlayer, _maxSpawnDistanceFromPlayer);
        Vector2 direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return (Vector2)_player.position + direction * distanceFromPlayer;
    }
}
