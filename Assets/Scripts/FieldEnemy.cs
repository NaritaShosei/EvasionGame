using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class FieldEnemy : MonoBehaviour
{
    [SerializeField] float _interval = 5;
    float _timer;
    [SerializeField] SpriteRenderer _sr;
    [SerializeField] CircleCollider2D _collider;
    PlayerController _player;

    void Start()
    {
        _player = FindObjectOfType<PlayerController>();
        _timer = Time.time;
    }

    void Update()
    {
        if (Time.time > _timer + _interval)
        {
            _timer = Time.time;
            Attack();
        }

    }

    private void Attack()
    {
        transform.position = _player.transform.position;
        _sr.DOFade(1, 1).OnComplete(() =>
        {
            _sr.color = Color.red;
            _collider.enabled = true;
            StartCoroutine(Invisible());
        });

    }

    IEnumerator Invisible()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Invisible");
        _collider.enabled = false;
        _sr.DOFade(0, 0.5f).OnComplete(() => _sr.color = new Color(1, 1, 1, 0));
        _timer = Time.time;
    }
}
