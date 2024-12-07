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
        _text.text = $"{Mathf.Floor(_timer / 60)}•ª{_timer % 60}•b";
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
