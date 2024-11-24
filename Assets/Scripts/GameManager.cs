using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _text;
    bool _isPlayerDead;
    float _timer;
    static float _surviveTimer;

    void Start()
    {

    }

    void Update()
    {
        _text.text = _timer.ToString();
        if (!_isPlayerDead)
        {
            _timer += Time.deltaTime;
        }
        if (_isPlayerDead)
        {
            _surviveTimer = _timer;
        }
    }

    public void PlayerDeath()
    {
        _isPlayerDead = true;
    }
}
