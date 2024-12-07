using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] float _normalSpawnInterval = 5;
    [SerializeField] float _targetSpawnInterval = 8;
    private float _normalSpawnTimer;
    private float _targetSpawnTimer;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] GameObject _enemy;
    [SerializeField] GameObject _targetEnemy;
    List<GameObject> _enemyList = new();
    [SerializeField] int _maxEnemyCount;
    [SerializeField] PlayerController _player;

    void Start()
    {
        _normalSpawnTimer = Time.time;
        _targetSpawnTimer = Time.time;
    }

    void Update()
    {
        if (Time.time > _normalSpawnTimer + _normalSpawnInterval)
        {
            _normalSpawnTimer = Time.time;
            Spawn();
        }
        if (Time.time > _targetSpawnTimer + _targetSpawnInterval)
        {
            _targetSpawnTimer = Time.time;
            TargetSpawn();
        }
    }

    void Spawn()
    {
        if (_enemyList.Count < _maxEnemyCount)
        {
            _enemyList.Add(Instantiate(_enemy, transform.position, Quaternion.identity));
        }
    }
    void TargetSpawn()
    {
        if (_player)
        {
            var dir = _player.transform.position - transform.position;
            var enemy = Instantiate(_targetEnemy, transform.position, Quaternion.LookRotation(Vector3.forward, dir));
            Destroy(enemy, 4);
        }
    }
}
