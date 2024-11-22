using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] GameObject _blood;
    [SerializeField] List<Transform> _moveLimitPos;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var hMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        var vMove = Input.GetAxisRaw("Vertical") * _moveSpeed;
        _rb.velocity = new Vector2(hMove, vMove);
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, _moveLimitPos[0].position.x, _moveLimitPos[1].position.x);
        pos.y = Mathf.Clamp(pos.y, _moveLimitPos[0].position.y, _moveLimitPos[1].position.y);
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("YOU DIED");
        var blood = Instantiate(_blood, transform.position, Quaternion.identity);
        var bloodParticle = blood.GetComponent<ParticleSystem>();
        bloodParticle.Simulate(1);
        bloodParticle.Play();
    }
}
