using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] List<Transform> _moveLimitPos;
    [SerializeField] float _moveSpeed;
    Vector2 _targetPos;

    void Start()
    {
        _targetPos = transform.position;
        Move(_moveSpeed);
    }

    private void Move(float speed)
    {
        var pos = _targetPos;
        while (Vector2.Distance(pos, _targetPos) < 8)
        {
            _targetPos.x = Random.Range(_moveLimitPos[0].position.x, _moveLimitPos[1].position.x);
            _targetPos.y = Random.Range(_moveLimitPos[0].position.y, _moveLimitPos[1].position.y);
        }
        var distance = Vector2.Distance(_targetPos, transform.position);
        var duration = distance / speed;
        transform.DOMove(_targetPos, duration).SetEase(Ease.Linear).OnComplete(() => Move(speed));
    }

}
