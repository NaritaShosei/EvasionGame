using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] float _interval = 5;
    private float _timer;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] GameObject _enemy;
    List<GameObject> _enemyList = new();
    [SerializeField] int _maxEnemyCount;

    void Start()
    {
        _timer = Time.time;
    }

    void Update()
    {
        if (Time.time > _timer + _interval)
        {
            _timer = Time.time;
            Spawn();
        }
    }

    void Spawn()
    {
        if (_enemyList.Count < _maxEnemyCount)
        {
            _enemyList.Add(Instantiate(_enemy, Vector3.zero, Quaternion.identity));
        }
    }
}
